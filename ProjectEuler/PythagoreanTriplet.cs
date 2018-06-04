using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class PythagoreanTriplet
    {
        public static int Solution()
        {
            int answer = 0;

            for(int i = 2; i < 30; i++)
            {
                for (int j = 2; j < 30; j++)
                {
                    for (int k = 2; k < 30; k++)
                    {
                        if((i * i) + (j * j) == (k * k))
                        {
                            int h = 0;
                        }
                    }
                }
            }

            return answer;
        }
    }
}
