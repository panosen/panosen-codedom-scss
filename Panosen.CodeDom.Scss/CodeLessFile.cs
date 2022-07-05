using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Scss
{
    /// <summary>
    /// scss 文件
    /// </summary>
    public class CodeScssFile
    {
        /// <summary>
        /// 变量
        /// </summary>
        public Dictionary<string, string> Variables { get; set; }

        /// <summary>
        /// scss 样式
        /// </summary>
        public List<CodeScss> CodeScssList { get; set; }
    }

    /// <summary>
    /// extension
    /// </summary>
    public static class CodeScssFileExtension
    {
        /// <summary>
        /// 添加变量
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CodeScssFile AddVariable(this CodeScssFile codeFile, string key, string value)
        {
            if (codeFile.Variables == null)
            {
                codeFile.Variables = new Dictionary<string, string>();
            }

            codeFile.Variables.Add(key, value);

            return codeFile;
        }

        /// <summary>
        /// add css
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="codeScss"></param>
        public static CodeScssFile AddCodeScss(this CodeScssFile codeFile, CodeScss codeScss)
        {
            if (codeFile.CodeScssList == null)
            {
                codeFile.CodeScssList = new List<CodeScss>();
            }

            codeFile.CodeScssList.Add(codeScss);

            return codeFile;
        }

        /// <summary>
        /// add css
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="name"></param>
        /// <param name="comment"></param>
        public static CodeScss AddCodeScss(this CodeScssFile codeFile, string name = null, string comment = null)
        {
            if (codeFile.CodeScssList == null)
            {
                codeFile.CodeScssList = new List<CodeScss>();
            }

            CodeScss codeScss = new CodeScss();
            codeScss.Name = name;
            codeScss.Comment = comment;

            codeFile.CodeScssList.Add(codeScss);

            return codeScss;
        }
    }
}
