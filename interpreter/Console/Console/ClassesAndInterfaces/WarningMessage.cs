using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpret.Vardec;

namespace Interpret.ClassesAndInterfaces{
    class WarningMessage{
        private const string _warning = "Warning: ";
        public const string INT2CHAR = _warning + "Naglalay ka ng halagang " + IntDeclaration.DATA_TYPE + " sa " + CharDeclaration.DATA_TYPE;
        public const string CHAR2INT = _warning + "Naglalay ka ng halagang " + CharDeclaration.DATA_TYPE + " sa " + IntDeclaration.DATA_TYPE;
        public const string FLOAT2INT = _warning + "Naglalay ka ng halagang " + FloatDeclaration.DATA_TYPE + " sa " + IntDeclaration.DATA_TYPE;
    }
}
