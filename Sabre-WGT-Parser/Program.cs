using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabre_WGT_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            WGTFile w = new WGTFile("Annie.wgt");

            Console.WriteLine("> Magic : " + w.hd.Magic);
            Console.WriteLine("> Version : " + w.hd.Version);
            Console.WriteLine("> ID : " + w.hd.ID);
            Console.WriteLine("> Weight Count : " + w.hd.WeightCount);
            Console.WriteLine();
            foreach(var we in w.Weights)
            {
                Console.WriteLine("> ID : " + we.BoneID);
                Console.WriteLine("> Weight : " + we.WeightValue[0] + ", " + we.WeightValue[1] + ", " + we.WeightValue[2]);
                Console.WriteLine("> Zero : " + we.Zero);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
