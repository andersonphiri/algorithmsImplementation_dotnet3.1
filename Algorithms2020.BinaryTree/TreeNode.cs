using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2020.BinaryTree
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

      
    }
}
