using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeCard.Trie
{
    public class WordSquare
    {
        private TrieNode root = null;
        private IList<IList<string>> result = new List<IList<string>>();
        private int N = 0;
        private string[] _words = null;
        public WordSquare()
        {
            this.root = new TrieNode();
        }
        public IList<IList<string>> WordSquares(string[] words)
        {

            this.N = words[0].Length;
            this._words = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                this._words[i] = words[i];
            }
            //Build Trie
            for (int i = 0; i < words.Length; ++i)
            {
                this.Insert(words[i], i);
            }

            foreach (string word in words)
            {
                LinkedList<string> wordSquare = new LinkedList<string>();
                wordSquare.AddLast(word);
                this.backtracking(1, wordSquare);
            }

            return result;
        }

        private void backtracking(int step, LinkedList<string> wordSquares)
        {
            //Base Case
            if (step == this.N)
            {
                string[] wordSq = new string[wordSquares.Count];
                wordSquares.CopyTo(wordSq, 0);
                result.Add(wordSq.ToList());
                return;
            }

            //a -> la -> lad
            StringBuilder prefix = new StringBuilder();

            foreach (string word in wordSquares)
            {
                prefix.Append(word[step]);
            }

            //Find word with prefix
            List<int> wordWithPrefix = SearchPrefix(prefix.ToString());

            foreach (int wordIndex in wordWithPrefix)
            {
                wordSquares.AddLast(this._words[wordIndex]);
                this.backtracking(step + 1, wordSquares);
                wordSquares.RemoveLast();
            }
        }


        public void Insert(string word, int index)
        {
            TrieNode node = root;
            foreach (char ch in word)
            {
                if (!node.containsKey(ch))
                {
                    node.put(ch, new TrieNode());
                }
                node = node.getChild(ch);
                node.addWordToList(index);
            }
            node.setEnd();
        }

        private List<int> SearchPrefix(string prefix)
        {
            TrieNode node = root;
            foreach (char ch in prefix)
            {
                if (node.containsKey(ch))
                {
                    node = node.getChild(ch);
                }
                else
                {
                    return new List<int>();
                }
            }
            return node.getWordList();
        }

    }

    public class TrieNode
    {
        private TrieNode[] children;
        private int R = 26;
        private bool _isEnd;
        private List<int> wordList;

        public TrieNode()
        {
            this.children = new TrieNode[R];
            this._isEnd = false;
            this.wordList = new List<int>();
        }

        public bool containsKey(char ch)
        {
            return this.children[ch - 'a'] != null;
        }

        public void put(char ch, TrieNode node)
        {
            this.children[ch - 'a'] = node;
        }

        public TrieNode getChild(char ch)
        {
            return this.children[ch - 'a'];
        }

        public void setEnd()
        {
            this._isEnd = true;
        }

        public bool isEnd()
        {
            return this._isEnd;
        }

        public void addWordToList(int idx)
        {
            this.wordList.Add(idx);
        }

        public List<int> getWordList()
        {
            return this.wordList;
        }
    }
}
