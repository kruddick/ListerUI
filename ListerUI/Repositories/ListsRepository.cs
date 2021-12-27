using ListerUI.Models;

namespace ListerUI.Repositories
{
    public class ListsRepository : IListsRepository
    {
        private List<ListInfo> Lists { get; set; }

        public ListsRepository()
        {
            Lists = new List<ListInfo>
            {
                new ListInfo
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Super List of stuff",
                    Description = "A fun and exciting list to fill out.",
                    CreatedBy = "AquaMan",
                    CreatedDate = DateOnly.FromDateTime(DateTime.Now)
                },

                new ListInfo
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Super List of stuff 2",
                    Description = "A exciting list to fill out.",
                    CreatedBy = "Superman",
                    CreatedDate = DateOnly.FromDateTime(DateTime.Now)
                }
            };
        }

        public List<ListInfo> GetLists()
        {
            return Lists;
        }

        public void AddList(ListInfo list)
        {
            Lists.Add(list);
        }

        public void RemoveList(ListInfo list)
        {
            Lists.Remove(list);
        }

        public void UpdateList(ListInfo list)
        {
            // save list?
        }
    }
}
