/* GROUP NAME: TEAM CONSTANT
 * DATE PASSED: 12-04-2015
 * DESCRIPTION: Integer Declaration
 * CHANGELOG:
 *      12-04-2015 10:15 to 13:25: Adona made the class and implemented check, analyze, and run
 *      12-09-2015 1:45 to 2:15: Julius modified regex, Check, and Analyze
 *      12-11-2015 4:20 to 5:27: Julius modified regex so that it can take variables for initialization and to support implicit typecasting
 *      12-11-2015 6:00 to 6:28: Julius modified the range of values
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
	class IntDeclaration : Submodule{
        public static Regex INT_VALUE = new Regex("-?\\d+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static int MAX_VALUE = 2147483647;
        public static int MIN_VALUE = -2147483647;
        public const string DATA_TYPE = "BILANG";
		private Regex IntRegex;
		private string DefaultValue;
        private Match Matcher;

		public IntDeclaration(){
            IntRegex = new Regex("^\\s*(" + DATA_TYPE + ")\\s+(" + Constant.IDENTIFIER + ")\\s*(\\s+(" + Constant.INIT + ")\\s+(" + FloatDeclaration.FLOAT_VALUE.ToString() + "))?\\s*(" + CommentModule.ONE_LINE_REGEX +")?\\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            DefaultValue = "0";
		}

		public bool Check(string line){
            Matcher = IntRegex.Match (line);
            return Matcher.Success;
		}

		public List<Lexeme> Analyze (string line){
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
                    if (!name.Contains(".")){
                        string value = int.Parse(name).ToString();
                        lex.Add(new Lexeme(value, DATA_TYPE + LexemeDescription.CONSTANT));
                    }
                    else if (FloatDeclaration.FLOAT_VALUE.IsMatch(name)){
                        Console.WriteLine(WarningMessage.FLOAT2INT);
                        string value = Math.Floor(float.Parse(name)).ToString();
                        lex.Add(new Lexeme(value, DATA_TYPE + LexemeDescription.CONSTANT));
                    }
                    else
                        lex.Add(new Lexeme(name, LexemeDescription.VARIABLE_IDENTIFIER));
                    break;
                }
            }
			return  lex;
		}

		public void Run(List<Lexeme> lex){
            if (Program.Symbol.ContainsKey(lex[1].Name))
                throw new SyntaxException(ErrorMessage.VARIABLE_DECLARED + lex[1].Name);
            else if (lex.Count < 3)
                Program.Symbol.Add(lex[1].Name, new ValueClass(DefaultValue, lex[0].Name));
            else if (lex[2].Name == Constant.INIT_KEYWORD)
            {
                if (lex[3].Description == DATA_TYPE + LexemeDescription.CONSTANT){
                    if (int.Parse(lex[3].Name) > MAX_VALUE)
                        throw new SyntaxException(ErrorMessage.BIGGER_THAN_MAX);
                    else if (int.Parse(lex[3].Name) < MIN_VALUE)
                        throw new SyntaxException(ErrorMessage.SMALLER_THAN_MIN);
                    Program.Symbol.Add(lex[1].Name, new ValueClass(lex[3].Name, lex[0].Name));
                }
                else
                {
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
