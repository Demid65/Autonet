using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet
{
    class PathFinder
    {

        public CGraph Graph;
        
        public void LoadGraph(CGraph G)
        {
            Graph = G;
        }

        public Stack<int> Pathfind(int Start, int End)
        {
            Stack<int> Stack = new Stack<int>();
            Stack.Push(Start);
            int i = 0;

            while (Stack.Count > 0)
            {
                if (Stack.Contains(End))
                {
                    return Stack;
                }

                for (; i < sizeof(CGraph.Points); i++)
                    if (!Stack.Contains(i) && Graph.Connections[Stack.Peek(), i].Cost >= 0)
                    {
                        Stack.Push(i);
                        i = 0;
                        goto x;
                    }

                x:;



            }

            return null;

        }

        public List<CManuever> GetManueverMap(Stack<int> stk)
        {
            
            int[] arr = new int[stk.ToArray().Length];
            int c = 0;
            for (int i = stk.ToArray().Length - 1; i >= 0; i--)
            {
                arr[c] = stk.ToArray()[i];
                c++;
            }
            List<CManuever> MMap = new List<CManuever>();
            for (int i = 0; i <= arr.Length - 2; i++)
            {
                MMap.Add(Graph.Connections[arr[i], arr[i + 1]].Manuever);
            }

            return MMap;

        }







    }

}
