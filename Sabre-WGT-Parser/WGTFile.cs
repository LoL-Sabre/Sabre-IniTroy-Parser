using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sabre_WGT_Parser
{
    class WGTFile
    {
        public BinaryReader br;
        public Header hd;
        public List<Weight> Weights = new List<Weight>();
        public WGTFile(string fileLocation)
        {
            br = new BinaryReader(File.Open(fileLocation, FileMode.Open));
            hd = new Header(br);
            for(int i = 0; i < hd.WeightCount; i++)
            {
                Weights.Add(new Weight(br));
            }
        }
        public class Header
        {
            public string Magic;
            public UInt32 Version;
            public UInt32 ID;
            public UInt32 WeightCount;
            public Header(BinaryReader br)
            {
                Magic = Encoding.ASCII.GetString(br.ReadBytes(8));
                Version = br.ReadUInt32();
                ID = br.ReadUInt32();
                WeightCount = br.ReadUInt32();
            }
        }
        public class Weight
        {
            public UInt32 BoneID;
            public float[] WeightValue = new float[3];
            public UInt32 Zero;
            public Weight(BinaryReader br)
            {
                BoneID = br.ReadUInt32();
                for(int i = 0; i < 3; i++)
                {
                    WeightValue[i] = br.ReadSingle();
                }
                Zero = br.ReadUInt32();
            }
        }
    }
}
