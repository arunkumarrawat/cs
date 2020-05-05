using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LispWindows
{
    public class ValueEnvironment
    {
        Dictionary<string, object> values = new Dictionary<string, object>();
        ValueEnvironment parent;

        public ValueEnvironment()
        {
        }

        public ValueEnvironment(ValueEnvironment parent)
        {
            this.parent = parent;
        }

        public object GetValue(string name)
        {
            if (!this.values.ContainsKey(name))
            {
                if (!(this.parent == null))
                {
                    return this.parent.GetValue(name);
                }

                return null;
            }

            return this.values[name];
        }

        public void SetValue(string name, object value)
        {
            this.values[name] = value;
        }

    }

    public enum LispObjectType
    {
        LispInt,
        LispFloat,
        LispDouble,
        LispString,
        LispLeftClose,
        LispRightClose,
        LispSymbols,
    };

    public class Token
    {
        public LispObjectType Type { get; set; }
        public object value { get; set; }
    }

    public class LispObject
    {
        private LispObjectType type;
        private object value;

        public LispObject(LispObjectType type, object value)
        {
            this.type = type;
            this.value = value;
        }

        public LispObjectType Type
        {
            get { return type; }
            set { type = value; }
        }

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }

    //@example: Lisp - invoke lisp from winforms
    public partial class Form1 : Form
    {
        Stack<LispObject> stack = new Stack<LispObject>();

        Dictionary<string, Delegate> env = new Dictionary<string, Delegate>();
        Dictionary<string, Stack<Type>> envStack = new Dictionary<string, Stack<Type>>();
        delegate void f1(string name);
        f1 g1;

        Token[] tokens = new Token[100000];
        int tokensPointer=0;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox.Items.Add("abc");
            g1 = new f1(addString);
            env.Add("addString", g1);

            Stack<Type> addStringType = new Stack<Type>();
            addStringType.Push(typeof(string));
            envStack.Add("addString", addStringType);
        }

        private void addString(string itemName)
        {
            listBox.Items.Add(itemName);
        }

        private void eval(string evalString)
        {
            char[] p = evalString.ToCharArray();
            Token t;
            int start;

            for (int i = 0; i < p.Length; i++)
            {
                switch (p[i])
                {
                    case '(':
                        t = new Token();
                        t.Type = LispObjectType.LispLeftClose;
                        t.value = '(';
                        tokens[tokensPointer++] = t;
                        break;

                    case 'a': case 'b': case 'c': case 'd': case 'e': 
                    case 'f': case 'g': case 'h': case 'i': case 'j': 
                    case 'k': case 'l': case 'm': case 'n': case 'o': 
                    case 'p': case 'q': case 'r': case 's': case 't': 
                    case 'u': case 'v': case 'w': case 'x': case 'y': 
                    case 'z': 
                    case 'A': case 'B': case 'C': case 'D': case 'E': 
                    case 'F': case 'G': case 'H': case 'I': case 'J': 
                    case 'K': case 'L': case 'M': case 'N': case 'O': 
                    case 'P': case 'Q': case 'R': case 'S': case 'T': 
                    case 'U': case 'V': case 'W': case 'X': case 'Y': 
                    case 'Z':
                    case '_': case '-':
                        start = i;

                        while (char.IsLetter(p[start]) == true
                            || p[start] == '-'
                            || p[start] == '_')
                        {
                            start++;
                        }
                        t = new Token();
                        t.Type = LispObjectType.LispSymbols;
                        t.value = evalString.Substring(i, start - i);
                        tokens[tokensPointer++] = t;

                        i = start;
                        break;

                    case '\"':
                        start = i+1;

                        while (p[start] != '\"' && start < evalString.Length) start++;
                        t = new Token();
                        t.Type = LispObjectType.LispString;
                        t.value = evalString.Substring(i+1, start - i - 1);
                        i = start;
                        tokens[tokensPointer++] = t;
                        break;

                    case '\'':
                        start = i+1;

                        while (p[start] != '\'' && start < evalString.Length) start++;

                        t = new Token();
                        t.Type = LispObjectType.LispString;
                        t.value = evalString.Substring(i+1, start - i - 1);
                        i = start+1;
                        tokens[tokensPointer++] = t;
                        break;

                    case '0': case '1': case '2': case '3': case '4': case '5': 
                    case '6': case '7': case '8': case '9':
                        start = i;
                        bool isInt = true;
                        while (char.IsNumber(p[start]) == true
                            ||p[start]=='.')
                        {
                            start++;

                            if (p[start] == '.')
                                isInt = false;
                        }

                        t = new Token();
                        if (isInt == true)
                        {
                            t.Type = LispObjectType.LispInt;
                            t.value = Int32.Parse(evalString.Substring(i, start - i));
                        }
                        else
                        {
                            t.Type = LispObjectType.LispFloat;
                            t.value = float.Parse(evalString.Substring(i, start - i));
                        }
                        tokens[tokensPointer++] = t;
                        break;

                    case ')':
                        t = new Token();
                        t.Type = LispObjectType.LispRightClose;
                        t.value = ')';
                        tokens[tokensPointer++] = t;
                        break;

                    case ' ':
                    case '\t':
                    case '\n':
                        // skip sperators.
                        break;
                }
            }

            evalToken();

        }

        private void evalToken()
        {
            int end = tokensPointer;
            int depth = 0;
            for (int i = 0; i < end; i++)
            {
                if (tokens[i].Type == LispObjectType.LispLeftClose)
                {
                    string name = (string)tokens[i+1].value;
                    if (envStack[name] != null)
                    {
                        Stack<Type> t = envStack[name];

                        if (tokens[i + t.Count+2].Type != LispObjectType.LispRightClose)
                        {
                            MessageBox.Show("Parse Error!!!!");
                            break;
                        }

                        switch (t.Count)
                        {
                            case 1:
                                Delegate tg = env[name];
                                tg.DynamicInvoke((string)tokens[i+2].value);
                                break;
                        }
                        i = i + t.Count + 2;
                    }
                }
            }
        }

        private void btnEval_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtEval.Text);
            if (txtEval.Text != null)
            {
                eval(txtEval.Text);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }

    public class pfunction
    {
        public Delegate FunctionPointer { get; set; }
        public Stack<Type> FunctionType { get; set; }
    }

    public class LispHelper
    {
        Dictionary<string, pfunction> env;

        public LispHelper()
        {
            env = new Dictionary<string, pfunction>();
        }

        public void add(string name, pfunction f)
        {
            env.Add(name, f);
        }

        public pfunction getFunction(string name)
        {
            if (env[name] != null)
            {
                return env[name];
            }
            return null;
        }

        public void callAndExe(string name, Stack<object> various)
        {

        }
    }
}
