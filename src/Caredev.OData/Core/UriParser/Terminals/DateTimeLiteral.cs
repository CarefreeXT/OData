// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.UriParser.Terminals
{
    using Irony.Parsing;
    using System;
    internal class DateTimeLiteral : Terminal
    {
        private readonly EDateTimeKind _Kind;

        public DateTimeLiteral(string name, EDateTimeKind kind)
           : base(name)
        {
            _Kind = kind;
        }

        public override Token TryMatch(ParsingContext context, ISourceStream source)
        {
            try
            {
                var text = source.Text;
                switch (_Kind)
                {
                    case EDateTimeKind.Date:
                        return source.CreateToken(this.OutputTerminal, DateTime.Parse(PreivewDate(source)));
                    case EDateTimeKind.TimeOfDay:
                        return source.CreateToken(this.OutputTerminal, DateTime.Parse(PreivewTime(source)));
                    case EDateTimeKind.DateTime:
                        {
                            var date = PreivewDate(source);
                            source.IsChar('T');
                            var time = PreivewTime(source, source.PreviewPosition);
                            return source.CreateToken(this.OutputTerminal, DateTime.Parse(date + " " + time));
                        }
                    case EDateTimeKind.DateTimeOffset:
                        {
                            var date = PreivewDate(source);
                            source.IsChar('T');
                            var time = PreivewTime(source, source.PreviewPosition);
                            if (source.PreviewChar == '+' || source.PreviewChar == '-')
                            {
                                var zone = PreviewZone(source, source.PreviewPosition);
                                return source.CreateToken(this.OutputTerminal, DateTime.Parse(date + " " + time + " " + zone));
                            }
                            else
                            {
                                source.IsChar('Z');
                            }
                            return source.CreateToken(this.OutputTerminal, DateTime.Parse(date + " " + time));
                        }
                    case EDateTimeKind.TimeSpan:
                        {
                            var multi = source.PreviewChar == '-' ? -1 : 1;
                            if (source.PreviewChar == '+')
                            {
                                source.Position++;
                            }
                            source.IsChar('P');
                            var day = PreviewDigit(source);
                            source.IsChar('D');
                            var space = TimeSpan.FromDays(Convert.ToDouble(day) * multi);
                            if (source.PreviewChar == 'T')
                            {
                                source.PreviewPosition++;
                                var iscontinue = true;
                                do
                                {
                                    var val = PreviewDigit(source);
                                    switch (source.PreviewChar)
                                    {
                                        case 'H':
                                            space += TimeSpan.FromHours(Convert.ToDouble(val) * multi);
                                            break;
                                        case 'M':
                                            space += TimeSpan.FromMinutes(Convert.ToDouble(val) * multi);
                                            break;
                                        case 'S':
                                            space += TimeSpan.FromSeconds(Convert.ToDouble(val) * multi);
                                            break;
                                        default:
                                            iscontinue = false;
                                            break;
                                    }
                                    if (iscontinue)
                                    {
                                        source.PreviewPosition++;
                                    }
                                } while (iscontinue && Char.IsDigit(source.PreviewChar));
                            }
                            return source.CreateToken(this.OutputTerminal, space);
                        }
                    default:
                        return context.CreateErrorToken("not suppored datetimekind.");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string PreivewDate(ISourceStream source)
        {
            source.IsDigit(4);
            source.IsChar('-');
            source.IsDigit(1, 2);
            source.IsChar('-');
            source.IsDigit(1, 2);
            return source.PreviewString();
        }

        private string PreivewTime(ISourceStream source, int index = -1)
        {
            source.IsDigit(1, 2);
            source.IsChar(':');
            source.IsDigit(1, 2);
            source.IsChar(':');
            source.IsDigit(1, 2);
            if (source.PreviewChar == '.')
            {
                source.PreviewPosition++;
                source.IsDigit(1, 12);
            }
            if (index > -1)
            {
                return source.PreviewString(index);
            }
            return source.PreviewString();
        }

        private string PreviewZone(ISourceStream source, int index)
        {
            source.PreviewPosition++;
            source.IsDigit(1, 2);
            source.IsChar(':');
            source.IsDigit(1, 2);
            return source.PreviewString(index);
        }

        private string PreviewDigit(ISourceStream source)
        {
            var index = source.PreviewPosition;
            var startIndex = index;
            var text = source.Text;
            if (!char.IsDigit(text[index++]))
            {
                throw new InvalidCastException();
            }
            while (char.IsDigit(text[index]) || text[index] == '.')
            {
                index++;
            }
            source.PreviewPosition = index;
            return source.PreviewString(startIndex);
        }
    }
}
