using ListerUI.Models;

namespace ListerUI.Repositories
{
    public interface IListsRepository
    {
        void AddList(ListInfo list);
        List<ListInfo> GetLists();
        void RemoveList(ListInfo list);
        void UpdateList(ListInfo list);
    }
}