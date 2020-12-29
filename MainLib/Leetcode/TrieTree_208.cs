using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 208. Implement Trie(Prefix Tree) https://leetcode.com/problems/implement-trie-prefix-tree/
    public class TrieTree_208
    {
        class TrieNode
        {

            // Initialize your data structure here.
            public TrieNode()
            {

            }
        }
        public class Trie
        {
            private TrieNode root;

            private  Dictionary<char, TrieNode> next;

            public Trie()
            {
                root = new TrieNode();
                next = new Dictionary<char, TrieNode>();
            }

            // Inserts a word into the trie.
            public void Insert(String word)
            {
                for(int i=0;i<word.Length;i++)
                {
                    char c = word[i];

                    

                }
            }

            // Returns if the word is in the trie.
            public bool Search(string word)
            {
                bool result = false;



                return result;
            }

            // Returns if there is any word in the trie
            // that starts with the given prefix.
            public bool StartsWith(string word)
            {
                bool result = false;



                return result;
            }
        }

        public static void main()
        {

        }

    }
}
