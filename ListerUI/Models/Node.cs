using ListerUI.Enums;

namespace ListerUI.Models
{
    public class Node
    {
        // Persistant data
        public string Id { get; set; }
        public Guid NodeId { get; set; }
        public string ListId { get; set; }
        public bool IsRoot { get; set; } = false;
        public Node ParentNode { get; set; }

        //Display data
        public int Indent { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool ShowSubList { get; set; } = false;
        public bool IsSelected { get; set; } = false;
        public float PositionUnderParent { get; set; }
        public string ParentPlacementString { get; set; }

        // Persistant record data
        public string Name { get; set; }
        public string Description { get; set; }
        public RecordState CompletionState { get; set; } = RecordState.Unclaimed;
        public string ClaimedBy { get; set; } = string.Empty;
        public string DependsOn { get; set; }

        public Node()
        {
        }

        public Node(string name, Guid parentNode, int indent, string listId)
        {
            NodeId = Guid.NewGuid();
            Name = name;
            ListId = listId;
            Indent = indent;
            Id = NodeId.ToString();
        }

        public Node GetCopy()
        {
            var newNode = new Node()
            {
                Id = this.Id,
                NodeId = this.NodeId,
                ListId = this.ListId,
                Name = this.Name,
                IsRoot = this.IsRoot,
                ParentPlacementString = this.ParentPlacementString,
                Indent = this.Indent,
                IsSelected = this.IsSelected,
                IsVisible = this.IsVisible,
                ParentNode = this.ParentNode,
                PositionUnderParent = this.PositionUnderParent,
                ShowSubList = this.ShowSubList
            };
            return newNode;
        }

        public string GetPlacementString()
        {
            if (PositionUnderParent == 0) return string.Empty;
            if (ParentPlacementString == "") return PositionUnderParent.ToString();

            return $"{ParentPlacementString}.{PositionUnderParent}";
        }
    }
}
