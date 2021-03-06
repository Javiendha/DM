using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisjointSet
{
    public class Set
    {
        int[] parent;   //індекс батьківської вершини
        int[] rank;     //ранг конкретного вузла

        public Set(int length)
        {
            parent = new int[length];
            rank = new int[length];

            for (int i = 0; i < parent.Length; i++)
                parent[i] = i;
        }

        public void MakeSet(int x)
        {
            parent[x] = x; 
            rank[x] = 0;
        }

        public void Union(int x, int y)
        {
            int representativeX = FindSet(x);
            int representativeY = FindSet(y);

            if (rank[representativeX] == rank[representativeY])
            {
                rank[representativeY]++;
                parent[representativeX] = representativeY;
            }

            else if (rank[representativeX] > rank[representativeY])
            { parent[representativeY] = representativeX; }
            else
            { parent[representativeX] = representativeY; }
        }

        public int FindSet(int x)
        {
            if (parent[x] != x)
                parent[x] = FindSet(parent[x]);
            return parent[x];
        }

        public int FindImmidiateParent(int x)
        {
            return parent[x];
        }

        public int FindRank(int x)
        {
            return rank[x];
        }
    }
}
