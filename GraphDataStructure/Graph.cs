using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure
{
    public class Graph
    {
        private int _numberOfVertices;
        private int verticesCount;
        private ArrayList vertices;
        private int[,] adjMatrix;

        public Graph(int maxNumberOfVertices)
        {
            _numberOfVertices = maxNumberOfVertices;
            verticesCount = -1;
            adjMatrix = new int[_numberOfVertices, _numberOfVertices];
            vertices = new ArrayList();
            InitializeMatrix();
        }
        private void InitializeMatrix()
        {
            for (int i = 0; i < _numberOfVertices; i++)
            {
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    adjMatrix[i, j] = 0;
                }
            }
        }

        public void AddVertex(string label)
        {
            
            vertices.Insert(++this.verticesCount, new Vertex(label));
        }

        public void AddEdge(int start, int end)
        {
            adjMatrix[start, end] = 1;
            adjMatrix[ end, start] = 1;
        }
        public void ShowVertex(int v)
        {
            Console.Write(((Vertex)vertices[v]).Label);
        }

        public int NoSuccessors()
        {
            bool isEdge;
            for (int i = 0; i < _numberOfVertices; i++)
            {
                isEdge = false;
                for (int j = 0; j < _numberOfVertices; j++)
                {
                   if(adjMatrix[i, j] > 0)
                    {
                        isEdge = true;
                        break;
                    }
                }
                if (!isEdge)
                    return i;
            }

            return -1;

        }

        public void DeleteVertex(int vertexToDelete)
        {
            if (vertexToDelete != _numberOfVertices-1)
            {
                for (int j = vertexToDelete; j <= _numberOfVertices - 1; j++)
                    vertices[j] = vertices[j + 1];
                for (int row = vertexToDelete; row <= _numberOfVertices - 1; row++)
                    MoveRow(row, _numberOfVertices);
                for (int col = vertexToDelete; col < _numberOfVertices; col++)
                    MoveColumn(col, _numberOfVertices - 1);
            }
        }

        private void MoveRow(int row, int length)
        {
            for (int col = 0; col <= length - 1; col++)
                adjMatrix[row, col] = adjMatrix[row + 1, col];
        }
        private void MoveColumn(int col, int length)
        {
            for (int row = 0; row <= length - 1; row++)
                adjMatrix[row, col] = adjMatrix[row, col + 1];
        }
        public Stack<string> TopologicalSort()
        {
            Stack<string> result = new Stack<string>();
            while (_numberOfVertices > 0)
            {
                int currentVertex = NoSuccessors();
                if (currentVertex == -1)
                {
                    throw new InvalidOperationException("The graph has cycles");
                }
                result.Push(((Vertex)vertices[currentVertex]).Label);
                DeleteVertex(currentVertex);

            }
            return result;
        }
        public void PrintTopologicalSort()
        {
            var topSort = TopologicalSort();
            if (topSort.Count<1)
            {
                Console.WriteLine("Topological sort stack was empty");
            }
            Console.Write("Topological Sorting Order: ");
            while (topSort.Count > 0)
            {
                Console.Write(topSort.Pop() + "\t");
            }
        }
    }
}
