using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2020.BinaryTree
{
    /// <summary>
    /// All nodes of left subtree are less than the root node 
    /// All nodes of right subtree are more than the root node Both subtrees of each node are also BSTs 
    /// i.e. they have the above two properties
    /// Algorithm for searching is as follows:
    /// 
    /// If root == NULL 
    /// return NULL;
    /// If number == root->data 
    /// return root->data;
    /// If number<root->data 
    /// return search(root->left)
    /// If number > root->data 
    /// return search(root->right)
    /// 
    /// 
    /// 
    /// ALGORITHM FOR INSERTION INTO A TREE IS AS FOLLOWS:
    /// If node == NULL 
    /// return createNode(data)
    /// if (data<node->data)
    /// node->left  = insert(node->left, data);
    /// else if (data > node->data)
    /// node->right = insert(node->right, data);  
    /// return node;
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; set; }
        private static StringBuilder inoderString;
        public string InoderString => inoderString.ToString();
        public BinarySearchTree()
        {
            Root = null;
            inoderString = new StringBuilder();
        }
        private static TreeNode<T> InsertUtil(TreeNode<T> root, T data)
        {
            if (root is null)
                return new TreeNode<T>(data);
            if (root.Data.CompareTo(data) > 0)
            {
                //then root node value is greater, so Insert to the right
                root.Left = InsertUtil(root.Left, data);
            }
            else
            {
                root.Right = InsertUtil(root.Right, data);
            }
            return root;
        }
        public void Insert(T data) => (Root) = InsertUtil(Root, data);
        public BinarySearchTree<T> Insertbuilder(T data)
        {
            this.Insert(data);
            return this;
        }
        private static T GetInOrderSuccessor(TreeNode<T> root)
        {
            T minValue = root.Data;
            while (root.Left != null)
            {
                minValue = root.Left.Data;
                root = root.Left;
            }
            return minValue;
        }

        private static TreeNode<T> DeleteUtil(TreeNode<T> root, T key)
        {
            if (root is null) return root;

            if (root.Data.CompareTo(key) < 0)
                root.Right = DeleteUtil(root.Right, key);
            else if (root.Data.CompareTo(key) > 0)
                root.Left = DeleteUtil(root.Left, key);
            else
            {
                // we have found the key ie root.Data.CompareTo(key) ==0
                if (root.Left is null)
                    return root.Right;
                if (root.Right is null)
                    return root.Left;

                // If the node has two children
                // Place the inorder successor in position of the node to be deleted

                root.Data = GetInOrderSuccessor(root.Right);
                // delete the inOrder successor
                root.Right = DeleteUtil(root.Right, key);


            }

            return root;

        }

        public void DeleteKey(T key) => (Root) = DeleteUtil(Root, key);

        /// <summary>
        /// InOrder traversal traverses the tree int the order: left -> root -> right
        /// </summary>
        /// <param name="root"></param>
        public string InorderTraversal()  {
            ClearString();
            return InorderTraversalUtil(Root); 
        }
        public string InorderTraversal(TreeNode<T> root) => InorderTraversalUtil(root);
        private static string InorderTraversalUtil(TreeNode<T> root)
        {
            
            if (root != null)
            {
                InorderTraversalUtil(root.Left);
                var str = $"{root.Data};";
                inoderString.Append(str);
                Console.Write(str);
                InorderTraversalUtil(root.Right);
            }
            return inoderString.ToString();
        }

        private static void ClearString() => (inoderString) = new StringBuilder();
    }
}
