using System;
using System.Collections.Generic;
using System.Linq;

namespace Omino.Utils
{
    public class BlockHash : IComparable<BlockHash>
    {
        private List<int> hash;

        public BlockHash(Block block)
        {
            Block tempBlock = block;
            List<int> tempHash = FlattenList(block.Pixels);
            for (int i = 0; i < 3; i++)
            {
                tempBlock = tempBlock.GetRotated();
                List<int> nextHash = FlattenList(tempBlock.Pixels);
                if (Compare(tempHash, nextHash) < 0)
                {
                    tempHash = nextHash;
                }
            }

            hash = tempHash;
        }

        public static int Compare(List<int> hash1, List<int> hash2)
        {
            if (hash1.Count != hash2.Count) return hash1.Count - hash2.Count;
            for (int i = 0; i < hash1.Count; i++)
            {
                if(hash1[i] == hash2[i]) continue;
                return hash1[i] - hash2[i];
            }
            
            return 0;
        }

        private static List<int> FlattenList(List<Pixel> coords)
        {
            List<int> list = new List<int>();
            foreach (var coord in coords)
            {
                list.Add(coord.X);
                list.Add(coord.Y);
            }

            return list;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if(obj is BlockHash)
                return Compare(this.hash, (obj as BlockHash).hash)==0;
            return false;
        }

        public override int GetHashCode()
        {
            int hc = hash.Count;
            for (int i = 0; i < hash.Count; i++)
            {
                hc = unchecked(hc * 119 + hash[i]);
            }

            return hc;
        }

        public int CompareTo(BlockHash other)
        {
            return Compare(this.hash, other.hash);
        }
    }
}