using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang
{
    public class Token
    {
        private TokenType type;

        private string text;

        public Token(TokenType type, string text)
        {
            this.type = type;
            this.text = text;
        }

        public TokenType getType()
        {
            return type;
        }

        public void setType(TokenType type)
        {
            this.type = type;
        }

        public string getText()
        {
            return text;
        }

        public void setText(string text)
        {
            this.text = text;
        }

        override public string ToString()
        {
            return type + " " + text;
        }
    }
}
