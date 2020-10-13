using System;
using System.Collections.Generic;
using System.Linq;

namespace tetris_trial
{
    public class BlockHash
    {
        private List<int> hash;

        public BlockHash(Block block)
        {
            Block tempBlock = block;
            List<int> tempHash = FlattenList(block.Coords);
            for (int i = 0; i < 3; i++)
            {
                tempBlock = tempBlock.GetRotated();
                List<int> nextHash = FlattenList(tempBlock.Coords);
                if (Compare(tempHash, nextHash) < 0)
                {
                    tempHash = nextHash;
                }
            }

            this.hash = tempHash;
        }

        private static int Compare(List<int> hash1, List<int> hash2)
        {
            for (int i = 0; i < hash1.Count; i++)
            {
                if(hash1[i] == hash2[i]) continue;
                return hash1[i] - hash2[i];
            }
            
            return 0;
        }

        private static List<int> FlattenList(List<Tuple<int, int>> coords)
        {
            List<int> list = new List<int>();
            foreach (var coord in coords)
            {
                list.Add(coord.Item1);
                list.Add(coord.Item2);
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
    }
}