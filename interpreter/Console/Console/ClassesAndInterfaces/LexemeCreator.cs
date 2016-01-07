using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpret.ClassesAndInterfaces
{
    interface LexemeCreator /**Creates a list of lexeme from a line**/
    {
        List<Lexeme> process(string line); //processes a string to form lexeme
    }
}
