namespace ListerUI.Models
{
    public class NodeList
    {
        public Guid Id { get; set; }
        public string ListName { get; private set; }
        private static List<Node> List { get; set; }
        public Node RootNode { get; private set; }
        public Node LastSelectedNode { get; set; }

        public NodeList()
        {
        }

        public void CreateList(string listName)
        {
            this.ListName = listName;
            this.Id = Guid.NewGuid();

            //if (List == null)
            //{
            List = new List<Node>();
            var node = new Node()
            {
                ListId = this.Id.ToString(),
                NodeId = System.Guid.NewGuid(),
                Name = "RootNode",
                IsRoot = true,
                ParentNode = null,
                Indent = 0,
                IsVisible = false,
                ShowSubList = true,
                IsSelected = false,
                PositionUnderParent = 0f,
                ParentPlacementString = ""
            };
            List.Add(node);
            this.RootNode = node;
            this.LastSelectedNode = node;
            //}
        }

        public void SaveList()
        {

        }

        public void Load(List<Node> list)
        {
            List = list;
            this.RootNode = List.Where(x => x.IsRoot == true).FirstOrDefault();
            this.LastSelectedNode = this.RootNode;
        }

        public void SelectNode(Node node)
        {
            if (node == null) return;
            if (this.LastSelectedNode == null) return;

            this.LastSelectedNode.IsSelected = false;
            this.LastSelectedNode = node;
            node.IsSelected = true;
        }

        public Node AddNodeBefore(Node node)
        {
            var newNode = GetNewNode(node?.ParentNode);

            //Add a fraction to put it between items
            newNode.PositionUnderParent = node.PositionUnderParent - 0.5f;
            List.Add(newNode);
            SelectNode(newNode);

            return newNode;
        }

        public Node AddNodeAfter(Node node)
        {
            var newNode = GetNewNode(node.ParentNode);

            //Add a fraction to put it between items
            newNode.PositionUnderParent = node.PositionUnderParent + 0.5f;
            List.Add(newNode);
            SelectNode(newNode);

            return newNode;
        }

        public Node AddSubNode(Node node)
        {
            var subNodeCount = this.GetSubNodes(node).Count;
            var newNode = GetNewNode(node);

            newNode.PositionUnderParent = subNodeCount + 1;
            List.Add(newNode);
            SelectNode(newNode);

            return newNode;
        }

        public void RemoveNode(Node node)
        {
            var removedGuids = new List<string>();

            var subItems = GetSubNodes(node);
            foreach (var subItem in subItems)
            {
                RemoveNode(subItem);
            }
            removedGuids.Add(node.NodeId.ToString());
            List.Remove(node);
        }

        public List<Node> GetSubNodes(Node node)
        {
            var subNodes = List
                        .Where(x => x.ParentNode != null && x.ParentNode.NodeId == node.NodeId)
                        .OrderBy(x => x.PositionUnderParent)
                        .ToList();
            int x = 1;
            foreach (var subNode in subNodes)
            {
                subNode.PositionUnderParent = x;
                subNode.ParentPlacementString = node.GetPlacementString();
                x++;
            }
            return subNodes;
        }

        public int Count()
        {
            return List.Count;
        }

        private static Node GetNewNode(Node parentNode)
        {
            var newNode = new Node()
            {
                ListId = parentNode.ListId,
                NodeId = Guid.NewGuid(),
                Name = "New Node",
                ParentNode = parentNode,
                IsSelected = true,
                ParentPlacementString = parentNode.GetPlacementString(),
                Indent = parentNode.Indent + 1
            };

            newNode.Id = newNode.NodeId.ToString();

            return newNode;
        }
    }
}
