using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeCard.Trie
{
    public class WordDictionary
    {
        private TrieNode root;
        public WordDictionary()
        {
            this.root = new TrieNode();
        }

        public void AddWord(string word)
        {
            TrieNode node = root;
            foreach (char ch in word)
            {
                if (!node.containsKey(ch))
                {
                    node.put(ch, new TrieNode());
                }
                node = node.getChild(ch);
            }
        }

        public bool Search(string word)
        {
            TrieNode node = searchPrefix(word);
            return node != null && node.isEnd();
        }

        private TrieNode searchPrefix(string word)
        {
            TrieNode node = root;
            foreach (char ch in word)
            {
                if (node.containsKey(ch))
                {
                    node = node.getChild(ch);
                }
                else
                {
                    return null;
                }
            }
            return node;
        }
    }
}
