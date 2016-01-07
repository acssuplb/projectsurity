using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interpret.ClassesAndInterfaces
{
	/// <summary>
	/// Submodule.
	/// </summary>
    interface Submodule
    {
		/// <summary>
		/// Check the specified line in the code.
		/// </summary>
		/// <param name="line">Line.</param>
        bool Check(string line);
		/// <summary>
		/// Analyze the specified line and returns a list of lexemes.
		/// </summary>
		/// <param name="line">Line.</param>
        List<Lexeme> Analyze(string line); //does lexical analyzer on string
		/// <summary>
		/// Run the specified list of lexemes.
		/// </summary>
		/// <param name="lex">Lexemes.</param>
        void Run(List<Lexeme> lex);
    }
}
