using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang
{
    class Lexer
    {
        private static string OPERATOR_CHARS = "+-*/()[]{}=<>!&|;.:";
        private string input;
        private List<Token> tokens;
        private static Dictionary<string, TokenType> OPERATORS;
        static Lexer()
        {
            OPERATORS = new Dictionary<string, TokenType>();

            OPERATORS.Add("++", TokenType.INC);
            OPERATORS.Add("--", TokenType.DEC);

            OPERATORS.Add("+=", TokenType.PLUSEQ);
            OPERATORS.Add("-=", TokenType.MINUSEQ);
            OPERATORS.Add("*=", TokenType.STAREQ);
            OPERATORS.Add("/=", TokenType.SLASHEQ);

            OPERATORS.Add("+", TokenType.PLUS);
            OPERATORS.Add("-", TokenType.MINUS);
            OPERATORS.Add("*", TokenType.STAR);
            OPERATORS.Add("/", TokenType.SLASH);

            OPERATORS.Add("(", TokenType.LPAREN);
            OPERATORS.Add(")", TokenType.RPAREN);
            OPERATORS.Add("[", TokenType.LBRAСKET);
            OPERATORS.Add("]", TokenType.RBRACKET);
            OPERATORS.Add("{", TokenType.LBRACE);
            OPERATORS.Add("}", TokenType.RBRACE);
            OPERATORS.Add("=", TokenType.EQ);
            OPERATORS.Add("<", TokenType.LT);
            OPERATORS.Add(">", TokenType.GT);
            OPERATORS.Add(";", TokenType.COMMA);
            OPERATORS.Add(".", TokenType.DOT);
            OPERATORS.Add(":", TokenType.DDOT);

            OPERATORS.Add("!", TokenType.EXCL);
            OPERATORS.Add("&", TokenType.AMP);
            OPERATORS.Add("|", TokenType.BAR);

            OPERATORS.Add("==", TokenType.EQEQ);
            OPERATORS.Add("!=", TokenType.EXCLEQ);
            OPERATORS.Add("<=", TokenType.LTEQ);
            OPERATORS.Add(">=", TokenType.GTEQ);

            OPERATORS.Add("&&", TokenType.AMPAMP);
            OPERATORS.Add("||", TokenType.BARBAR);
        }
        private int pos;
        private int length;
        public Lexer(string input)
        {
            this.input = input;
            length = input.Length;

            tokens = new List<Token>();
        }

        public List<Token> tokenize()
        {
            while (pos < length)
            {
                char current = peek(0);
                if (Char.IsDigit(current)) tokenizeNumber();
                else if (Char.IsLetter(current)) tokenizeWord();
                else if (OPERATOR_CHARS.IndexOf(current) != -1)
                {
                    tokenizeOperator();
                }
                else if (current == '"')
                {
                    tokenizeText();
                }
                else
                {
                    next();
                }
            }
            return tokens;
        }

        private void tokenizeText()
        {
            next();
            StringBuilder buffer = new StringBuilder();
            char current = peek(0);
            while (true)
            {
                if (current == '\\')
                {
                    current = next();
                    switch (current)
                    {
                        case '"':
                            {
                                current = next();
                                buffer.Append('"');
                                continue;
                            }
                        case 'n':
                            {
                                current = next();
                                buffer.Append('\n');
                                continue;
                            }
                        case 't':
                            {
                                current = next();
                                buffer.Append('\t');
                                continue;
                            }
                        case 'b':
                            {
                                current = next();
                                buffer.Append('\b');
                                continue;
                            }
                        case 'r':
                            {
                                current = next();
                                buffer.Append('\r');
                                continue;
                            }
                        case 'a':
                            {
                                current = next();
                                buffer.Append('\a');
                                continue;
                            }
                        case 'f':
                            {
                                current = next();
                                buffer.Append('\f');
                                continue;
                            }
                        case 'v':
                            {
                                current = next();
                                buffer.Append('\v');
                                continue;
                            }
                    }
                    buffer.Append('\\');
                    continue;
                }
                if (current == '"')
                {
                    break;
                }
                buffer.Append(current);
                current = next();
            }
            next();

            addToken(TokenType.TEXT, buffer.ToString());
        }

        private void tokenizeWord()
        {
            StringBuilder buffer = new StringBuilder();
            char current = peek(0);
            while (true)
            {
                if (!Char.IsLetterOrDigit(current) && (current != '_') && (current != '$'))
                {
                    break;
                }
                buffer.Append(current);
                current = next();
            }
            string word = buffer.ToString();
            switch (word)
            {
                case "ldef":
                    {
                        addToken(TokenType.LDEF);
                        break;
                    }
                case "switch":
                    {
                        addToken(TokenType.SWITCH);
                        break;
                    }
                case "case":
                    {
                        addToken(TokenType.CASE);
                        break;
                    }
                case "statement":
                    {
                        addToken(TokenType.STATEMENT);
                        break;
                    }
                case "lambda":
                    {
                        addToken(TokenType.LAMBDA);
                        break;
                    }
                case "catch":
                    {
                        addToken(TokenType.CATCH);
                        break;
                    }
                case "await":
                    {
                        addToken(TokenType.AWAIT);
                        break;
                    }
                case "sout":
                    {
                        addToken(TokenType.PRINT);
                        break;
                    }
                case "var":
                    {
                        addToken(TokenType.OBJ);
                        break;
                    }
                case "enum":
                    {
                        addToken(TokenType.ENUM);
                        break;
                    }
                case "if":
                    {
                        addToken(TokenType.IF);
                        break;
                    }
                case "else":
                    {
                        addToken(TokenType.ELSE);
                        break;
                    }

                case "try":
                    {
                        addToken(TokenType.TRY);
                        break;
                    }

                case "while":
                    {
                        addToken(TokenType.WHILE);
                        break;
                    }
                case "for":
                    {
                        addToken(TokenType.FOR);
                        break;
                    }
                case "foreach":
                    {
                        addToken(TokenType.FOREACH);
                        break;
                    }
                case "to":
                    {
                        addToken(TokenType.TO);
                        break;
                    }

                case "do":
                    {
                        addToken(TokenType.DO);
                        break;
                    }
                case "break":
                    {
                        addToken(TokenType.BREAK);
                        break;
                    }
                case "continue":
                    {
                        addToken(TokenType.CONTINUE);
                        break;
                    }
                case "def":
                    {
                        addToken(TokenType.DEF);
                        break;
                    }
                case "class":
                    {
                        addToken(TokenType.CLASS);
                        break;
                    }
                case "init":
                    {
                        addToken(TokenType.RUN_CLASS);
                        break;
                    }
                case "return":
                    {
                        addToken(TokenType.RETURN);
                        break;
                    }
                case "use":
                    {
                        addToken(TokenType.USE);
                        break;
                    }
                case "true":
                    {
                        addToken(TokenType.TRUE);
                        break;
                    }
                case "false":
                    {
                        addToken(TokenType.FALSE);
                        break;
                    }
                default:
                    {
                        addToken(TokenType.WORD, word);
                        break;
                    }
            }
        }

        private void tokenizeOperator()
        {
            char current = peek(0);
            if (current == '/')
            {
                if (peek(1) == '/')
                {
                    next();
                    next();
                    tokenizeComment();
                    return;
                }
                else if (peek(1) == '*')
                {
                    next();
                    next();
                    tokenizeMultilineComment();
                    return;
                }
            }

            StringBuilder buffer = new StringBuilder();
            while (true)
            {
                string text = buffer.ToString();
                if (!OPERATORS.ContainsKey(text + current) && text != null)
                {
                    addToken(OPERATORS[text]);
                    return;
                }
                buffer.Append(current);
                current = next();
            }
        }

        private void tokenizeMultilineComment()
        {
            char current = peek(0);
            while (true)
            {
                if (current == '\0') throw new Exception("Missing close tag");
                if (current == '*' && peek(1) == '/') break;
                current = next();
            }
            next();
            next();
        }

        private void tokenizeComment()
        {
            char current = peek(0);
            while ("\r\n\0".IndexOf(current) == -1)
            {
                current = next();
            }
        }

        private void tokenizeNumber()
        {
            StringBuilder buffer = new StringBuilder();
            char current = peek(0);
            while (true)
            {
                if (current == ',')
                {
                    if (buffer.ToString().IndexOf(',') != -1)
                    {
                        throw new Exception("Invalid float number");
                    }
                }
                else if (!Char.IsDigit(current))
                {
                    break;
                }
                buffer.Append(current);
                current = next();
            }
            addToken(TokenType.NUMBER, buffer.ToString());
        }

        private char next()
        {
            pos++;
            return peek(0);
        }

        private char peek(int relativePosition)
        {
            int position = pos + relativePosition;
            if (position >= length)
            {
                return '\0';
            }
            return input[position];
        }

        private void addToken(TokenType type)
        {
            addToken(type, "");
        }

        private void addToken(TokenType type, string text)
        {
            tokens.Add(new Token(type, text));
        }
    }
}
