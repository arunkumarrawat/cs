using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LispParser
{
    public enum TokenType
    {
        NONE,
        NAME,
        LEFTBRACKET,
        RIGHTBRACKET,
        INTEGER,
        FLOAT,
        SYMBOL,
        STRING
    }
    public enum ExpType
    {
        SEXP,
        ATOM
    }
    public interface ISExp
    {

    }
    /*
     * There are two ways to make lisp storage work
     * 1. make the a queue<ISExp>, then put all items into it.
     * just like array
     * 2. use first next in one objects. then the whole storage will be a linked
     * list
     */
    /// <summary>
    /// Queue SExpress
    /// </summary>
    public class QueueSExp : ISExp
    {
        Queue<ISExp> queue;
        public QueueSExp()
        {
            queue = new Queue<ISExp>();
        }
    }

    /// <summary>
    /// Lisp Storage: Linked SExpress
    /// </summary>
    public class LinkedSExp : ISExp
    {
        ISExp first;
        ISExp next;

        public LinkedSExp(ISExp first, ISExp next)
        {
            this.first = first;
            this.next = next;
        }

        /// <summary>
        /// Car op in lisp
        /// </summary>
        /// <returns></returns>
        public ISExp car()
        {
            return first;
        }

        /// <summary>
        /// (cdr ) cdr operation in lisp
        /// </summary>
        /// <returns></returns>
        public ISExp cdr()
        {
            return next;
        }
    }

    public class Atom : ISExp
    {
        string name;
        TokenType type;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public Atom(string name, TokenType type)
        {
            this.name = name;
            this.type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        public TokenType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public interface Op
    {
        ISExp Execute(ISExp exp);
    }

    public class EvalOp : Op
    {
        public EvalOp()
        {
        }

        public ISExp Execute(ISExp exp)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AddOp : Op
    {
        /// <summary>
        /// 
        /// </summary>
        public AddOp()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="various"></param>
        /// <returns></returns>
        public ISExp Execute(ISExp exp)
        {
            float result = 0;

            LinkedSExp localExp = exp as LinkedSExp;

            if (localExp == null)
                return null;

            LinkedSExp p = localExp;

            while (true)
            {
                if (p.cdr() == null)
                    break;

                ISExp s = p.car();

                if (s is Atom)
                {
                    if ((s as Atom).Type == TokenType.INTEGER)
                    {
                        result += Int32.Parse((s as Atom).Name);
                    }
                    else if ((s as Atom).Type == TokenType.FLOAT)
                    {
                        result += float.Parse((s as Atom).Name);
                    }
                }
                else
                {
                    return null;// fail to execute;
                }
                p = (LinkedSExp)p.cdr();
            }

            //foreach (ISExp s in various)
            //{
            //    if (s is Atom)
            //    {
            //        if ((s as Atom).Type == TokenType.INTEGER)
            //        {
            //            result += Int32.Parse((s as Atom).Name);
            //        }
            //        else if ((s as Atom).Type == TokenType.FLOAT)
            //        {
            //            result += float.Parse((s as Atom).Name);
            //        }
            //    }
            //    else
            //    {
            //        return null;// fail to execute;
            //    }
            //}

            return new Atom(result.ToString(), TokenType.INTEGER);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ValueEnvironment
    {
        private Dictionary<string, object> values = new Dictionary<string, object>();
        private ValueEnvironment parent;

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

        public void SetGlobalValue(string name, object value)
        {
            if (this.parent == null)
            {
                this.values[name] = value;
                return;
            }

            this.parent.SetGlobalValue(name, value);
        }
    }
}
