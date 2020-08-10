using Algorithms2020.BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace Algorithms2020.UnitTestsAll
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        static readonly string inorder1 = "1;3;4;6;7;8;10;14;";
        static readonly string inorder2 = "1;3;4;6;7;8;14;";
        [TestMethod]
        public void TestInsertDeleteAndInorderTraversal()
        {
            var tree = BuildTree();

            Assert.AreEqual(inorder1, tree.InorderTraversal());
            tree.DeleteKey(10);
            Assert.AreEqual(inorder2, tree.InorderTraversal());

        }

        private static BinarySearchTree<int> BuildTree() => new BinarySearchTree<int>().Insertbuilder(8).Insertbuilder(3).Insertbuilder(1)
            .Insertbuilder(6).Insertbuilder(7).Insertbuilder(10).Insertbuilder(14).Insertbuilder(4);
    }
}
