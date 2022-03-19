//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LeetCodeCard.Trie
//{
//    public class ReplaceWords
//    {
//        private TrieNode root;
//        public ReplaceWords()
//        {
//            this.root = new TrieNode();
//        }
//        public string ReplaceWordsWithRoot(IList<string> dictionary, string sentence)
//        {

//            StringBuilder sb = new StringBuilder();
//            //Build Trie from given dictionary of roots
//            foreach (string word in dictionary)
//            {
//                //Insert each root from dictionary into trie
//                this.Insert(word);
//            }

//            string[] successorList = sentence.Split(' ');

//            foreach (string word in successorList)
//            {
//                sb.Append(this.SearchRoot(word));
//                sb.Append(" ");
//            }

//            return sb.ToString().Trim();
//        }

//        //Search for successor roots
//        public string SearchRoot(string word)
//        {
//            TrieNode node = root;
//            foreach (char ch in word)
//            {
//                if (node.containsKey(ch))
//                {
//                    node = node.getChild(ch);
//                    if (node.isRoot())
//                    {
//                        return node.getRootValue();
//                    }
//                }
//                else
//                {
//                    break;
//                }
//            }
//            return word;
//        }
//        //Method to build trie
//        public void Insert(string word)
//        {
//            TrieNode node = root;
//            foreach (char ch in word)
//            {
//                if (!node.containsKey(ch))
//                {
//                    node.put(ch, new TrieNode());
//                    node = node.getChild(ch);
//                }
//            }
//            node.setRoot();
//            node.setEnd();
//            node.setRootValue(word);
//        }
//    }

//    //public class TrieNode
//    //{
//    //    private int R = 26;
//    //    private TrieNode[] children;
//    //    private bool _isRoot;
//    //    private bool _isEnd;
//    //    private string rootValue;

//    //    public TrieNode()
//    //    {
//    //        this.children = new TrieNode[R];
//    //    }

//    //    public void put(char ch, TrieNode node)
//    //    {
//    //        this.children[ch - 'a'] = node;
//    //    }

//    //    public bool containsKey(char ch)
//    //    {
//    //        if (ch - 'a' > 0)
//    //        {
//    //            return this.children[ch - 'a'] != null;
//    //        }
//    //        else
//    //        {
//    //            return false;
//    //        }
//    //    }

//    //    public TrieNode getChild(char ch)
//    //    {
//    //        return this.children[ch - 'a'];
//    //    }

//    //    public void setEnd()
//    //    {
//    //        this._isEnd = true;
//    //    }

//    //    public bool isEnd()
//    //    {
//    //        return this._isEnd;
//    //    }

//    //    public void setRoot()
//    //    {
//    //        this._isRoot = true;
//    //    }

//    //    public bool isRoot()
//    //    {
//    //        return this._isRoot;
//    //    }

//    //    public void setRootValue(string root)
//    //    {
//    //        this.rootValue = root;
//    //    }

//    //    public string getRootValue()
//    //    {
//    //        return this.rootValue;
//    //    }
//    //}
//}
