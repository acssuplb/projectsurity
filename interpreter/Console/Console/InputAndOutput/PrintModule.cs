/* GROUP NAME: Bajalalero
 * DATE PASSED: 
 * DESCRIPTION: Printing Variables, Expressions, and Literals
 * CHANGELOG: 
 *
 * 12-05-2015 Maru Created the class
 * DEC 8 2:30
 * 
 * 12-09-2015  Error checking was done by Aron "Kekmaster" 
 * DEC 9 1:45
 * 
 * ERRORS FOUND:
 * -> Bawal yung >>"ISULAT  <insert command/function here>" eg. >>ISULAT ANG "ISULAT ANG 12" 
 */

using Interpret.ClassesAndInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Interpret.Vardec;


namespace Interpret.InputAndOutput
{
	class PrintModule : Submodule
	{	
		/*Attributes*/
		private String[] printKeyword;
		private String printRegexString;
		private Regex printRegex;

		/*Constructor Method*/
		public PrintModule ()
		{
			printKeyword = new String[]{"ISULAT", "ANG"};
			printRegexString = "^\\s*"+printKeyword[0]+"\\s+("+printKeyword[1]+"\\s+)?( .*,\\s+)*.*[^,]$";
			printRegex = new Regex (printRegexString);
		}

		/*Interface Methods*/
		public bool Check(string line){
			return printRegex.Match(line).Success;
		}

		public List<Lexeme> Analyze(string line){
			List<Lexeme> lexemeList = new List<Lexeme>();
			string token = "";
			Boolean printOpsReady = false;
			Boolean printOpsComplete = false;
			line += " ";
			foreach (char c in line) {
				if (c == ' ' || c == ',') {
					if (token == printKeyword [0] || token == printKeyword [1]) {
						if (!printOpsReady && token == printKeyword [0]) {
							lexemeList.Add (new Lexeme (token, "Print Keyword"));
							printOpsReady = true;	
						} 
						else if (printOpsReady) {
							lexemeList.Add (new Lexeme (token, "Print Noise Keyword"));
							printOpsComplete = true;
						} 
						else if(printOpsComplete){
							Console.WriteLine ("Error: Unexpected Symbol " + token);
						}
						token = "";
						continue;
					} 
					else{
						string type = "";
						if (Regex.Match (token, "^" + IntDeclaration.INT_VALUE.ToString() + "$").Success) {
							type = "BILANG Constant";
						} 
						else if (Regex.Match (token, "^" + FloatDeclaration.FLOAT_VALUE.ToString() + "$").Success) {
							type = "NUMERO Constant";
						} 
						else if (Regex.Match (token, "^\'" + CharDeclaration.CHAR_VALUE.ToString() + "\'$").Success) {
							type = "SIMBOLO Constant";
						} 
						else if (Regex.Match (token, "^\"" + StringDeclaration.STRING_VALUE.ToString() + "\"$").Success) {
							type = "SALITA Constant";
						} 
						else if (Regex.Match (token, "^" + Constant.IDENTIFIER + "$").Success) {
							type = "Variable Identifier";
						} 
						else if( token != "" ){
							Console.WriteLine ("Error: Invalid \""+token+"\"");
						}
						if(type != "" )
							lexemeList.Add (new Lexeme (token, type));
						token = "";
					}
				} 
				else {
					token += c;
				}
			}
			return lexemeList;
		}

		public void Run(List<Lexeme> lex){
			for(int i = 0; i<lex.Count; i++ ){
				if (lex [i].Description.EndsWith ("Keyword")) {
					Console.WriteLine ("KEYWORD");
					continue;
				}
				if (lex [i].Description.EndsWith ("Constant")) {
					Console.Write (lex [i].Name);
				} 
				else if (lex [i].Description == "Variable Identifier") {
					try {
						Console.Write (Program.Symbol [lex [i].Name].Value);
					} catch (Exception ex) {
						Console.WriteLine ("Error: " + ex.Message);
					}
				} 
			}
			Console.WriteLine ("");
		}
	}
}

