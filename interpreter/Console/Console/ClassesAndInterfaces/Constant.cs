//PARA PO ITO SA MGA REGEX AND KEYWORDS NA GAGAMITIN SA IBANG SUBMODULES

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*
Change Log:
	fxn(g), 2015 Nov 10
	static Regex SIMBOLOVAL, created regex
	static Regex SALITAVAL, created regex
	static Regex SAGOTVAL, created regex
	static Regex NA_MAY, created regex
	static Regex IDENTIFIER, created regex
	static Regex SIMBOLO, created regex
	static Regex SALITA, created regex
	static Regex SAGOT, created regex
    Julius, 2015 Nov 11
    created regex from NUMERO and BILANG
 */


namespace Interpret.ClassesAndInterfaces{
	class Constant{
		/// <summary>
		/// Escape character
		/// </summary>
        public static Regex ESC_CHAR = new Regex("\\\\.+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		/// <summary>
		/// Character for printing new line
		/// </summary>
        public static Regex NEW_LINE = new Regex("\\\\(linya)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// The regex for initializing a variable when it is declared.
        /// </summary>
        public static Regex INIT = new Regex("\\s*NA\\s+MAY\\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        //Identifiers
        /// <summary>
        /// Regex for variable name and function name
        /// </summary>
        public static Regex IDENTIFIER = new Regex("[A-Za-z_][A-Za-z0-9_-]*", RegexOptions.Compiled);

		/// <summary>
		/// The keyword for initializing a variable when it is declared.
		/// </summary>
		public const string INIT_KEYWORD = "NA MAY";
      
        /// <summary>
        /// Value for an empty string
        /// </summary>
        public const string EMPTY_STRING = "";  
    }
}
