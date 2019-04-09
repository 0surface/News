using News.Types.D3Tree;
using News.Types.Website;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Util.D3Tree
{
    public class D3TreeNodeMaker
    {
        public static Func<string, string, List<D3TreeNode>, D3TreeNode> ConstructNode;
        public static Func<List<string>, List<D3TreeNode>> GetNodesFromStringList;

        public static int InjectDependencies()
        {
            ConstructNode = _ConstructNode();
            GetNodesFromStringList = _GetNodesFromStringList();

            return 0;
        }

        private static Func<string, string, List<D3TreeNode>, D3TreeNode> _ConstructNode()
            =>  (name, parent, nodeList) =>
            {
                try
                {
                    D3TreeNode node = new D3TreeNode(name, parent);

                    if(nodeList != null && nodeList.Count > 0)
                    {
                        nodeList.ForEach(x => x.Parent = name);
                    }
                    node.Children = nodeList;

                    return node;
                }
                catch (Exception)
                {
                    return D3TreeNode.Empty();
                }
            };

        private static Func<List<string>, List<D3TreeNode>> _GetNodesFromStringList()
          => (stringList) =>
          {
              try
              {
                  List<D3TreeNode> nodes = new List<D3TreeNode>();

                  if (stringList != null && stringList.Count > 0)
                  {
                      foreach (var item in stringList)
                      {
                          nodes.Add(new D3TreeNode(item, ""));
                      }
                  }

                  return nodes;
              }
              catch (Exception)
              {
                  return new List<D3TreeNode>();
              }
          };               
    }
}
