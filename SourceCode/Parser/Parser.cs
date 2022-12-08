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
            if (match(TokenType.FOREACH))
            {
                return foreachStatement();
            }
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
            if (match(TokenType.TRY))
            {
                return tryStatement();
            }
            if (match(TokenType.DO))
            {
                return doWhileStatement();
            }
            if (match(TokenType.STATEMENT))
            {
                return new StatementStatement(statementOrBlock());
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
            if (match(TokenType.SWITCH))
            {
                return switchs();
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
            if(match(TokenType.ENUM))
            {
                return enums();
            }
            if (get(0).getType() == TokenType.AWAIT && get(1).getType() == TokenType.WORD && get(2).getType() == TokenType.LPAREN)
            {
                return new AsyncFunctionStatement(async_function());
            }
            else if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.LPAREN)
            {
                return new FunctionStatement(function());
            }
            else if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.DDOT && get(2).getType() == TokenType.WORD && get(3).getType() == TokenType.LPAREN)
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

        private Statement switchs()
        {
            Expression expr = expression();
            List<CaseStatement> caseStatements = new List<CaseStatement>();
            consume(TokenType.LBRACE);
            
            while (!(match(TokenType.RBRACE)))
            {
                consume(TokenType.CASE);
                Expression curr = expression();
                caseStatements.Add(new CaseStatement(curr, expr, block()));
            }

            return new SwitchStatement(caseStatements);
        }

        private Statement enums()
        {
            string name = consume(TokenType.WORD).getText();
            Dictionary<string, Value> enums = new Dictionary<string, Value>();

            consume(TokenType.LBRACE);
            while(!(match(TokenType.RBRACE)))
            {
                string en = consume(TokenType.WORD).getText();
                match(TokenType.COMMA);
                enums.Add(en, new StringValue(en));
            }
            Variables.set(name, new EnumValue(enums));
            return new AssignmentStatement(name, new ValueExpression(new EnumValue(enums)));
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

            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.WORD && get(2).getType() == TokenType.DDOTEQ)
            {
                string enums = consume(TokenType.WORD).getText();
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.DDOTEQ);
                DdotEqAssignmentStatement ddotEq = new DdotEqAssignmentStatement(enums, new StringValue(variable), expression().eval());
                return ddotEq;
            }

            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.PLUSEQ)
            {
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.PLUSEQ);
                return new NewAssignmentStatement(variable, expression(), "+");
            }

            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.INST_ENUM)
            {
                List<string> fdelete = new List<string>();
                string enums = consume(TokenType.WORD).getText();
                consume(TokenType.INST_ENUM);
                consume(TokenType.LPAREN);
                while (!match(TokenType.RPAREN))
                {
                    fdelete.Add(consume(TokenType.WORD).getText());
                }
                string enumf = consume(TokenType.WORD).getText();
                Dictionary<string, Value> enumss = ((EnumValue)Variables.get(enums)).getAll();
                foreach (string fd in fdelete)
                {
                    enumss[fd] = new StringValue(fd);
                }
                Variables.set(enumf, new EnumValue(enumss));
                return new AssignmentStatement(enumf, new ValueExpression(new EnumValue(enumss)));
            }

            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.MINUSEQ)
            {
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.MINUSEQ);
                return new NewAssignmentStatement(variable, expression(), "-");
            }

            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.STAREQ)
            {
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.STAREQ);
                return new NewAssignmentStatement(variable, expression(), "*");
            }

            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.SLASHEQ)
            {
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.SLASHEQ);
                return new NewAssignmentStatement(variable, expression(), "/");
            }

            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.INC)
            {
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.INC);
                return new SuffixAssignmentStatement(variable, "+");
            }

            if (current.getType() == TokenType.WORD && get(1).getType() == TokenType.DEC)
            {
                string variable = consume(TokenType.WORD).getText();
                consume(TokenType.DEC);
                return new SuffixAssignmentStatement(variable, "-");
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
            if (current.getType() == TokenType.OBJ && get(1).getType() == TokenType.WORD)
            {
                string obj = consume(TokenType.OBJ).getText();
                string variable = consume(TokenType.WORD).getText();
                //Variables.set(variable, new NumberValue(0));
                return new AssignmentStatement(variable, new ValueExpression(0));
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

        private Statement tryStatement()
        {
            Statement statement_try = statementOrBlock();
            Statement statement_catch;
            if (match(TokenType.CATCH))
            {
                statement_catch = statementOrBlock();
            }
            else
            {
                throw new Exception("Catch block wasn\'t found");
            }
            return new TryCatchStatement(statement_try, statement_catch);
        }

        private Statement doWhileStatement()
        {
            //consume(TokenType.WHILE);
            Statement statement = statementOrBlock();
            consume(TokenType.WHILE);
            Expression condition = expression();
            return new DoWhileStatement(statement, condition);
        }

        private Statement foreachStatement()
        {
            Expression initalization = expression();
            consume(TokenType.TO);
            Expression termination = expression();
            Statement statement = statementOrBlock();
            return new ForeachStatement(termination.ToString(), initalization, statement);
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
                if (match(TokenType.BAR))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.LOGOR, result, logicalAnd());
                    continue;
                }
                if (match(TokenType.XOR))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.XOR, result, logicalAnd());
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
                if (match(TokenType.AMP))
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
            Expression result = suffix();

            while (true)
            {
                if (match(TokenType.EXCLEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.NOT_EQUALS, result, suffix());
                    continue;
                }


                if (match(TokenType.EQEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.EQUALS, result, suffix());
                    continue;
                }

                if (match(TokenType.LT))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.LT, result, suffix());
                    continue;
                }

                if (match(TokenType.LTEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.LTEQ, result, suffix());
                    continue;
                }

                if (match(TokenType.GT))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.GT, result, suffix());
                    continue;
                }

                if (match(TokenType.GTEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.GTEQ, result, suffix());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression suffix()
        {
            Expression result = foreq();

            while (true)
            {
                if (match(TokenType.INC))
                {
                    result = new SuffixExpression('+', result);
                    continue;
                }

                if (match(TokenType.DEC))
                {
                    result = new SuffixExpression('-', result);
                    continue;
                }

                if (match(TokenType.LOGNOT))
                {
                    result = new SuffixExpression('~', result);
                    continue;
                }

                break;
            }
            
            return result;
        }

        private Expression foreq()
        {
            Expression result = additive();

            while (true)
            {
                if (match(TokenType.PLUSEQ))
                {
                    result = new ForEqExpression('+', result, additive());
                    continue;
                }

                if (match(TokenType.MINUSEQ))
                {
                    result = new ForEqExpression('-', result, additive());
                    continue;
                }

                if (match(TokenType.STAREQ))
                {
                    result = new ForEqExpression('*', result, additive());
                    continue;
                }

                if (match(TokenType.SLASHEQ))
                {
                    result = new ForEqExpression('/', result, additive());
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

                if (match(TokenType.STARSTAR))
                {
                    result = new BinaryExpression('*', result, unary()).set_op1("**");
                    continue;
                }

                if (match(TokenType.PERCENT))
                {
                    result = new BinaryExpression('%', result, unary());
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
            if (match(TokenType.TRUE))
            {
                return new ValueExpression(true);
            }
            if (match(TokenType.FALSE))
            {
                return new ValueExpression(false);
            }
            if(lookMatch(0, TokenType.LDEF))
            {
                return ldef();
            }
            if(lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.DDOT))
            {
                return ddot();
            }
            if (lookMatch(0, TokenType.LAMBDA))
            {
                return lambda();
            }
            if (get(0).getType() == TokenType.WORD && get(1).getType() == TokenType.DDOT && get(2).getType() == TokenType.WORD && get(3).getType() == TokenType.LPAREN)
            {
                return function();
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.LPAREN))
            {
                return function();
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.LBRAСKET))
            {
                return element();
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.LBRACE))
            {
                return element();
            }
            if (lookMatch(0, TokenType.DOG))
            {
                return dog();
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

        private DogExpression dog()
        {
            consume(TokenType.DOG);
            consume(TokenType.LDEF);
            List<string> argNames = new List<string>();
            Statement body = statementOrBlock();
            return new DogExpression(new LdefExpression(body, argNames));
        }

        private Expression element()
        {
            string variable = consume(TokenType.WORD).getText();
            try
            {
                consume(TokenType.LBRAСKET);
                Expression index = expression();
                consume(TokenType.RBRACKET);
                return new ArrayAccesExpression(variable, index);
            }
            catch
            {
                consume(TokenType.LBRACE);
                Expression index = expression();
                consume(TokenType.RBRACE);
                return new StackAccesExpression(variable, index);
            }
        }

        private LambdaExpression lambda()
        {
            consume(TokenType.LAMBDA);
            LambdaExpression lambda = new LambdaExpression(statement());
            return lambda;
        }

        private DdotExpression ddot()
        {
            string name = consume(TokenType.WORD).getText();
            consume(TokenType.DDOT);
            StringValue value = new StringValue(consume(TokenType.WORD).getText());
            DdotExpression ddot = new DdotExpression(name, value);
            return ddot;
        }

        private LdefExpression ldef()
        {
            consume(TokenType.LDEF);
            consume(TokenType.LPAREN);
            List<string> argNames = new List<string>();
            while (!match(TokenType.RPAREN))
            {
                argNames.Add(consume(TokenType.WORD).getText());
                match(TokenType.COMMA);
            }
            Statement body = statementOrBlock();
            return new LdefExpression(body, argNames);
        }

        private FunctionalExpression function()
        {
            string name = consume(TokenType.WORD).getText();
            if (lookMatch(0, TokenType.DDOT))
            {
                consume(TokenType.DDOT);
                string valname = consume(TokenType.WORD).getText();
                consume(TokenType.LPAREN);
                FunctionalExpression efunction = new FunctionalExpression(valname);
                efunction.enumFunc = name;
                while (!match(TokenType.RPAREN))
                {
                    efunction.addArgument(expression());
                    match(TokenType.COMMA);
                }
                return efunction;
            }
            consume(TokenType.LPAREN);
            FunctionalExpression function = new FunctionalExpression(name);
            while (!match(TokenType.RPAREN))
            {
                function.addArgument(expression());
                match(TokenType.COMMA);
            }
            return function;
        }

        private FunctionalExpression async_function()
        {
            consume(TokenType.AWAIT);
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
