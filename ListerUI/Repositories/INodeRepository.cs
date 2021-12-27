using ListerUI.Models;

namespace ListerUI.Repositories
{
    public interface INodeRepository
    {
        void DeleteNode(Node node);
        List<Node> LoadList(string listId);
        void SaveNode(Node node);
        void UpdateNode(Node node);
    }
}