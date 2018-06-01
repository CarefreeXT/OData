// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData
{
    using System;
#if NETSTANDARD2_0
    using Microsoft.AspNetCore.Mvc;
    public abstract class ODataController : ControllerBase
#else
    using System.Web.Http;
    public abstract class ODataController: ApiController
#endif
    {
    }
}