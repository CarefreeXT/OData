// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.UriParser
{
    using Caredev.OData.Core.UriParser.Terminals;
    using Irony.Parsing;
    using System;
    internal static class ODataTermianlFacotry
    {
        public static Terminal CreateGuid(string name)
        {
            return new GuidLiteral(name);
        }

        public static Terminal CreateCustomQueryOption(string name)
        {
            return new CustomQueryOptionTerminal(name);
        }

        public static Terminal CreateBinary(string name)
        {
            return new BinaryLiteral(name);
        }

        public static Terminal CreateDate(string name)
        {
            return new DateTimeLiteral(name, EDateTimeKind.Date);
        }

        public static Terminal CreateDateTime(string name)
        {
            return new DateTimeLiteral(name, EDateTimeKind.DateTime);
        }

        public static Terminal CreateDateTimeOffset(string name)
        {
            return new DateTimeLiteral(name, EDateTimeKind.DateTimeOffset);
        }

        public static Terminal CreateTimeOfDay(string name)
        {
            return new DateTimeLiteral(name, EDateTimeKind.TimeOfDay);
        }

        public static Terminal CreateDuration(string name)
        {
            return new DateTimeLiteral(name, EDateTimeKind.TimeSpan);
        }
    }
}
