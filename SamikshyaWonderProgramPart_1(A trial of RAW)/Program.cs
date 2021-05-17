using System;
using System.Collections.Generic;

namespace SamikshyaWonderProgramPart_1_A_trial_of_RAW_
{


    // What about distance ???????????? 
    class Program
    {
        public static int ResidenceRequired(List<Dictionary<string, bool>> blocks, string[] requirements)
        {
            int[] maxdistancesbetweenblocks = new int[blocks.Count];
            Array.Fill(maxdistancesbetweenblocks, Int32.MinValue);

            for(int i=0; i<blocks.Count;i++)
            {
                foreach(string req in requirements)
                {
                    int closestdistance = Int32.MaxValue;
                    for(int j=0;j<blocks.Count;j++)
                    {
                        if(blocks[j][req])
                        {
                            closestdistance = Math.Min(closestdistance, distancebetween(i, j));
                        }
                    }
                    maxdistancesbetweenblocks[i] = Math.Max(maxdistancesbetweenblocks[i], closestdistance);

                }

            }
            return getreqsatminvalue(maxdistancesbetweenblocks);


        }

        private static int getreqsatminvalue(int[] array)
        {
            int reqatminvalue = 0;
            int minvalue = Int32.MaxValue;
            for(int i=0;i<array.Length;i++)
            {
                int currentvalue = array[i];
                if(currentvalue<minvalue)
                {
                    minvalue = currentvalue;
                    reqatminvalue = i;
                }
            }

            return reqatminvalue;
        }

        private static int  distancebetween(int i, int j)
        {
            return Math.Abs(i - j);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Dictionary<string, bool>> blocks =
            new List<Dictionary<string, bool>>();

            blocks.Insert(0, new Dictionary<string, bool>());
            blocks[0]["gym"] = false;
            blocks[0]["school"] = true;
            blocks[0]["store"] = false;

            blocks.Insert(1, new Dictionary<string, bool>());
            blocks[1]["gym"] = true;
            blocks[1]["school"] = false;
            blocks[1]["store"] = false;

            blocks.Insert(2, new Dictionary<string, bool>());
            blocks[2]["gym"] = true;
            blocks[2]["school"] = true;
            blocks[2]["store"] = false;

            blocks.Insert(3, new Dictionary<string, bool>());
            blocks[3]["gym"] = false;
            blocks[3]["school"] = true;
            blocks[3]["store"] = false;

            blocks.Insert(4, new Dictionary<string, bool>());
            blocks[4]["gym"] = false;
            blocks[4]["school"] = true;
            blocks[4]["store"] = true;

            string[] reqs = new string[] { "gym", "school", "store" };
            ResidenceRequired(blocks, reqs);
        }
    }
}
