using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LispParser
{
    public delegate void GeneralPointer(params LispObject[] list);

    public enum LispObjectType
    {
        LispInt,
        LispFloat,
        LispDouble,
        LispString,
    };

    public class LispObject
    {
        private LispObjectType objectType;
        private object value;

        LispObject(LispObjectType objectType, object value)
        {
            this.objectType = objectType;
            this.value = value;
        }

        public LispObjectType ObjectType
        {
            get { return objectType; }
            set { objectType = value; }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }

    public class LispSubr
    {
        private string symbolName;
        //int opcode;
        //Stack<LispObject> paramaters;
        private GeneralPointer pointer;
        private string doc;
        private string prompt;

        public LispSubr(string symbolName, GeneralPointer pointer, string prompt, string doc)
        {
            this.symbolName = symbolName;
            this.pointer = pointer;
            this.prompt = prompt;
            this.doc = doc;
        }



    }

    /*
     * switch(number)
     * {
     * case 2:
     *     instruction.pointer(argv0,argv1);
     *     
     * }
     */

    /*
     *public enum TokenType
    {
        LEFTPARENTHESIS,      //(
        RIGHTPARENTHESIS,     //)
        SYMOBLS,              //function-name
        STRING,               //"string"
        INT,                  //123
        NUMBER,               //123.345
    };
     * 
     *  delegate void GeneratePointer1(string name);
        delegate void GeneratePointer0();
        GeneratePointer0 p0;
        GeneratePointer1 p1;
     * 
     *  private void Form1_Load(object sender, EventArgs e)
        {
            p0 = new GeneratePointer0(echoMessage);
            p1 = new GeneratePointer1(addString);
            nodes.Add("echo", p0);
            nodes.Add("add-string", p1);
        }

        private void echoMessage()
        {
            MessageBox.Show("Hello");
        }
     * 
     *  private void CompilerAndInvoke(string sexp)
        {
            for (int i = 0; i < sexp.Length; i++)
            {
                switch (sexp[i])
                {
                    case '(':
                        break;

                    case '\"':
                        break;

                }
            }
        }
     */

    class Program
    {
        static void GetNextcTest()
        {
            FileStream fs = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\lisp.txt", FileMode.Open);
            FileStream output = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\out.txt", FileMode.Create);

            StreamWriter sw = new StreamWriter(output);

            TokenParserTwo tokenParser = new TokenParserTwo(fs);
            char c = tokenParser.nextc();
            //while (c != '\0')
            //{
            //    sw.WriteLine(c);
            //    c = tokenParser.nextc();
            //}
            fs.Close();
            sw.Close();
        }

        static void GetNextTokenTest()
        {
            FileStream fs = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\lisp.txt", FileMode.Open);
            FileStream output = new FileStream("D:\\workspace\\c\\my-lib\\test\\TestMain\\LispParserTest\\IO\\out-token.txt", FileMode.Create);

            StreamWriter sw = new StreamWriter(output);
            TokenParserTwo tokenParser = new TokenParserTwo(fs);
            using (tokenParser)
            {
                Token t = tokenParser.nextToken();
                while (t != null)
                {
                    sw.WriteLine(t.TokenValue + "," + t.Type);
                    t = tokenParser.nextToken();
                }
                Console.WriteLine(tokenParser.LineNumber);
            }
            fs.Close();
            sw.Close();
        }

        //@example: Lisp parser and Test program
        static void Main(string[] args)
        {
            string commandString = "(add 1 2 (add 2 3) 4)";
            Stack<string> mainStack = new Stack<string>();

            Queue<ISExp> sexp = new Queue<ISExp>();

            GetNextcTest();
            GetNextTokenTest();
        }
    }
}

/*
 * Now Nextc can works very good.
 * abc 
 * ^
 * index=0;
 * abc 
 *    ^
 * index=3   
 */
