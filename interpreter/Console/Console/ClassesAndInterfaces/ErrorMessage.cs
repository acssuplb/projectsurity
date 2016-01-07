using System;

namespace Interpret
{
    public class ErrorMessage
    {
        //NOTE: Temporary palang ang mga nandito
        public const string VARIABLE_DECLARED = "Nadeklara na itong variable: ";
        public const string VARIABLE_NOT_DECLARED = "Hindi pa nadedeklara itong varaible: ";
        public const string UNEXPECTED_LEXEME = "Hindi ko inaasahang makita ito: ";
        public const string VARDEC_UNEXPECTED_ERROR = "May hindi nakakatuwang nangyari sa pagdeklara ng variable";
        public const string INVALID_VALUE = " ay hindi tinatanggap bilang isang ";
        public const string CANNOT_CONVERT = " ay hindi maconvert bilang isang ";
        public const string BIGGER_THAN_MAX = "Naglalagay ka ng halagang mas malaki pa sa kayang hawakan ng isang variable!";
        public const string SMALLER_THAN_MIN = "Naglalagay ka ng halagang mas maliit pa sa kayang hawakan ng isang variable!";
    }
}

