using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Scss.Engine.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
            codeScss.Margin = "10px";
            codeScss.BackgroundColor = "#f00";

            {
                var scss = codeScss.AddChild("&.active");
                scss.Margin = "5px";
            }

            {
                var scss = codeScss.AddChild("&.disable");
                scss.Margin = "6px";

                {
                    var scss2 = scss.AddChild("a");
                    scss2.BackgroundColor = "#f00";
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
        margin: 5px;
    }

    &.disable {
        margin: 6px;

        a {
            background-color: #f00;
        }
    }
}
";
        }
    }
}
