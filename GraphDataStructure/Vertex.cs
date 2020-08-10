using System;

namespace GraphDataStructure
{
    public class Vertex
    {
        public bool wasVisited { get; set; }
        public string Label { get; set; }

        public Vertex(string label)
        {
            Label = label;

        }
    }
}
