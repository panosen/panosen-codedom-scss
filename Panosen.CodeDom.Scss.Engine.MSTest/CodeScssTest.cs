using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.CodeDom.Css;

namespace Panosen.CodeDom.Scss.Engine.MSTest
{
    [TestClass]
    public class CodeScssTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var codeScss = PrepareCodeScss();

            var actual = codeScss.TransformText();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        public CodeScss PrepareCodeScss()
        {
            CodeScss codeScss = new CodeScss();

            codeScss.Name = ".basic";
            codeScss.AddProperty("margin", "10px");
            codeScss.AddProperty("background-color", "#f00");

            {
                var scss = codeScss.AddChild("&.active");
                scss.AddProperty("margin", "5px", "abc");
            }

            {
                var scss = codeScss.AddChild("&.disable");
                scss.AddProperty("margin", "6px");

                {
                    var scss2 = scss.AddChild("a", "def");
                    scss2.AddProperty("background-color", "#f00");
                }
            }

            return codeScss;
        }

        private string PrepareExpected()
        {
            return @".basic {
    background-color: #f00;
    margin: 10px;

    &.active {
        /* abc */
        margin: 5px;
    }

    &.disable {
        margin: 6px;

        /* def */
        a {
            background-color: #f00;
        }
    }
}
";
        }
    }
}
