/* GROUP NAME: Bajalalero
 * DATE PASSED: 
 * DESCRIPTION: Scanning Variables, Expressions, and Literals
 * CHANGELOG: 
 *
 * 12-08-2015 Gio created the class
 * 
 * 12-09-2015 Error Checking + Editing Analyze method done by Aron  the "Kekmaster"
 * 
 */


using Interpret.ClassesAndInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Interpret.Vardec;

namespace Interpret.InputAndOutput{
	class ScanModule : Submodule{
		//Attributes
		private String[] scanKeyword;
		private String scanRegexString;
		private Regex scanRegex;
		private Match Matcher;
		public ScanModule (){
			scanKeyword = new String[]{"HINGI", "NG"};
			scanRegexString = @"^\s*" + "(" + scanKeyword[0] + @")\s+(" + "(" + scanKeyword[1] +@")\s+)?(" +Constant.IDENTIFIER.ToString() + @")\s*$";
			scanRegex = new Regex (scanRegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		public bool Check(string line){
            Matcher = scanRegex.Match(line);
            return Matcher.Success;
		}
		
		public List<Lexeme> Analyze(string line){
			string input = "";
		
			List<Lexeme> lexemeList = new List<Lexeme> ();
            lexemeList.Add(new Lexeme(Matcher.Groups[1].Value.ToUpper(), "Scan Keyword"));
            lexemeList.Add(new Lexeme(Matcher.Groups[3].Value.Trim().ToUpper(), "Scan Noise Word"));
            if (Program.Symbol.ContainsKey(Matcher.Groups[4].Value)){
				input = Console.ReadLine ();
				string type = Program.Symbol [Matcher.Groups [4].Value].Type;
				string inputType = checkDataType (input);
				Console.WriteLine (inputType);
				if (type == inputType) {
					if (type == "BILANG" || type == "NUMERO") {
						double x = Convert.ToInt32 (input);
                        Program.Symbol[Matcher.Groups[4].Value] = new ValueClass(x.ToString(), type);
					} 
                    else if (type == "SIMBOLO") {
						Console.WriteLine (input);
                        Program.Symbol[Matcher.Groups[4].Value] = new ValueClass(input.ToString(), type);
					} 
                    else if (type == "SAGOT") {
                        Program.Symbol[Matcher.Groups[4].Value] = new ValueClass(input, type);
					} 
                    else {
                        Program.Symbol[Matcher.Groups[4].Value] = new ValueClass(input, type);
					}	
				}
                else if(inputType == FloatDeclaration.DATA_TYPE && type == IntDeclaration.DATA_TYPE){
                    //int to float
                }
                else {
					throw new SyntaxException ("Hindi " + type + " yung " + input);
				}	
			} else {
                throw new SyntaxException(ErrorMessage.VARIABLE_NOT_DECLARED + Matcher.Groups[4].Value);
			}

			return lexemeList;
		}
		private string checkDataType(string input){
			
			if (Regex.IsMatch (input, IntDeclaration.INT_VALUE.ToString())) {
				return "BILANG";
			} else if (Regex.IsMatch (input, FloatDeclaration.FLOAT_VALUE.ToString())) {
				return "NUMERO";
			} else if (Regex.IsMatch (input, "^" + CharDeclaration.CHAR_VALUE.ToString()+ "$")) {
				return "SIMBOLO";
			} else if (Regex.IsMatch (input, BoolDeclaration.BOOL_VALUE.ToString())) {
				return "SAGOT";
			} else{
				return "SALITA";
			}
		}	
		public void Run(List<Lexeme> lex){
			foreach (Lexeme l in lex) {
				Console.WriteLine (l.Name+" : "+l.Description);
			}		
		}

	}

}
