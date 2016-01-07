using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpret.ClassesAndInterfaces{
	/// <summary>
	/// Lexeme.
	/// </summary>
    class Lexeme {
        private String _name;
        private String _desc;

		/// <summary>
		/// Represent the token of the lexeme
		/// </summary>
		/// <value>Gets the name of lexeme</value>
		public String Name {
            get { return _name; }
        }
		/// <summary>
		/// Represents the description of lexeme
		/// </summary>
		/// <value>Gets the Description of lexeme</value>
        public String Description {
            get { return _desc; }
        }
		/// <summary>
		/// Initializes a new instance of the <see cref="Interpret.ClassesAndInterfaces.Lexeme"/> class.
		/// </summary>
		/// <param name="n">Name.</param>
		/// <param name="d">Description.</param>
        public Lexeme(String n, String d){
            this._name = n;
			this._desc = d;
        }

        public override string ToString (){
            return string.Format ("Name={0}, Description={1}", Name, Description);
        }
    }
}
