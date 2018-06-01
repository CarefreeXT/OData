// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.UriParser.Terminals
{
    using Irony.Parsing;
    using System;
    using System.Collections.Generic;

    internal class BinaryLiteral : Terminal
    {
        public BinaryLiteral(string name)
            : base(name)
        { }

        public override Token TryMatch(ParsingContext context, ISourceStream source)
        {
            try
            {
                var left = GetByte(source.PreviewChar);
                var right = GetByte(source.NextPreviewChar);
                if (left >= 0 && right >= 0)
                {
                    var list = new List<byte>();
                    do
                    {

                        list.Add(Convert.ToByte(left * 16 + right));
                        source.PreviewPosition += 2;
                        left = GetByte(source.PreviewChar);
                        right = GetByte(source.NextPreviewChar);
                    } while (left >= 0 && right >= 0);
                    return source.CreateToken(this.OutputTerminal, list.ToArray());
                }
                return null;
            }
            catch (Exception ex)
            {
                return context.CreateErrorToken(ex.Message);
            }
        }

        private int GetByte(char c)
        {
            if (c >= '0' && c < '9')
            {
                return (int)(c - '0');
            }
            else if (c >= 'a' && c <= 'f')
            {
                return ((int)(c - 'a')) + 10;
            }
            else if (c >= 'A' && c <= 'F')
            {
                return ((int)(c - 'A')) + 10;
            }
            return -1;
        }
    }
}
