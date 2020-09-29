using Randomizer.Services.Interfaces;
using System.Collections.ObjectModel;

namespace Randomizer.Services
{
    public class ListService : IListService
    {
        public ListService()
        {
            ItemsList = new ObservableCollection<string>();
        }

        public ObservableCollection<string> ItemsList;


        public ObservableCollection<string> AddItem(string item)
        {
            ItemsList.Add(item);

            return ItemsList;
        }

        public ObservableCollection<string> CleanList()
        {
            ItemsList.Clear();

            return ItemsList;
        }

        public ObservableCollection<string> GetList()
        {
            return ItemsList;
        }
    }
}
