using ListerUI.Models;

namespace ListerUI.Repositories
{
    public class NodeRepository : INodeRepository
    {
        private List<Node> List { get; set; }

        public NodeRepository()
        {
            List = new List<Node>();
        }

        public List<Node> LoadList(string listId)
        {
            if (List != null && List.Count > 0)
            {
                var list = List.Where(x => x.ListId == listId).ToList();
                if (list.Count > 0) return list;
            }
            else
            {
                List = new List<Node>();

                var node = new Node()
                {
                    NodeId = System.Guid.NewGuid(),
                    Name = "RootNode",
                    IsRoot = true,
                    ParentNode = null,
                    Indent = 0,
                    IsVisible = false,
                    ShowSubList = true,
                    IsSelected = false,
                    PositionUnderParent = 0f,
                    ParentPlacementString = "",
                    ListId = listId
                };

                node.Id = node.NodeId.ToString();

                List.Add(node);
            }

            return List;
        }

        public void SaveNode(Node node)
        {
            List.Add(node);
        }

        public void DeleteNode(Node node)
        {
            List.Remove(node);
        }

        public void UpdateNode(Node node)
        {

        }
    }
}
