using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class TrieNode
    {
        private TrieNode[] link;
        private bool _isEnd;
        private int R = 26;

        //Initialize TrieNode
        public TrieNode()
        {
            link = new TrieNode[R];
        }

        //Check if character is in the current prefix
        public bool containsKey(char ch)
        {
            return link[ch - 'a'] != null;
        }

        //Get current character present in the trie prefix path
        public TrieNode get(char ch)
        {
            return link[ch - 'a'];
        }

        //Check if current node is the last node of the link
        public bool isEnd()
        {
            return this._isEnd;
        }

        //Set end for current link if last char found for key
        public void setEnd()
        {
            this._isEnd = true;
        }

        //Add character to current link if doesn't exist
        public void put(char ch, TrieNode node)
        {
            link[ch - 'a'] = node;
        }
    }
}
