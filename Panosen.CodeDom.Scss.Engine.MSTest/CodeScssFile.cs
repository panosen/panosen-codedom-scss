using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.CodeDom.Css;

namespace Panosen.CodeDom.Scss.Engine.MSTest
{
    [TestClass]
    public class CodeScssFileTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var codeScssFile = PrepareCodeScss();

            var actual = codeScssFile.TransformText(new GenerationOptions
            {
                TabString = "  "
            });

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        public CodeScssFile PrepareCodeScss()
        {
            var codeScssFile = new CodeScssFile();
            codeScssFile.Summary = "Sample";

            for (int i = 0; i < 2; i++)
            {
                var codeScss = codeScssFile.AddScss($".basic{i}");

                codeScss.AddProperty("margin", "10px");
                codeScss.AddProperty("background-color", "#f00");

                {
                    var scss = codeScss.AddChild("&.active");
                    scss.AddProperty("margin", "5px");
                }

                {
                    var scss = codeScss.AddChild("&.disable");
                    scss.AddProperty("margin", "6px");

                    {
                        var scss2 = scss.AddChild("a");
                        scss2.AddProperty("background-color", "#f00");
                    }
                }
            }

            return codeScssFile;
        }

        private string PrepareExpected()
        {
            return @"/*!
 * Sample
 */

.basic0 {
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

.basic1 {
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
