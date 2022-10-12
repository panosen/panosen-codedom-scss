using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Scss.Engine
{
    /// <summary>
    /// CodeScssExtension
    /// </summary>
    public static class CodeScssExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        /// <param name="codeScss"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string TransformText(this CodeScss codeScss, GenerationOptions options = null)
        {
            var builder = new StringBuilder();

            new ScssCodeEngine().Generate(codeScss, builder, options);

            return builder.ToString();
        }
    }
}
