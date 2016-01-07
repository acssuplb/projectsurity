/* GROUP NAME: VEGABONDS
 * DATE PASSED: 11-10-2015
 * DESCRIPTION: Regex for comments
 * CHANGELOG:
 *
 * 11-09-2015 Miles made the class
 * 11-10-2015 Miles added private attributes and fixed check function (Single line Regex from aron)
 * 11-11-2015 Aron fixed the single and multi-line comment regex checking
 * 11-12-2015 Miles fixed the vegabonds.cs file to reflect changes made by Aron	
 * 
 */

using Interpret.ClassesAndInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Interpret.Comments {
    class CommentModule : Submodule {
        public const string BLOCK_COMMENT_KEYWORD = "MGA KOMENTO:";
        public const string END_COMMENT_KEYWORD = "DULO NG KOMENTO";
        public const string ONE_LINE_KEYWORD = "KOMENTO";
        public const string ONE_LINE_REGEX = "\\s*" + ONE_LINE_KEYWORD + "\\s*.*";

		private string[] BlockComKeyword;
        private string[] EndComKeyword;

        private Regex BlockComRegex;
        private Regex ComOneLine;

        public CommentModule(){
            BlockComKeyword = new string[]{"MGA", "KOMENTO", ":"};
            EndComKeyword = new string[]{"DULO", "NG", "KOMENTO"};
            ComOneLine = new Regex("^" + ONE_LINE_REGEX + "$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            BlockComRegex = new Regex("^\\s*"+ BlockComKeyword[0]+ "\\s+"+ BlockComKeyword[1] + "\\s*"+ BlockComKeyword[2] +
                "\\s*" + ".*" + "\\s*" + EndComKeyword[0]+"\\s+"+ EndComKeyword[1] +"\\s+"+ EndComKeyword[2] + "\\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public bool Check(string line) {
            return ComOneLine.IsMatch(line) || BlockComRegex.IsMatch(line);
        }

		public List<Lexeme> Analyze(string line) {
            return null;
        }

        public void Run(List<Lexeme> lex) {
			return;
        }
    }
}
