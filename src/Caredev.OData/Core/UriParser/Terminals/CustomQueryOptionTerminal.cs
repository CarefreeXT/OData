// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.UriParser.Terminals
{
    using Irony.Parsing;
    using System;
    internal class CustomQueryOptionTerminal : Terminal
    {
        public CustomQueryOptionTerminal(string name)
            : base(name)
        { }


        public override Token TryMatch(ParsingContext context, ISourceStream source)
        {
            if (!IsValid(source.PreviewChar))
            {
                return null;
            }
            source.PreviewPosition++;
            do
            {
                var current = source.PreviewChar;
                if (!IsValid(source.PreviewChar))
                {
                    break;
                }
                source.PreviewPosition++;
            }
            while (!source.EOF());
            var value = source.PreviewString();
            return source.CreateToken(this.OutputTerminal, value);
        }

        private bool IsValid(char current)
        {
            return current != '?' && current != '$' && current != '='
                    && current != '&' && current != '@';
        }
    }
}
