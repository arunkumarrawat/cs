using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    /// <summary>
    /// https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3645/
    /// </summary>
    public class MinimumRemovetoMakeValidParentheses
    {
        class TObj
        {
            public char c;
            public int index;
            public TObj()
            {

            }
            public TObj(char c, int index)
            {
                this.c = c;
                this.index = index;
            }
        }
        public string MinRemoveToMakeValid(string s)
        {
            Stack<TObj> stack = new Stack<TObj>();

            char[] a = s.ToCharArray();

            for(int i=0;i<a.Length;i++)
            {
                if(a[i] == '(')
                {
                    stack.Push(new TObj(a[i], i));
                }

                if (a[i] == ')')
                {
                    if(stack.Count>0 && stack.Peek().c == '(')
                    {
                        stack.Pop();
                    } else
                    {
                        stack.Push(new TObj(a[i], i));
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            while(stack.Count>0)
            {
                a[stack.Peek().index] = '0';
                stack.Pop();
            }

            for(int i=0;i<a.Length;i++)
            {
                if(a[i] != '0')
                {
                    sb.Append(a[i]);
                }
            }
            return sb.ToString();
        }

        public static void main()
        {
            MinimumRemovetoMakeValidParentheses s = new MinimumRemovetoMakeValidParentheses();
            string x = "))((";
            string result = s.MinRemoveToMakeValid(x);
            Console.WriteLine(result);
        }
    }
}
