using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class FindAndReplaceString
    {
        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            Dictionary<int, (int, string)> map = new Dictionary<int, (int, string)>();
            for (int i = 0; i < indices.Length; i++){
                if (s.Substring(indices[i], sources[i].Length).Equals(sources[i]))
                {
                    //Create a map for given index with target string to replac with length of source string
                    map.TryAdd(indices[i], new (sources[i].Length, targets[i]));
                }
            }

            StringBuilder sb = new StringBuilder();

            int c = 0;

            while (c < s.Length)
            {
                if (map.ContainsKey(c))
                {
                    sb.Append(map[c].Item2);
                    c += map[c].Item1;
                }
                else
                {
                    sb.Append(s[c]);
                    c++;
                }
            }

            return sb.ToString();
        }
    }
}
