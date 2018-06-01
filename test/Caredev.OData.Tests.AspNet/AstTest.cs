using System;
using Caredev.OData.Core.UriParser;
using Irony.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caredev.OData.Tests
{
    [TestClass]
    public class AstTest
    {

        private readonly static ODataGrammar Grammar = new ODataGrammar();
       
        [TestMethod]
        public void TestMethod1()
        {
            var parser = new Parser(Grammar);
            var result = parser.Parse("enum Edm.Int32 'AAAAA'");

           
        }
    }
}
