/* GROUP NAME: fxn(g)
 * DATE PASSED: 12-04-2015
 * DESCRIPTION: Declaring boolean
 * CHANGELOG:
 *      12-04-2015 10:15 to 13:25: Adona made the class and implemented check, analyze, and run
 *      12-09-2015 1:45 to 2:15: Julius modified regex, Check, and Analyze
 *      12-11-2015 4:20 to 5:27: Julius modified regex so that it can take variables for initialization and to support implicit typecasting
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Interpret.ClassesAndInterfaces;
using Interpret.Comments;

namespace Interpret.Vardec{
	class BoolDeclaration : Submodule{
        public static Regex BOOL_VALUE = new Regex("TAMA|MALI", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public const string DATA_TYPE = "SAGOT";
		private Regex BoolRegex;
		private string DefaultValue;
        private Match Matcher;

		public BoolDeclaration(){
            BoolRegex = new Regex("\\s*(" + DATA_TYPE + ")\\s+(" + Constant.IDENTIFIER.ToString() + ")\\s*(\\s+(" + Constant.INIT.ToString() + ")\\s+(" + BOOL_VALUE.ToString() + "|" + Constant.IDENTIFIER.ToString() +"))?(" 
                + CommentModule.ONE_LINE_REGEX +")?\\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            DefaultValue = "TAMA";
		}

		public bool Check(string line){
            Matcher = BoolRegex.Match (line);
            return Matcher.Success;
		}
		public List<Lexeme> Analyze(string line){
			List<Lexeme> lex = new List<Lexeme> ();
            for (int i = 0; i < Matcher.Groups.Count; i++) {
                if (Matcher.Groups [i].Value == "")
                    continue;
                string name = Matcher.Groups [i].Value;
                switch (i) {
                case 1:
                    lex.Add (new Lexeme (name.ToUpper(), DATA_TYPE + LexemeDescription.VARIABLE_DECLARATION));
                    break;
                case 2:
                    if (Constant.IDENTIFIER.IsMatch (name))
                        lex.Add (new Lexeme (name, LexemeDescription.VARIABLE_IDENTIFIER));
                    else
                        throw new SyntaxException (name + ErrorMessage.INVALID_VALUE + LexemeDescription.VARIABLE_IDENTIFIER);
                    break;
                case 4:
                    lex.Add (new Lexeme (Constant.INIT_KEYWORD, LexemeDescription.INIT));
                    break;
                case 5:
                    if (BOOL_VALUE.IsMatch (name))
                        lex.Add (new Lexeme (name.ToUpper (), DATA_TYPE + LexemeDescription.CONSTANT));
                    else
                        lex.Add(new Lexeme(name, LexemeDescription.VARIABLE_IDENTIFIER));
                    break;
                }
            }

			return lex;
		}

		public void Run(List<Lexeme> lex){
			if (Program.Symbol.ContainsKey (lex [1].Name))
				throw new SyntaxException (ErrorMessage.VARIABLE_DECLARED+lex [1].Name);
			else if (lex.Count < 3)
                Program.Symbol.Add (lex [1].Name, new ValueClass (DefaultValue, lex [0].Name));
            else if (lex[2].Name == Constant.INIT_KEYWORD){
                if (lex[3].Description == DATA_TYPE + LexemeDescription.CONSTANT)
                    Program.Symbol.Add(lex[1].Name, new ValueClass(lex[3].Name, lex[0].Name));
                else{
                    if (!Program.Symbol.ContainsKey(lex[3].Name))
                        throw new SyntaxException(ErrorMessage.VARIABLE_DECLARED + lex[3].Name);
                    else if(Program.Symbol[lex[3].Name].Type == DATA_TYPE)
                        Program.Symbol.Add(lex[1].Name, Program.Symbol[lex[3].Name]);
                    else
                        throw new SyntaxException(lex[3].Name + ErrorMessage.CANNOT_CONVERT + DATA_TYPE);
                }
            }
            else
                throw new Exception(ErrorMessage.VARDEC_UNEXPECTED_ERROR);

            Console.WriteLine(lex[1].Name + " has now " + Program.Symbol[lex[1].Name].Value);
		}
	}
}
