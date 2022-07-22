using System;
using System.Collections.Generic;
using System.Text;

namespace AllDataStructures.Others
{
    //can we also implement stack using simple array?
    public class Kadanes
    {
        public  int FindBestSubsequence(int[] Array)
        {
            int max_sum = 0;
            int current_sum = 0;
            int n = Array.Length;
            for (int i = 0; i < n; i++)
            {
                current_sum = current_sum + Array[i];
                
                if (current_sum < 0)
                { current_sum = 0; }

                if (max_sum < current_sum)
                {
                    
                    max_sum = current_sum; 
                }
            }
            return max_sum;
        }
        public void Start()
        {
            // - value set to zeo
            int[] array =  {  -2, -3, 4, -1, -2, 1, 5, -3 } ;
            
            decimal total = FindBestSubsequence(array);

        }
    }
}
