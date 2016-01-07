/* GROUP NAME: TEAM CONSTANT
 * DATE PASSED: 12-04-2015
 * DESCRIPTION: Integer Declaration
 * CHANGELOG:
 *      12-04-2015 10:15 to 13:25: Adona made the class and implemented check, analyze, and run
 *      12-09-2015 1:45 to 2:15: Julius modified regex, Check, and Analyze
 *      12-11-2015 4:20 to 4:40: Julius modified regex so that it can take variables for initialization
 *      12-11-2015 4:20 to 5:27: Julius modified regex so that it can take variables for initialization and to support implicit typecasting
 *      12-11-2015 6:00 to 6:28: Julius modified the range of values
 *      12-11-2015 6:28 to 6:30: Julius modified Run to append 4 decimal places in value
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
	class FloatDeclaration : Submodule{
        public static Regex FLOAT_VALUE = new Regex("-?\\d+|-?\\d*\\.\\d+", RegexOptions.Compiled);
        public const string DATA_TYPE = "NUMERO";
		private Regex FloatRegex;
		private string DefaultValue;
        private Match Matcher;

		public FloatDeclaration(){
            FloatRegex = new Regex("\\s*(" + DATA_TYPE + ")\\s+(" + Constant.IDENTIFIER.ToString() + ")\\s*(\\s+(" + Constant.INIT.ToString() + ")\\s+(" + FLOAT_VALUE.ToString() + "|" + Constant.IDENTIFIER + "))?\\s*("
                + CommentModule.ONE_LINE_REGEX +")?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            DefaultValue = "0";
		}

		public bool Check(string line){
            Matcher = FloatRegex.Match (line);
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
                    if (FLOAT_VALUE.IsMatch(name))
                        lex.Add(new Lexeme(name, DATA_TYPE + LexemeDescription.CONSTANT));
                    else
                        lex.Add(new Lexeme(name, LexemeDescription.VARIABLE_IDENTIFIER));
                    break;
                }
            }
			return lex;
		}

		public void Run (List<Lexeme> lex){
            if (Program.Symbol.ContainsKey(lex[1].Name))
                throw new SyntaxException(ErrorMessage.VARIABLE_DECLARED + lex[1].Name);
            else if (lex.Count < 3)
                Program.Symbol.Add(lex[1].Name, new ValueClass(DefaultValue, lex[0].Name));
            else if (lex[2].Name == Constant.INIT_KEYWORD)
            {
                if (lex[3].Description == DATA_TYPE + LexemeDescription.CONSTANT){
                    if (float.Parse(lex[3].Name) > IntDeclaration.MAX_VALUE)
                        throw new SyntaxException(ErrorMessage.BIGGER_THAN_MAX);
                    else if (float.Parse(lex[3].Name) < IntDeclaration.MIN_VALUE)
                        throw new SyntaxException(ErrorMessage.SMALLER_THAN_MIN);
                    string value = Math.Round(float.Parse(lex[3].Name), 4).ToString("F4");
                    Program.Symbol.Add(lex[1].Name, new ValueClass(value, lex[0].Name));
                }
                else{
                    if (!Program.Symbol.ContainsKey(lex[3].Name))
                        throw new SyntaxException(ErrorMessage.VARIABLE_DECLARED + lex[3].Name);
                    else if (Program.Symbol[lex[3].Name].Type == DATA_TYPE)
                        Program.Symbol.Add(lex[1].Name, Program.Symbol[lex[3].Name]);
                    else
                        throw new SyntaxException(lex[3].Name + ErrorMessage.CANNOT_CONVERT + DATA_TYPE);
                }
            }
            Console.WriteLine(lex[1].Name + " has now " + Program.Symbol[lex[1].Name].Value);
		}
	}
}
