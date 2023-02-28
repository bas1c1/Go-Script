using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    public interface Value
    {
        double asDouble();
        string asString();
        int asNumber();
        char asChar();
        object asObject();
        TokenType type();
    }
}
