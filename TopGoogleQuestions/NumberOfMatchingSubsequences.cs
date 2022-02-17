using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class  NumberOfMatchingSubsequences
    {
        #region Trie Implementation
        public int NumMatchingSubseq(string s, string[] words)
        {
            //Build Trie using given words
            int count = 0;
            if (s == null || s.Length == 0)
            {
                return count;
            }

            string aa = "avc";
            aa.ToCharArray();
            TrieNode root = buildTrie(s);

            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            //Check word frequency in current words array for pruning
            foreach (string word in words)
            {
                wordFrequency.TryAdd(word, 0);
                wordFrequency[word] += 1;
            }
            foreach (string word in wordFrequency.Keys)
            {
                //Check if current word is a substring of string s using Trie
                if (isSubsequence(root, word))
                {
                    count += wordFrequency[word];
                }
            }

            return count;
        }

        private bool isSubsequence(TrieNode root, string word)
        {
            TrieNode currentNode = root;
            foreach (char ch in word)
            {
                if (currentNode.containsKey(ch))
                {
                    currentNode = currentNode.get(ch);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //Build Trie
        private TrieNode buildTrie(string s)
        {
            TrieNode root = new TrieNode();
            TrieNode currentNode = root;
            foreach (char ch in s)
            {
                if (!currentNode.containsKey(ch))
                {
                    currentNode.put(ch, new TrieNode());
                }
                currentNode = currentNode.get(ch);
            }
            currentNode.setEnd();
            return root;
        }
        #endregion

        #region Modified Trie with Buckets
        public int NumMatchingSubseqModified(string s, string[] words)
        {
            int ans = 0;

            //Initialize heads array
            //Heads array will hold list of Nodes with word and their characters at respective character position
            List<Node>[] heads = new List<Node>[26];

            //Fill array will new List initialized
            for (int i = 0; i < 26; i++)
            {
                heads[i] = new List<Node>();
            }

            //Store first character of each word in heads array along with the word
            //[a, bb, ace, acd] => heads[0] = {(a, 0), (ace, 0), (acd, 0)}
            //heads[1] => {(bb, 0)}
            foreach (string word in words)
            {

                heads[word[0] - 'a'].Add(new Node(word, 0));
            }

            //Iterate through each character in original word s
            foreach (char ch in s.ToCharArray())
            {
                List<Node> old_bucket = new List<Node>();
                old_bucket.AddRange(heads[ch - 'a']);
                //Initialize heads character bucket again
                heads[ch - 'a'] = new List<Node>();

                foreach (Node node in old_bucket)
                {
                    node.IncrementIndex();
                    if (node.GetIndex() == node.GetWordLength())
                    {
                        ans++;
                    }
                    else
                    {
                        heads[node.GetWord()[node.GetIndex()] - 'a'].Add(node);
                    }
                }
                old_bucket.Clear();
            }
            return ans;
        }

        public class Node
        {
            private string _word;
            private int _index;
            public Node(string word, int idx)
            {
                this._word = word;
                this._index = idx;
            }

            public void IncrementIndex()
            {
                this._index++;
            }

            public int GetIndex()
            {
                return this._index;
            }

            public int GetWordLength()
            {
                return this._word.Length;
            }
            public string GetWord()
            {
                return this._word;
            }
        }
        #endregion
    }
}
