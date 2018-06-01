// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.UriParser.Terminals
{
    using Irony.Parsing;
    using System;
    internal class GuidLiteral : Terminal
    {
        public GuidLiteral(string name)
            : base(name)
        { }

        public override Token TryMatch(ParsingContext context, ISourceStream source)
        {
            try
            {
                var previewPosition = source.Location.Position + 36;
                if (source.Text.Length >= previewPosition)
                {
                    source.PreviewPosition = previewPosition;
                    var body = source.Text.Substring(source.Location.Position, 36);
                    if (Guid.TryParse(body, out Guid value))
                    {
                        return source.CreateToken(this.OutputTerminal, value);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return context.CreateErrorToken(ex.Message);
            }
        }
    }
}