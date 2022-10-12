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
        /// 文件注释
        /// </summary>
        public string Summary { get; set; }

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
        /// AddScss
        /// </summary>
        public static CodeScssFile AddScss(this CodeScssFile codeFile, CodeScss codeScss)
        {
            if (codeFile.CodeScssList == null)
            {
                codeFile.CodeScssList = new List<CodeScss>();
            }

            codeFile.CodeScssList.Add(codeScss);

            return codeFile;
        }

        /// <summary>
        /// AddScss
        /// </summary>
        public static CodeScss AddScss(this CodeScssFile codeFile, string name = null, string summary = null)
        {
            if (codeFile.CodeScssList == null)
            {
                codeFile.CodeScssList = new List<CodeScss>();
            }

            CodeScss codeScss = new CodeScss();
            codeScss.Name = name;
            codeScss.Summary = summary;

            codeFile.CodeScssList.Add(codeScss);

            return codeScss;
        }
    }
}
