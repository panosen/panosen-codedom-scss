using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Scss.Engine
{
    /// <summary>
    /// CodeScssFileExtension
    /// </summary>
    public static class CodeScssFileExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        /// <param name="codeScssFile"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string TransformText(this CodeScssFile codeScssFile, GenerationOptions options = null)
        {
            var builder = new StringBuilder();

            new ScssCodeEngine().Generate(codeScssFile, builder, options);

            return builder.ToString();
        }
    }
}
