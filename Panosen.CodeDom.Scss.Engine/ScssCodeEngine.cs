using Panosen.CodeDom.Css.Engine;
using System;
using System.Collections.Generic;

namespace Panosen.CodeDom.Scss.Engine
{
    /// <summary>
    /// css 代码引擎
    /// </summary>
    public class ScssCodeEngine
    {
        /// <summary>
        /// 生成css文件
        /// </summary>
        public void Generate(CodeScssFile codeFile, CodeWriter codeWriter, GenerationOptions options = null)
        {
            if (codeFile == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerationOptions();

            if (!string.IsNullOrEmpty(codeFile.Summary))
            {
                codeWriter.Write(options.IndentString)
                    .Write(Marks.SLASH).Write(Marks.STAR).WriteLine(Marks.Exclamation)
                    .Write(Marks.WHITESPACE).Write(Marks.STAR).Write(Marks.WHITESPACE).WriteLine(codeFile.Summary)
                    .Write(Marks.WHITESPACE).Write(Marks.STAR).WriteLine(Marks.SLASH);
                codeWriter.WriteLine();
            }

            if (codeFile.Variables != null && codeFile.Variables.Count > 0)
            {
                Generate(codeFile.Variables, codeWriter, options);
                codeWriter.WriteLine();
            }

            Generate(codeFile.CodeScssList, codeWriter, options);
        }

        /// <summary>
        /// 生成变量
        /// </summary>
        public void Generate(Dictionary<string, string> variables, CodeWriter codeWriter, GenerationOptions options = null)
        {
            if (variables == null || variables.Count == 0)
            {
                return;
            }

            foreach (var item in variables)
            {
                codeWriter.Write(item.Key).Write(Marks.COLON).Write(Marks.WHITESPACE).Write(item.Value).WriteLine(Marks.SEMICOLON);
            }
        }

        /// <summary>
        /// 生成 css 列表
        /// </summary>
        public void Generate(List<CodeScss> codeCssList, CodeWriter codeWriter, GenerationOptions options = null)
        {
            if (codeCssList == null || codeCssList.Count == 0)
            {
                return;
            }

            var enumerator = codeCssList.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                var codeCss = enumerator.Current;
                Generate(codeCss, codeWriter, options);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.WriteLine();
                }
            }
        }

        /// <summary>
        /// 生成scss
        /// </summary>
        public void Generate(CodeScss codeScss, CodeWriter codeWriter, GenerationOptions options = null)
        {
            if (codeScss == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerationOptions();

            if (!string.IsNullOrEmpty(codeScss.Summary))
            {
                codeWriter.Write(options.IndentString)
                    .Write(Marks.SLASH).Write(Marks.STAR).Write(Marks.WHITESPACE)
                    .Write(codeScss.Summary)
                    .Write(Marks.WHITESPACE).Write(Marks.STAR).WriteLine(Marks.SLASH);
            }
            codeWriter.Write(options.IndentString).Write(codeScss.Name).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            CssCodeEngine.GenerateCssProperty(codeScss, codeWriter, new Css.Engine.GenerationOptions
            {
                IndentSize = options.IndentSize
            });

            if (codeScss.Children != null && codeScss.Children.Count > 0)
            {
                codeWriter.WriteLine();

                Generate(codeScss.Children, codeWriter, new GenerationOptions
                {
                    IndentSize = options.IndentSize
                });
            }

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
