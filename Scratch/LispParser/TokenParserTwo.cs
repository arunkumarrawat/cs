using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/*
 * The most important part is
 * abc
 *    ^
 * when finishing reading a token.
 */

// TODO: 
// BeginFunction()
// p = index;
//  .... p++/++p/p--;\
// offset
// index += offset;
namespace LispParser
{
    /// <summary>
    /// This Token Parser will use new nextc
    /// The "nextc" only skip ' ' '\n' and do refile line.
    /// </summary>
    public class TokenParserTwo : IDisposable
    {
        private string sexp = string.Empty;

        // Use File Stream to Store input string
        //private FileStream fs=null;
        private StreamReader sr = null;
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
        private string line = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sexp"></param>
        public TokenParserTwo(string sexp)
        {
            this.sexp = sexp;
        }
        #region Constructor
        /// <summary>
        /// pointer to the file stream
        /// </summary>
        /// <param name="fs"></param>
        public TokenParserTwo(FileStream fs)
        {
            sr = new StreamReader(fs);
            lineNumber = 0;
            index = 0;
        }
        #endregion

        #region Main Parser
        /// <summary>
        /// Move index forward
        /// </summary>
        private void MoveForward()
        {
            ++index;
        }

        private void getNextLine()
        {
            line = sr.ReadLine();
            lineNumber++;
            index = 0;
        }

        private char getNextChar()
        {
            char c = '\0';
            try
            {
                if (index >= line.Length - 1)
                {
                    getNextLine();
                    if (line == null)
                        return '\0';
                    else if (line == string.Empty)
                        getNextLine();
                }
                c = line[++index];
            }
            catch (Exception e)
            {
                int i = 0;
            }
            return c;
        }

        public char nextc()
        {
            if (line == string.Empty)
            {
                lineNumber++;
                line = sr.ReadLine();
                line += '\n';
                index = 0;
            }

            if (line == null)
                return '\0';

            char c = line[index];

            while (true)
            {
                switch (c)
                {
                    case ' ':
                    case '\t':
                    case '\v':
                    case '\r':
                        {
                            ++index;
                            c = line[index];
                        }
                        break;
                    case '\n':
                        {
                            line = sr.ReadLine();
                            if (line != null)
                            {
                                lineNumber++;
                                line += '\n';
                                index = 0;
                            }
                            else
                                return '\0';

                            c = line[index];
                        }
                        break;
                    default:
                        return c;
                }
            }
        }

        private bool isValidateTokenChar(char c)
        {
            if (char.IsLetter(c)
                || c == '_'
                || c == '-'
                || c == '+'
                || c == '-'
                || c == '*'
                || char.IsDigit(c))
            {
                return true;
            }
            return false;
        }

        private bool isValidateTokenStart(char c)
        {
            if (char.IsLetter(c) || c == '_')
            {
                return true;
            }
            return false;
        }

        private bool isValidateNum(char c)
        {
            if (char.IsDigit(c) || c == '.')
            {
                return true;
            }
            return false;
        }

        private Token getNextName(char c)
        {
            Token result = null;
            string cache = string.Empty;

            for(;isValidateTokenChar(c = line[index]);index++)
            {
                cache += c;
            }
            result = new Token(cache, TokenType.NAME);
            cache = string.Empty;
            return result;
        }

        private Token getString(char c)
        {
            Token result = null;
            string cache = string.Empty;

            //move to start of string.
            ++index;

            for (; (c = line[index]) != '\"'; ++index)
            {
                cache += c;
            }

            result = new Token(cache, TokenType.STRING);
            //move pointer out of string
            ++index;
            return result;
        }

        private Token getChar(char c)
        {
            Token result = null;
            string cache = string.Empty;

            ++index;
            for (; (c=line[index]) != '\''; ++index)
            {
                cache += c;
            }
            result = new Token(cache, TokenType.STRING);
            return result;
        }

        private Token getNextDigit(char c)
        {
            Token result = null;
            string cache = string.Empty;
            TokenType type = TokenType.INTEGER;
            if (c == '-' && isValidateNum(line[index + 1]) == false)
            {
                result = new Token("-", TokenType.NAME);
                ++index;
            }
            else
            {
                if (c == '-')
                {
                    c = line[++index];
                    cache += '-';
                }
                for (; isValidateNum(c = line[index]); index++)
                {
                    cache += c;
                    if (c == '.')
                        type = TokenType.FLOAT;
                    if (char.IsLetter(c))
                        type = TokenType.NAME;
                }
                result = new Token(cache, type);
            }

            return result;
        }

        public Token nextToken()
        {
            Token result = null;
            char c = nextc();

            if (c == '(')
            {
                result = new Token("(", TokenType.LEFTBRACKET);
                ++index;
            }
            else if (c == ')')
            {
                result = new Token(")", TokenType.RIGHTBRACKET);
                ++index;
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
            else if (c == '\"')
            {
                result = getString(c);
            }
            else if (c == '\'')
            {
                result = getChar(c);
            }
            else if (c == '\0')
            {
                return null;
            }
            else
            {
                result = getNextName(c);
            }

            return result;
        }

        #endregion Main Parser


        #region Public Property
        public int LineNumber
        {
            get { return lineNumber; }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (sr != null)
            {
                sr.Close();
                sr.Dispose();
                sr = null;
            }
        }
    }
}
