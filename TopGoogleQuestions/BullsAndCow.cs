using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class BullsAndCow
    {
        public string GetHint(string secret, string guess)
        {
            int aCount = 0;
            int bCount = 0;
            StringBuilder sb = new StringBuilder();
            int[] secretCharCount = new int[10];
            int[] guessCharCount = new int[10];

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    aCount++;
                }
                else
                {
                    secretCharCount[secret[i] - '0']++;
                    guessCharCount[guess[i] - '0']++;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                bCount += Math.Min(secretCharCount[i], guessCharCount[i]);
            }

            sb.Append(aCount);
            sb.Append('A');
            sb.Append(bCount);
            sb.Append('B');
            return sb.ToString();
        }
    }
}
