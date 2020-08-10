using System;

namespace Algorithms2020.BinaryTree
{
    public class BinaryTree<T> where T: IComparable<T>
    {
        public TreeNode<T> Root { get; set;}
        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(T data)
        {
            Root = new TreeNode<T>(data);
        }
        public void PostOrder(TreeNode<T> node)
        {
            if (node is null)
                return;
            else
            {
                //trav left
                PostOrder(node.Left);
                //traverse right
                PostOrder(node.Right);
                //traverse root
                Console.Write($"{node.Data}->\t");
            }
            
        }

        public void InOrder(TreeNode<T> node)
        {
            if (node is null)
                return;
            //traverse left
            InOrder(node.Left);
            //traverse root
            Console.Write($"{node.Data}->\t");
            //then traveser right
            InOrder(node.Right);


        }

        public void PreOrder(TreeNode<T> node)
        {
            if (node is null)
                return;
            //traverse root
            Console.Write($"{node.Data}->\t");
            //traverse left
            InOrder(node.Left);
            //then traveser right
            InOrder(node.Right);


        }
        #region Properties
        
        private static int GetHeightUtil(TreeNode<T> node)
        {
            if (node is null) return 0;
            int left, right;
            left = GetHeightUtil(node.Left);
            right = GetHeightUtil(node.Right);

            return Math.Max(left, right) + 1;
        }
        /// <summary>
        /// The height of a node is the number of edges from that node to the deapest leaf
        /// it is basically the max of all possible paths from that node to the leaf
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetHeight(TreeNode<T> node) => GetHeightUtil(node);
        

        private static int DepthUtil(TreeNode<T> node)
        {
            int d = 0;
            while (node != null)
            {
                d++;
                node = node.Left;
            }
            return d;
        }
        /// <summary>
        /// The depth of the node is the height or number of edges from root to that node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int Depth(TreeNode<T> node) => DepthUtil(node);
        private static int CountNodesUtil(TreeNode<T> root)
        {
            if (root is null) return 0;
            if (root.Left is null && root.Right is null) return 1;
            return (1 + CountNodesUtil(root.Left) + CountNodesUtil(root.Right));
        }
        public int CountNodes(TreeNode<T> root) => CountNodesUtil(root);
        

        #endregion

        #region Checkings
        private static bool CheckCompleteUtil(TreeNode<T> root, int index, int numberNodes)
        {
            if (root is null) return true;
            if (index > numberNodes) return false;
            return (CheckCompleteUtil(root.Left, 2 * index + 1, numberNodes) && CheckCompleteUtil(root.Left, 2 * index + 2, numberNodes));
        }
        public bool CheckComplete(TreeNode<T> root, int index, int numberNodes) => CheckCompleteUtil(root, index, numberNodes);

        /// <summary>
        /// A full Binary tree is a special type of binary tree in which every parent node/internal node has either two or no children.
        /// THEOREMS:
        /// Let, i = the number of internal nodes
        /// n = be the total number of nodes
        /// l = number of leaves
        /// λ = number of levels
        /// 
        /// The number of leaves is i + 1.
        /// The total number of nodes is 2i + 1.
        /// The number of internal nodes is (n – 1) / 2.
        /// The number of leaves is (n + 1) / 2.
        /// The total number of nodes is 2l – 1.
        /// The number of internal nodes is l – 1.
        /// The number of leaves is at most 2^λ - 1.
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsFullBinaryTree(TreeNode<T> node)
        {
            if (node is null) return true;
            if (node.Left is null && node.Right is null) return true;
            if (node.Left != null && node.Right != null) return IsFullBinaryTree(node.Left) && IsFullBinaryTree(node.Right);
            return false;
        }
        private static bool IsPerfectUtil(TreeNode<T> root, int depth, int level)
        {
            if (root is null) return true;
            if (root.Left is null && root.Right is null)
                return depth == level + 1;
            if (root.Left is null || root.Right is null) return false;
            return IsPerfectUtil(root.Left, depth, level + 1) && IsPerfectUtil(root.Right, depth, level + 1);
        }
        /// <summary>
        /// A perfect binary tree is a type of binary tree in which every internal node has exactly two child nodes 
        /// and all the leaf nodes are at the same level.
        /// THEOREMS:
        /// A perfect binary tree of height h has 2^(h + 1) – 1 node.
        /// A perfect binary tree with n nodes has height log(n + 1) – 1 = Θ(ln(n)).
        ///A perfect binary tree of height h has 2^h leaf nodes.
        ///The average depth of a node in a perfect binary tree is Θ(ln(n))
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsPerfect(TreeNode<T> root)
        {
            var depth = DepthUtil(root);
            return IsPerfectUtil(root, depth, 0);
        }

        private static bool IsBalancedUtil(TreeNode<T> root, Height height)
        {
            if (root is null)
            {
                height.HeightProperty = 0;
                return true;
            }
            Height leftHeightEight =new Height(); 
            Height rightHeightEight = new Height();
            bool left = IsBalancedUtil(root.Left, leftHeightEight);
            bool right = IsBalancedUtil(root.Right, rightHeightEight);
            int leftHeight = leftHeightEight.HeightProperty;
            int rightHeight = rightHeightEight.HeightProperty;
            height.HeightProperty = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
            if (ModulusFunc(leftHeight, rightHeight) >= 2) return false;
            return left && right;
        }
        public bool IsBalanced(TreeNode<T> root, Height height) => IsBalancedUtil(root, height);

        private static int ModulusFunc(int x, int y) => x >= y ? x - y : y - x;

        #endregion

    }
}
