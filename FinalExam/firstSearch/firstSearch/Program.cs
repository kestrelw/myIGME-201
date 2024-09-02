#define DIGRAPH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Threading;

namespace firstSearch
{
    enum Color
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Purple,
        Grey
    }

    internal class Program
    {
#if DIGRAPH

        static int[,] mGraph = new int[,]
        {
           { -1   , -1   , -1   , -1   , -1   , 1    , -1   , 5   },
           { -1   , -1   , -1   , -1   , -1   , -1   , 1    , -1  },
           { -1   , -1   , -1   , 6    , -1   , -1   , -1   , -1  },
           { -1   , -1   , -1   , -1   , -1   , -1   , -1   , -1  },
           { -1   , -1   , -1   , -1   , -1   , 1    , -1   , 0   },
           { -1   , -1   , 8    , -1   , 1    , -1   , -1   , -1  },
           { -1   , -1   , 1    , -1   , -1   , -1   , -1   , -1  },
           { -1   , 1    , -1   , -1   , 0    , -1   , -1   , -1 }
        };
                 // Red     Orange    Yellow   Green     Blue    Indigo   Purple   Grey
        /* Red    { null   , null   , null   , null   , null   , 1      , null   , 5    },
        * Orange  { null   , null   , null   , null   , null   , null   , 1      , null },
        * Yellow  { null   , null   , null   , 6      , null   , null   , null   , null },
        * Green   { null   , null   , null   , null   , null   , null   , null   , null },
        * Blue    { null   , null   , null   , null   , null   , 1      , null   , 0    },
        * Indigo  { null   , null   , 8      , null   , 1      , null   , null   , null },
        * Purple  { null   , null   , 1      , null   , null   , null   , null   , null },
        * Grey    { null   , 1      , null   , null   , 0      , null   , null   , null }
        */

        static int[][] lGraph = new int[][]
        {
            new int[] { (int)Color.Red, (int)Color.Indigo, (int)Color.Grey},
            new int[] { (int)Color.Orange, (int)Color.Purple },
            new int[] { (int)Color.Yellow, (int)Color.Green},
            //new int[] { (int)Color.Green },
            new int[] { (int)Color.Blue, (int)Color.Indigo/*, (int)Color.Grey */},
            new int[] { (int)Color.Indigo, (int)Color.Yellow, (int)Color.Blue },
            new int[] { (int)Color.Purple, (int)Color.Yellow },
            new int[] { (int)Color.Grey, (int)Color.Orange/*, (int)Color.Blue */}
        };

        static int[][] wGraph = new int[][]
        {
            new int[] { 1, 5},
            new int[] { 1 },
            new int[] { 6 },
            //new int[] { },
            new int[] { 1/*, 0*/},
            new int[] { 8, 1 },
            new int[] { 1 },
            new int[] { 1/*, 0 */}
        };


#endif
        static List<Node> game = new List<Node>();
        // variable to request DFS() AI for next move
        //static bool bWaitingForMove = false;

        // the current numeric representation of the coin state
        static int nState = (int)Color.Red;

        // the user-entered string representation of the desired coin state
        //static string sUserState;

        // mutex (mutual exclusive lock) which will give exclusive access to bWaitingForMove
        static object lockObject = new object();

        static void Main(string[] args)
        {
            Random rand = new Random();
            Node node;

            node = new Node((int)Color.Red);
            game.Add(node);

            node = new Node((int)Color.Orange);
            game.Add(node);

            node = new Node((int)Color.Yellow);
            game.Add(node);

            node = new Node((int)Color.Green);
            game.Add(node);

            node = new Node((int)Color.Blue);
            game.Add(node);

            node = new Node((int)Color.Indigo);
            game.Add(node);

            node = new Node((int)Color.Purple);
            game.Add(node);

            node = new Node((int)Color.Grey);
            game.Add(node);

            game[(int)Color.Red].AddEdge(1, game[(int)Color.Indigo]);
            game[(int)Color.Red].AddEdge(5, game[(int)Color.Grey]);
            game[(int)Color.Red].edges.Sort();

            game[(int)Color.Orange].AddEdge(1, game[(int)Color.Purple]);
            game[(int)Color.Orange].edges.Sort();

            game[(int)Color.Yellow].AddEdge(6, game[(int)Color.Green]);
            game[(int)Color.Yellow].edges.Sort();

            game[(int)Color.Blue].AddEdge(1, game[(int)Color.Indigo]);
            game[(int)Color.Blue].AddEdge(0, game[(int)Color.Grey]);
            game[(int)Color.Blue].edges.Sort();

            game[(int)Color.Indigo].AddEdge(8, game[(int)Color.Yellow]);
            game[(int)Color.Indigo].AddEdge(1, game[(int)Color.Blue]);
            game[(int)Color.Indigo].edges.Sort();

            game[(int)Color.Purple].AddEdge(1, game[(int)Color.Yellow]);
            game[(int)Color.Purple].edges.Sort();

            game[(int)Color.Grey].AddEdge(1, game[(int)Color.Orange]);
            game[(int)Color.Grey].AddEdge(0, game[(int)Color.Blue]);
            game[(int)Color.Grey].edges.Sort();

            // the current string representation of the color state
            string sState;


            // create thread running DFS() for AI fetching the next move
            Thread t = new Thread(DFS);

            t.Start();

            // while not all visited
            while (game.Any(Color => !Color.visited))
            {
                // convert the current numeric state to a string
                sState = ((Color)nState).ToString();

                // output the current state
                //Console.WriteLine("Current color: "+sState);


#if USE_MATRIX

#else

            }


#endif
            t.Abort();
        }

        static void DFSUtil(int v, bool[] visited)
        {

            visited[v] = true;

            string colorName = ((Color)v).ToString();
            Console.WriteLine(colorName);

            // Recur for all the vertices 
            // adjacent to this vertex if there are any
            int[] thisStateList = lGraph[v];
            //Console.WriteLine("thisStateList: " + thisStateList);

            if (thisStateList != null)
            {
                //Console.WriteLine("thisStateList length: " + thisStateList.Length);
                foreach (int n in thisStateList)
                {
                    //Console.WriteLine("int n in thisStateList: "+n);
                    //Console.WriteLine("194 "+((Color)n).ToString());
                    if (!visited[n])
                    {
                        DFSUtil(n, visited);
                    }
                }
            }
        }

        // The function to do DFS traversal. 
        // It uses recursive DFSUtil() 
        static void DFS()
        {
            // Mark all the vertices as not visited 
            // (set as false by default in c#) 
            bool[] visited = new bool[lGraph.Length];

            // Call the recursive helper function 
            // to print DFS traversal 
            DFSUtil((int)Color.Red, visited);
        }

    }

    public class Node : IComparable<Node>
    {
        public int nState;
        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int nState)
        {
            this.nState = nState;
            this.minCostToStart = int.MaxValue;
        }

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }
    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }
}
