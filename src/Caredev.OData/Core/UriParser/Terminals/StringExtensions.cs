// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.UriParser.Terminals
{
    using Irony.Parsing;
    using System;

    internal static class StringExtensions
    {

        public static string PreviewString(this ISourceStream source)
        {
            var index = source.Location.Position;
            return source.Text.Substring(index, source.PreviewPosition - index);
        }

        public static string PreviewString(this ISourceStream source, int index)
        {
            return source.Text.Substring(index, source.PreviewPosition - index);
        }

        public static void IsChar(this ISourceStream source, char value)
        {
            if (source.PreviewChar != value)
            {
                throw new InvalidCastException();
            }
            source.PreviewPosition++;
        }

        public static void IsDigit(this ISourceStream source, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (!Char.IsDigit(source.PreviewChar))
                {
                    throw new InvalidCastException();
                }
                source.PreviewPosition++;
            }
        }

        public static void IsDigit(this ISourceStream source, int minLength, int maxLength)
        {
            IsDigit(source, minLength);
            var length = maxLength - minLength;
            for (int i = 0; i < length; i++)
            {
                if (Char.IsDigit(source.PreviewChar))
                {
                    source.PreviewPosition++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
