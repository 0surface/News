using Newtonsoft.Json;
using System.Collections.Generic;

namespace News.Service.Model
{
    public class Node
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("parent")]
        public string Parent { get; set; }
        [JsonProperty("children")]
        public List<Node> Children { get; set; }

        public Node(string name, string parent, List<Node> children)
        {
            Name = name;
            Parent = parent;
            Children = children;
        }

        public Node(string name, string parent)
        {
            Name = name;
            Parent = parent;
            Children = null;
        }
    }
}
