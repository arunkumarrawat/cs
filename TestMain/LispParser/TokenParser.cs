using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LispParser
{
    public class Token
    {
        string tokenValue;
        TokenType type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenValue"></param>
        /// <param name="type"></param>
        public Token(string tokenValue, TokenType type)
        {
            this.tokenValue = tokenValue;
            this.type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TokenValue
        {
            get { return tokenValue; }
            set { tokenValue = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public TokenType Type
        {
            get { return type; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TokenParser : IDisposable
    {
        private string sexp=string.Empty;

        // Use File Stream to Store input string
        //private FileStream fs=null;
        private StreamReader sr=null;

        /// <summary>
        /// main index for line and nextc
        /// </summary>
        private int index = 0;

        /// <summary>
        /// To Help stream reader to know which line.
        /// </summary>
        private int lineNumber = 0;
        
        /// <summary>
        /// The only line to store the file
        /// </summary>
        private string line=string.Empty;

        /// <summary>
        /// to identify whether the stream reader is still reading
        /// if EOF appear, IsReading will be false
        /// </summary>
        private bool IsReading = true;
        
        /// <summary>
        /// Save the lastToken
        /// </summary>
        private Token lastToken = null;

        /// <summary>
        /// save last char token, if IsLastCharChange is true, then 
        /// we will no get nextc
        /// </summary>
        private bool IsLastCharChange = false;
        private char lastChar = '\0';
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sexp"></param>
        public TokenParser(string sexp)
        {
            this.sexp = sexp;
        }

        /// <summary>
        /// pointer to the file stream
        /// </summary>
        /// <param name="fs"></param>
        public TokenParser(FileStream fs)
        {
            sr = new StreamReader(fs);
        }
        
        //using(FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        /*
         * Comparing to two different version of nextc,
         * This first one is the one below,
         * it changes the '\r''\n' to ' '(space).
         * The second one is TokenParserTwo.nextc
         * It use two steps to get token.
         * <1>. nextc to skip ' ', if '\n' appear, it will refill the line.
         * <2>. the keyword() function to move forward to get a whole token.
         * <3>. then call nextc() to move to the beginning of next token.
         * */
        public char nextc()
        {
            if (line == string.Empty)
            {
                lineNumber = 1;
                line = sr.ReadLine();
            }

            //if file is empty or reading is finished, return '\0'
            if (line == null)
                return '\0';

            if (index < line.Length)
            {
                char c = line[index++];
                if (c == '\r' ||
                    c == '\n' ||
                    c== '\t' ||
                    c== '\v' 
                    )
                    return ' ';

                return c;
            }

            if (index >= line.Length)
            {
                /* refill the line, have a new line.
                 * if it is last line, we will return '\0'
                */
                line = sr.ReadLine();

                if (line == null)
                    return '\0';

                lineNumber++;

                index = 0;

                return ' ';
            }
            return '\0';
        }

        private void updateLastChar(char c)
        {
            lastChar = c;
        }

        private void resetLastChar()
        {
            lastChar = '\0';
        }

        private bool CheckDelimit(char c)
        {
            if (c == '\0'||
                c == '(' ||
                c == ')')
            {
                updateLastChar(c);
                return true;
            }
            return false;
        }

        public Token getNextName(char c)
        {
            Token result = null;
            string cache = string.Empty;
            cache += c;
            while ((c = nextc()) != ' ')
            {
                if (CheckDelimit(c) == true)
                    break;

                cache += c;
            }
            result = new Token(cache, TokenType.NAME);
            cache = string.Empty;
            return result;
        }

        public Token getNextDigit(char c)
        {
            Token result = null;
            string cache = string.Empty;
            cache += c;
            TokenType type = TokenType.INTEGER;
                while ((c = nextc()) != ' ')
                {
                    if (CheckDelimit(c) == true)
                        break;
                    cache += c;
                    if (c == '.')
                        type = TokenType.FLOAT;
                    if (char.IsLetter(c))
                        type = TokenType.NAME;
                }
            result = new Token(cache, type);
            return result;
        }

        public Token nextToken()
        {
            Token result = null;
            char c;
            //loop condition
            if (lastChar == '\0')
                c = nextc();
            else
            {
                c = lastChar;
                lastChar = '\0';
            }

            // Get the end of file
            if (c == '\0')
                return null;

            /*
             * if c is letter, push c into cache.
             */
            string cache = string.Empty;
            if (c == '(')
            {
                result = new Token("(", TokenType.LEFTBRACKET);
            }
            else if (c == ')')
            {
                result = new Token(")", TokenType.RIGHTBRACKET);
            }
            else if (char.IsLetter(c))
            {
                result = getNextName(c);
            }
            else if (c == '-')
            {
                result = getNextDigit(c);
            }
            else if (char.IsDigit(c))
            {
                result = getNextDigit(c);
            }
            //else if (c == '`')
            //{
            //    while ((c = nextc()) != ' ')
            //    {
            //        if (CheckDelimit(c) == true)
            //            break;
            //        cache += c;
            //    }
            //    result = new Token(cache, TokenType.SYMBOL);
            //    cache = string.Empty;
            //}
            else
            {
                if (c != ' ')
                {
                    return getNextName(c);
                }

                if (c == ' ')
                {
                    while ((c = nextc()) == ' ') ;
                    lastChar = c;
                }
                return nextToken();
            }


            return result;
        }

        public bool validateSExp(string sexp)
        {
            /*
             * Here we want to do some check on sexp
             * (abc (def ))
             * check whether '(' match ')'
             * algorithm
             * 1. push '(' into stack or counter increase 1
             * 2. if ')' pop up first '(' in stack or counter decrease 1
             * 3. when string finished, the stack should be empty or counter be zero
             */
            //Stack<char> stack = new Stack<char>();
            int counter = 0;
            for (int i = 0; i < sexp.Length; i++)
            {
                if (sexp[i] == '(')
                    counter++;
                else if (sexp[i] == ')')
                    counter--;
            }

            return (counter == 0 ? true : false);
        }

        public void Dispose()
        {
            if (sr != null)
                sr.Close();

            if (line != null)
                line = null;

            lastToken = null;
        }
    }
}
