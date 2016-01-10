/* GROUP NAME: Team Aron
 * DATE PASSED:
 * DESCRIPTION: Declaring array of strings/numbers/troof values/characters.
 * CHANGELOG:
 *      12-07-2015 02:35PM Miles created the class
 *      12-07-2015 09:11PM Julius refactored the code
 *      12-08-2015 04:40PM PJ fixed the regex
 *      12-10-2015 10:10AM PJ fixed the regex and implemented Analyze for BILANG, SIMBOLO and SAGOT array
 *      12-11-2015 12:00NN Aron has done: minor tweaks on regex, added NUMERO array regex, remodeled  module for readability, module can now accept strings and characters
 * 	    12-13-2015 11:00PM Aron made module conform to the new format.
 * 	    12-17-2015 06:00PM Aron added functionalities of Run function
 * 	    12-18-2015 10:45PM Miles added: now checks if values are their respective types in the run() method; Fixed group name and changelog
 * 
 * TO BE FIXED AND YUNG MGA KULANG PA:
 *      >Pwede dapat ang bilang sa numero array and vice versa (fix muna yung regex, di nakaka tanggap ng numero yung bilang and vice versa)
 *      >Pwede dapat ang bilang sa simbolo array (convert to ASCII) and vice versa (fix muna yung regex, same as above)
 *      >Napapagkamalang Variable yung characters and strings || IMPORTANT: Consult niyo muna ako kung balak niyong gawin to -Aron,2015 (now I think regex problem din to, havent checked again kung meron pa tong problema na to)
 *      >Apparently, case sensitive yung regex dito.
 *      >For more others na kulang pa, use Ctrl+f search niyo yung "may kulang pa"
 * 
 *      PS: Kung may mga tanong pa, PM niyo ako or si Julius sa fb. And remember na magdagdag sa changelog if you made any changes
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpret.ClassesAndInterfaces;
using System.Text.RegularExpressions;

namespace Interpret.Vardec{
    class ArrayDeclaration : Submodule{
        private string[] ArrayKeywords;
        private string[] ArrayElements;
        private string ArrayKeyword;
        private Match matches;
        private char[] splitter = { ',' };
		private string type = "";
		private string Arrayname = "";
        public static Regex SPACES = new Regex ("\\s+", RegexOptions.Compiled);
        public static Regex ARRAY_INT = new Regex("^\\s*(KOLEKSYON\\s+NG)\\s+"+"(" + IntDeclaration.DATA_TYPE+")\\s+("+Constant.IDENTIFIER.ToString()+")\\s*(\\s+("+Constant.INIT.ToString()+")\\s+((("+IntDeclaration.INT_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")$)|((("+IntDeclaration.INT_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")\\s*,\\s*)+\\s*("+IntDeclaration.INT_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")\\s*$)))?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ARRAY_CHAR = new Regex("^\\s*(KOLEKSYON\\s+NG)\\s+("+CharDeclaration.DATA_TYPE+")\\s+("+Constant.IDENTIFIER.ToString()+")(\\s+("+Constant.INIT.ToString()+")\\s+(((\'"+CharDeclaration.CHAR_VALUE.ToString()+"\'|"+Constant.IDENTIFIER.ToString()+")$)|(((\'"+CharDeclaration.CHAR_VALUE.ToString()+"\'|"+Constant.IDENTIFIER.ToString()+")\\s*,\\s*)+\\s*(\'"+CharDeclaration.CHAR_VALUE.ToString()+"\'|"+Constant.IDENTIFIER.ToString()+")\\s*$)))?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ARRAY_STRING = new Regex("^\\s*(KOLEKSYON\\s+NG)\\s+("+StringDeclaration.DATA_TYPE+")\\s+("+Constant.IDENTIFIER.ToString()+")(\\s+("+Constant.INIT.ToString()+")\\s+(((\""+Constant.IDENTIFIER.ToString()+"\"|"+Constant.IDENTIFIER.ToString()+")$)|(((\""+Constant.IDENTIFIER.ToString()+"\"|"+Constant.IDENTIFIER.ToString()+")\\s*,\\s*)+\\s*(\""+Constant.IDENTIFIER.ToString()+"\"|"+Constant.IDENTIFIER.ToString()+")\\s*$)))?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ARRAY_TROOF = new Regex("^\\s*(KOLEKSYON\\s+NG)\\s+("+BoolDeclaration.DATA_TYPE+")\\s+("+Constant.IDENTIFIER.ToString()+")(\\s+("+Constant.INIT.ToString()+")\\s+((("+BoolDeclaration.BOOL_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")$)|((("+BoolDeclaration.BOOL_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")\\s*,\\s*)+\\s*("+BoolDeclaration.BOOL_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")\\s*$)))?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ARRAY_FLOAT = new Regex("^\\s*(KOLEKSYON\\s+NG)\\s+("+FloatDeclaration.DATA_TYPE+")\\s+("+Constant.IDENTIFIER.ToString()+")\\s*(\\s+("+Constant.INIT.ToString()+")\\s+((("+FloatDeclaration.FLOAT_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")$)|((("+FloatDeclaration.FLOAT_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")\\s*,\\s*)+\\s*("+FloatDeclaration.FLOAT_VALUE.ToString()+"|"+Constant.IDENTIFIER.ToString()+")\\s*$)))?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public ArrayDeclaration(){
            ArrayKeywords = new string[]{"KOLEKSYON", "NG"};
            ArrayKeyword = ArrayKeywords [0] + " " + ArrayKeywords [1];
        }

        public bool Check(string line){ 
            
            if (Regex.IsMatch (line, ARRAY_INT.ToString())) {
                
                matches = ARRAY_INT.Match (line);
                return matches.Success;

            } else if (Regex.IsMatch (line, ARRAY_CHAR.ToString())) {
                
                matches = ARRAY_CHAR.Match (line);
                return matches.Success;

            } else if (Regex.IsMatch (line, ARRAY_STRING.ToString())) {
                
                matches = ARRAY_STRING.Match (line);
                return matches.Success;

            } else if (Regex.IsMatch (line, ARRAY_TROOF.ToString())) {
                matches = ARRAY_TROOF.Match (line);
                return matches.Success;

            } else if (Regex.IsMatch (line, ARRAY_FLOAT.ToString())) {
                matches = ARRAY_FLOAT.Match (line);
                return matches.Success;
            } 
            return false;
        }

        public List<Lexeme> Analyze(string line){
            /* FORMAT: <something> -> <contains this>;
            * please take note of the following:
            * matches.Groups[0].Value -> line
            * matches.Groups[1].Value -> KOLEKSYON NG
            * matches.Groups[2].Value -> data type
            * matches.Groups[3].Value -> array identifier
            * matches.Groups[5].Value -> NA MAY
            * matches.Groups[6].Value - > array elements
            */
		
            List<Lexeme> lexemeList = new List<Lexeme> ();

            lexemeList.Add(new Lexeme(ArrayKeyword,"Array Declaration"));

			type = matches.Groups [2].Value;

			if (type.Equals (IntDeclaration.DATA_TYPE)) {
				lexemeList.Add (new Lexeme (type, "Integer Array"));
			} else if (type.Equals (FloatDeclaration.DATA_TYPE)) {
				lexemeList.Add (new Lexeme (type, "Float Array"));
			} else if (type.Equals (CharDeclaration.DATA_TYPE)) {
				lexemeList.Add (new Lexeme (type, "Character Array"));
			} else if (type.Equals (StringDeclaration.DATA_TYPE)) {
				lexemeList.Add (new Lexeme (type, "String Array"));
			} else if (type.Equals (BoolDeclaration.DATA_TYPE)) {
				lexemeList.Add (new Lexeme (type, "Boolean Array"));
			}

			if (Program.Symbol.ContainsKey (matches.Groups [3].Value) || Program.SymbolArray.ContainsKey (matches.Groups [3].Value)) {
				throw new SyntaxException (ErrorMessage.VARIABLE_DECLARED + matches.Groups [3].Value);
			} else {
				lexemeList.Add (new Lexeme (matches.Groups[3].Value, "Variable Identifier"));
				Arrayname = matches.Groups [3].Value;
			}

            if(matches.Groups[5].Value != ""){
                lexemeList.Add (new Lexeme (matches.Groups [5].Value, "Variable Initialization")); 
            }

            ArrayElements = matches.Groups [6].Value.Split (splitter);

            foreach (string value in ArrayElements) {
                if (Regex.IsMatch (value.Trim (), Constant.IDENTIFIER.ToString())) {
                    if (Program.Symbol.ContainsKey (value.Trim ())) {
                        lexemeList.Add (new Lexeme (value.Trim(),"Variable Identifier"));

                    } else if(matches.Groups [2].Value == CharDeclaration.DATA_TYPE){
                        //may kulang dito ->(eto yung taas) kailangan tanggalin yung single quotes bago ilagay sa mga lists (aka: lexemeList)
                        lexemeList.Add (new Lexeme (value.Trim (), "Character Constant"));

                    }else if(matches.Groups [2].Value == StringDeclaration.DATA_TYPE){
                        //may kulang dito -> kailangan tanggalin yung double quotes bago ilagay sa mga lists, same case sa taas
                        lexemeList.Add (new Lexeme (value.Trim (), "String Constant"));
                    }
                } else {
                    if (matches.Groups [2].Value == FloatDeclaration.DATA_TYPE) {
                        lexemeList.Add (new Lexeme (value.Trim (), "Float Constant"));

                    } else if (matches.Groups [2].Value == IntDeclaration.DATA_TYPE) {
                        lexemeList.Add (new Lexeme (value.Trim (), "Integer Constant"));

                    } else if (matches.Groups [2].Value == CharDeclaration.DATA_TYPE) {
                        //may kulang pa dito -> refer dun sa taas
                        lexemeList.Add (new Lexeme (value.Trim (), "Character Constant"));

                    } else if (matches.Groups [2].Value == BoolDeclaration.DATA_TYPE) {
                        lexemeList.Add (new Lexeme (value.Trim (), "Boolean Constant"));

                    } else if (matches.Groups [2].Value == StringDeclaration.DATA_TYPE) {
                        //may kulang pa dito -> refer dun sa taas
                        lexemeList.Add (new Lexeme (value.Trim (), "String Constant"));
                    } 
                }

            }
				
            return lexemeList;

        }

        public void Run(List<Lexeme> lexemeList){
            //what it should do: ilagay sa dictionary yung array.
			List<ValueClass> Elements = new List<ValueClass>();
			int i = 0;
			Console.WriteLine (lexemeList.Count);
			if (lexemeList.Count == 4) {
					Program.SymbolArray.Add (Arrayname, Elements);
			} else {
				for (i = 5; i < lexemeList.Count; i++) {
					if (type.Equals (IntDeclaration.DATA_TYPE)) {
						if (Regex.IsMatch (lexemeList [i].Name, Constant.IDENTIFIER.ToString ())) {
                            if (Regex.IsMatch (Program.Symbol[lexemeList[i].Name], IntDeclaration.INT_VALUE.ToString())){
							    Elements.Add (Program.Symbol[lexemeList[i].Name]);
                            }
						} else if (Regex.IsMatch (lexemeList [i].Name, FloatDeclaration.FLOAT_VALUE.ToString())) {
							//Truncation
						} else {
							Elements.Add (new ValueClass(lexemeList[i].Name,IntDeclaration.DATA_TYPE));
						}
					} else if (type.Equals (FloatDeclaration.DATA_TYPE)) {
						if (Regex.IsMatch (lexemeList [i].Name, Constant.IDENTIFIER.ToString ())) {
                            if (Regex.IsMatch (Program.Symbol[lexemeList[i].Name], FloatDeclaration.FLOAT_VALUE.ToString())){
                                Elements.Add(Program.Symbol[lexemeList[i].Name]);
                            }
						} else if (Regex.IsMatch (lexemeList [i].Name, IntDeclaration.INT_VALUE.ToString())) {
							//Floatify
						} else {
							Elements.Add (new ValueClass(lexemeList[i].Name,FloatDeclaration.DATA_TYPE));
						}
					} else if (type.Equals (CharDeclaration.DATA_TYPE)) {
						if (Regex.IsMatch (lexemeList [i].Name, Constant.IDENTIFIER.ToString ())) {
                            if (Regex.IsMatch (Program.Symbol[lexemeList[i].Name], CharDeclaration.CHAR_VALUE.ToString())){
                                Elements.Add(Program.Symbol[lexemeList[i].Name]);
                            }
						} else{
							Elements.Add (new ValueClass(lexemeList[i].Name,CharDeclaration.DATA_TYPE));
						}
					} else if (type.Equals (StringDeclaration.DATA_TYPE)) {
						if (Regex.IsMatch (lexemeList [i].Name, Constant.IDENTIFIER.ToString ())) {
                            if (Regex.IsMatch (Program.Symbol[lexemeList[i].Name], Constant.IDENTIFIER.ToString())){
							    Elements.Add (Program.Symbol [lexemeList [i].Name]);
                            }
						} else{
							Elements.Add (new ValueClass(lexemeList[i].Name,StringDeclaration.DATA_TYPE));
						} 
					} else if (type.Equals (BoolDeclaration.DATA_TYPE)) {
						if (Regex.IsMatch (lexemeList [i].Name, Constant.IDENTIFIER.ToString ())) {
                            if (Regex.IsMatch (Program.Symbol[lexemeList[i].Name], BoolDeclaration.BOOL_VALUE.ToString())){
							    Elements.Add (Program.Symbol [lexemeList [i].Name]);
                            }
						} else{
							Elements.Add (new ValueClass(lexemeList[i].Name,BoolDeclaration.DATA_TYPE));
						} 
					} else {
						throw new SyntaxException ("Invalid Data type");
					}
				
				}
				Program.SymbolArray.Add (Arrayname, Elements);
			}
				
		}
    }
}
