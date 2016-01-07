using Interpret.ClassesAndInterfaces;
using Interpret.Vardec;
using Interpret.Comments;
using Interpret.InputAndOutput;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Interpret{
    class Program{
		public static Dictionary<String, ValueClass> Symbol = new Dictionary<String, ValueClass>();

        static void Main (string[] args){
            Dictionary<String, Submodule> submodule = new Dictionary<String, Submodule> () {
                { "decBool", new BoolDeclaration () },
                { "decInt", new IntDeclaration () },
                { "decFloat", new FloatDeclaration () },
                { "decString", new StringDeclaration () },
                { "decChar", new CharDeclaration () },
                { "comment", new CommentModule () },
                { "scan", new ScanModule() }
            };

            Console.WriteLine("ADOBOCODE v1.0 Console Interpreter");
            Console.WriteLine("Type a command in ADOBOCODE. You can quit anytime by entering \"quit\"\n");

            while (true) {
                Console.Write (">> ");
                string line = Console.ReadLine ();
                const string exit = "quit";
                const string clear = "clear";

                try {
                    if (line.Equals (exit))
                        break;
                    else if (line.Equals (clear)) {
                        Symbol.Clear ();
                        Console.Clear ();
                        Console.WriteLine ("\nRemoved all stored variables.");
                    } else if (submodule ["decInt"].Check (line))
                        submodule ["decInt"].Run (submodule ["decInt"].Analyze (line));
                    else if (submodule ["decFloat"].Check (line))
                        submodule ["decFloat"].Run (submodule ["decFloat"].Analyze (line));
                    else if (submodule ["decBool"].Check (line))
                        submodule ["decBool"].Run (submodule ["decBool"].Analyze (line));
                    else if (submodule ["decString"].Check (line))
                        submodule ["decString"].Run (submodule ["decString"].Analyze (line));
                    else if (submodule ["decChar"].Check (line))
                        submodule ["decChar"].Run (submodule ["decChar"].Analyze (line));
                    else if (submodule["scan"].Check(line))
                        submodule["scan"].Run(submodule["scan"].Analyze(line));
                    else if (submodule ["comment"].Check (line))
                        Console.WriteLine ("Comment found!");
                    else
                        Console.WriteLine ("Did not match any regex available.");
                } 
                catch (SyntaxException e) {
                    Console.WriteLine ("RUNTIME ERROR: " + e.Message);
                } 
                catch (Exception e) {
                    Console.WriteLine("CRASHED: " + e.Message + "\n" + e.StackTrace);
                }
            }
        }
    }
}
