using OwnLang.ast.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLang.ast
{
    class Parser
    {
        private List<Token> tokens;
        private int pos;
        private int size;
        private static Token EOF = new Token(TokenType.EOF, "");
        
        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            size = tokens.Count();
        }

        public Statement parse()
        {
            BlockStatement result = new BlockStatement();
            while (!match(TokenType.EOF))
            {
                result.add(statement());
            }
            return result;
        }

        private Statement block()
        {
            BlockStatement block = new BlockStatement();
            consume(TokenType.LBRACE);
            while (!match(TokenType.RBRACE))
            {
                block.add(statement());
            }
            return block;
        }

        private Statement statementOrBlock()
        {
            if (get(0).getType() == TokenType.LBRACE) return block();
            return statement();
        }

        private Statement statement()
        {
            if (match(TokenType.PRINT))
            {
                return new PrintStatement(expression());
            }
            if (match(TokenType.IF))
            {
                return ifElse();
            }
            if (match(TokenType.WHILE))
            {
                return whileStatement();
            }
            if (match(TokenType.DO))
            {
                return doWhileStatement();
            }
            if (match(TokenType.BREAK))
            {
                return new BreakStatement();
            }
            if (match(TokenType.CONTINUE))
            {
                return new ContinueStatement();
            }
            if (match(TokenType.RETURN))
            {
                return new ReturnStatement(expression());
            }
            if (match(TokenType.USE))
            {
                return new UseStatement(expression().ToString());
            }
            if (match(TokenType.FOR))
            {
                return forStatement();
            }
            if (match(TokenType.DEF))
            {
                return functionDefine();
            }
            if (match(TokenType.CLASS))
            {
                return classDefine();
            }
            if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.LPAREN)
            {
                return new FunctionStatement(function());
            }
            if (get(0).getType() == TokenType.RUN_CLASS && get(1).getType() == TokenType.WORD && get(2).getType() == TokenType.LPAREN)
            {
                return new ClassStatement(classes());
            }
            return assignmentStatement();
        }

        private ClassDefine classDefine()
        {
            string name = consume(TokenType.WORD).getText();
            consume(TokenType.LPAREN);
            List<string> argNames = new List<string>();
            while (!match(TokenType.RPAREN))
            {
                argNames.Add(consume(TokenType.WORD).getText());
                match(TokenType.COMMA);
            }
            Statement body = statementOrBlock();
            return new ClassDefine(name, body);
        }

        private FunctionDefine functionDefine()
        {
            string name = consume(TokenType.WORD).getText();
            consume(TokenType.LPAREN);
            List<string> argNames = new List<string>();
            while (!match(TokenType.RPAREN))
            {
                argNames.Add(consume(TokenType.WORD).getText());
                match(TokenType.COMMA);
            }
            Statement body = statementOrBlock();
            return new FunctionDefine(name, argNames, body);
        }

        private Statement assignmentStatement()
        {
            Token current = get(0);
            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.EQ)
            {
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.EQ);
                return new AssignmentStatement(variable, expression());
            }
            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.LBRAСKET)
            {
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.LBRAСKET);
                Expression index = expression();
                consume(TokenType.RBRACKET);
                consume(TokenType.EQ);
                return new ArrayAssignmentStatement(variable, index, expression());
            }
            if (current.getType() == TokenType.OBJ && get(1).getType() == TokenType.WORD && get(2).getType() == TokenType.EQ)
            {
                string obj = consume(TokenType.OBJ).getText();
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.EQ);
                return new AssignmentStatement(variable, expression());
            }

            throw new Exception("Unknow statement");
        }

        private Statement ifElse()
        {
            Expression condition = expression();
            Statement ifStatement = statementOrBlock();
            Statement elseStatement;

            if (match(TokenType.ELSE))
            {
                elseStatement = statementOrBlock();
            }
            else
            {
                elseStatement = null;
            }

            return new IfStatement(condition, ifStatement, elseStatement);
        }

        private Statement whileStatement()
        {
            //consume(TokenType.WHILE);
            Expression condition = expression();
            Statement statement = statementOrBlock();
            return new WhileStatement(condition, statement);
        }

        private Statement doWhileStatement()
        {
            //consume(TokenType.WHILE);
            Statement statement = statementOrBlock();
            consume(TokenType.WHILE);
            Expression condition = expression();
            return new DoWhileStatement(statement, condition);
        }

        private Statement forStatement()
        {
            Statement initalization = assignmentStatement();
            consume(TokenType.COMMA);
            Expression termination = expression();
            consume(TokenType.COMMA);
            Statement increment = assignmentStatement();
            Statement statement = statementOrBlock();
            return new ForStatement(termination, statement, initalization, increment);
        }

        private Expression expression()
        {
            return logicalOr();
        }

        private Expression logicalOr()
        {
            Expression result = logicalAnd();

            while (true)
            {
                if (match(TokenType.BARBAR))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.OR, result, logicalAnd());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression logicalAnd()
        {
            Expression result = equality();

            while (true)
            {
                if (match(TokenType.AMPAMP))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.AND, result, equality());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression equality()
        {
            Expression result = conditional();

            if (match(TokenType.EXCLEQ))
            {
                return new ConditionalExpression(ConditionalExpression.Operator.NOT_EQUALS, result, conditional());
            }


            if (match(TokenType.EQEQ))
            {
                return new ConditionalExpression(ConditionalExpression.Operator.EQUALS, result, conditional());
            }

            return result;
        }

        private Expression conditional()
        {
            Expression result = additive();

            while (true)
            {
                if (match(TokenType.EXCLEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.NOT_EQUALS, result, additive());
                    continue;
                }


                if (match(TokenType.EQEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.EQUALS, result, additive());
                    continue;
                }

                if (match(TokenType.LT))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.LT, result, additive());
                    continue;
                }

                if (match(TokenType.LTEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.LTEQ, result, additive());
                    continue;
                }

                if (match(TokenType.GT))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.GT, result, additive());
                    continue;
                }

                if (match(TokenType.GTEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.GTEQ, result, additive());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression additive()
        {
            Expression result = multiplicative();

            while (true)
            {
                if (match(TokenType.PLUS))
                {
                    result = new BinaryExpression('+', result, multiplicative());
                    continue;
                }

                if (match(TokenType.MINUS))
                {
                    result = new BinaryExpression('-', result, multiplicative());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression multiplicative()
        {
            Expression result = unary();

            while (true)
            {
                if (match(TokenType.STAR))
                {
                    result = new BinaryExpression('*', result, unary());
                    continue;
                }

                if (match(TokenType.SLASH))
                {
                    result = new BinaryExpression('/', result, unary());
                    continue;
                }
                break;
            }
            return result;
        }

        private Expression unary()
        {
            if (match(TokenType.MINUS))
            {
                return new UnaryExpression('-', primary());
            }
            if (match(TokenType.PLUS))
            {
                return new UnaryExpression('+', primary());
            }
            return primary();
        }

        private Expression primary()
        {
            Token current = get(0);
            if (match(TokenType.NUMBER))
            {
                return new ValueExpression(double.Parse(current.getText()));
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.LPAREN))
            {
                return function();
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.LBRAСKET))
            {
                return element();
            }
            if (match(TokenType.WORD))
            {
                return new ConstantExpression(current.getText());
            }
            if (match(TokenType.TEXT))
            {
                return new ValueExpression(current.getText());
            }
            if (match(TokenType.LPAREN))
            {
                Expression result = expression();
                match(TokenType.RPAREN);
                return result;
            }
            throw new Exception("unknown expression");
        }

        private Expression element()
        {
            string variable = consume(TokenType.WORD).getText();
            consume(TokenType.LBRAСKET);
            Expression index = expression();
            consume(TokenType.RBRACKET);
            return new ArrayAccesExpression(variable, index);
        }

        private FunctionalExpression function()
        {
            string name = consume(TokenType.WORD).getText();
            consume(TokenType.LPAREN);
            FunctionalExpression function = new FunctionalExpression(name);
            while (!match(TokenType.RPAREN))
            {
                function.addArgument(expression());
                match(TokenType.COMMA);
            }
            return function;
        }

        private ClassExpression classes()
        {
            consume(TokenType.RUN_CLASS);
            string name = consume(TokenType.WORD).getText();
            consume(TokenType.LPAREN);
            ClassExpression classes = new ClassExpression(name);
            while (!match(TokenType.RPAREN))
            {
                //classes.addArgument(expression());
                match(TokenType.COMMA);
            }
            return classes;
        }

        private Token consume(TokenType type)
        {
            Token current = get(0);

            if (type != current.getType()) throw new Exception("Token" + current + "doesn't match" + type);
            pos++;
            return current;
        }

        private bool match(TokenType type)
        {
            Token current = get(0);

            if (type != current.getType()) return false;
            pos++;
            return true;
        }

        private bool lookMatch(int index, TokenType type)
        {
            Token current = get(index);

            if (type != current.getType()) return false;
            //pos++;
            return true;
        }

        private Token get(int relativePosition)
        {
            int position = pos + relativePosition;
            if (position >= size)
            {
                return EOF;
            }
            return tokens[position];
        }
    }
}
