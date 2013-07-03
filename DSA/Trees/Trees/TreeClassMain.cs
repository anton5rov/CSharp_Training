using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
    class TreeClassMain
    {
        static void Main(string[] args)
        {
            int N = 7;
            TreeWithDictionary<int> tree = new TreeWithDictionary<int>(2, 4);
            tree.AddPair(3, 2);
            tree.AddPair(5, 0);
            tree.AddPair(3, 5);
            tree.AddPair(5, 6);
            tree.AddPair(5, 1);            

            // Task 1.
            var allChildren = new List<TreeNode<int>>();

            foreach (var list in tree.Nodes.Values)
            {
                foreach (var child in list)
                {
                    allChildren.Add(child);
                }
            }

            TreeNode<int> root = new TreeNode<int>();
            for (int i = 0; i < N; i++)
            {
                bool rootFound = true;
                foreach (var item in allChildren)
                {
                    if (item.Value == i)
                    {
                        rootFound = false;
                        break;
                    }
                }
                if (rootFound == true)
                {
                    root.Value = i;
                    break;
                }
            }
            
            Console.WriteLine("The root is: {0}", root.Value);

            //Task 2.
            var leafs = new List<int>();
            foreach (var edge in tree.Nodes)
            {
                if (edge.Value.Count == 0)
                {
                    leafs.Add(edge.Key);
                }
            }

            Console.WriteLine("Leafs are: {0}", string.Join(", ", leafs));

            // Task 3.
            var middleNodes = new List<int>();
            foreach (var edge in tree.Nodes)
            {
                if (edge.Key != root.Value && edge.Value.Count > 0)
                {
                    middleNodes.Add(edge.Key);
                }
            }

            Console.WriteLine("Middle nodes are: {0}", string.Join(", ", middleNodes));

            // task 4.
            int maxPath = 0;
            maxPath = FindMaxPath(tree, root.Value);
            Console.WriteLine("Max path in the tree: {0}", maxPath);

            // task 5.
            int sum = 6;
            List<Path<int>> allPaths = new List<Path<int>>();

            FindAllPaths(tree, root, allPaths);
            Console.WriteLine("Paths with sum {0} found:", sum);
            foreach (var path in allPaths)
            {
                if (path.GetSumAsInt32() == sum)
                {
                    Console.WriteLine("{0}; Sum: {1}", path.ToString(), path.GetSumAsInt32());
                }
            }

            // task 6.

            sum = 9;
            List<TreeWithDictionary<int>> treesWithGivenSum = new List<TreeWithDictionary<int>>();
            foreach (var path in allPaths)
            {
                if (path.GetSumAsInt32() == sum)
                {
                    TreeWithDictionary<int> treeFound = new TreeWithDictionary<int>(path.Nodes[0].Value);
                    for (int i = 1; i < path.Nodes.Count; i++)
                    {
                        treeFound.AddPair(path.Nodes[i - 1].Value, path.Nodes[i].Value);
                    }

                    treesWithGivenSum.Add(treeFound);
                }
            }

            foreach (var treeWithSumS in treesWithGivenSum)
            {
                Console.WriteLine(treeWithSumS);
            }
        }

        private static void FindAllPaths(TreeWithDictionary<int> tree, TreeNode<int> root, List<Path<int>> allPaths)
        {
            foreach (var path in AllPathsFromNode(tree, root))
            {
                allPaths.Add(path);
            }

            foreach (var child in tree.Nodes[root.Value])
            {
                FindAllPaths(tree, child, allPaths);
            }
        }

        private static List<Path<int>> AllPathsFromNode(TreeWithDictionary<int> tree, TreeNode<int> node)
        {
            List<Path<int>> result = new List<Path<int>>();
            result.Add(new Path<int>(node));
            foreach (var child in tree.Nodes[node.Value])
            {
                foreach (var path in AllPathsFromNode(tree, child))
                {
                    Path<int> childSubPath = new Path<int>(node);
                    childSubPath.AddSubPath(path);
                    result.Add(childSubPath);
                }
            }

            return result;
        }

        private static int FindMaxPath(TreeWithDictionary<int> tree, int rootValue)
        {
            if (tree.Nodes[rootValue].Count == 0)
            {
                return 0;
            }

            int maxPathFound = 0;
            foreach (var node in tree.Nodes[rootValue])
            {
                maxPathFound = Math.Max(maxPathFound, FindMaxPath(tree, node.Value));
            }
            return maxPathFound + 1;
        }

        
    }
}
