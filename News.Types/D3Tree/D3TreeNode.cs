using Newtonsoft.Json;
using System.Collections.Generic;

namespace News.Types.D3Tree
{
    public class D3TreeNode
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("parent")]
        public string Parent { get; set; }
        [JsonProperty("children")]
        public List<D3TreeNode> Children { get; set; }

        public D3TreeNode(string name, string parent, List<D3TreeNode> children)
        {
            Name = name;
            Parent = parent;
            Children = children;
        }

        public D3TreeNode(string name, string parent)
        {
            Name = name;
            Parent = parent;
            Children = null;
        }

        public static D3TreeNode Empty() => new D3TreeNode("", "");
        
    }
}
