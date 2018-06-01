// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.UriParser
{
    using Irony.Parsing;
    internal static class ParserExtensions
    {
        public static BnfExpression Q(this BnfExpression bnf, string name)
        {
            bnf = bnf.Q();
            bnf.Name = name;
            return bnf;
        }
    }
}
