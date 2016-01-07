using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpret.ClassesAndInterfaces{
	/// <summary>
	/// ValueClass.
	/// </summary>
    class ValueClass{
        private string _value;
        private string _type;

		/// <summary>
		/// Holds the value.
		/// </summary>
		/// <value>Value.</value>
        public string Value {
            get { return _value; }
        }

		/// <summary>
		/// Datatype of the value.
		/// </summary>
		/// <value>Datatype.</value>
        public string Type {
            get { return _type; }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Interpret.ClassesAndInterfaces.ValueClass"/> class.
		/// </summary>
		/// <param name="v">Value.</param>
		/// <param name="t">Type.</param>
		public ValueClass(String v, String t){
			this._value = v;
			this._type = t;
        }

        public override string ToString (){
            return string.Format ("Value={0}, Type={1}", Value, Type);
        }
    }
}
