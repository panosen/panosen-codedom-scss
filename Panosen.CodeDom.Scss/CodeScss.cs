using Panosen.CodeDom.Css;
using System;
using System.Collections.Generic;

namespace Panosen.CodeDom.Scss
{
    /// <summary>
    /// scss 样式
    /// </summary>
    public class CodeScss : CodeCss
    {
        /// <summary>
        /// 子 scss 样式
        /// </summary>
        public List<CodeScss> Children { get; set; }
    }

    /// <summary>
    /// 扩展
    /// </summary>
    public static class CodeScssExtension
    {
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="codeScss"></param>
        /// <param name="scss"></param>
        public static void AddChild(this CodeScss codeScss, CodeScss scss)
        {
            if (codeScss.Children == null)
            {
                codeScss.Children = new List<CodeScss>();
            }

            codeScss.Children.Add(scss);
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        public static CodeScss AddChild(this CodeScss codeScss, string name, string summary = null)
        {
            if (codeScss.Children == null)
            {
                codeScss.Children = new List<CodeScss>();
            }

            CodeScss scss = new CodeScss();
            scss.Name = name;
            scss.Summary = summary;

            codeScss.Children.Add(scss);

            return scss;
        }
    }
}
