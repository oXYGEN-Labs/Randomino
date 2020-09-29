using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Randomizer.Services.Interfaces
{
    public interface IListService
    {
        ObservableCollection<string> AddItem(string item);
        ObservableCollection<string> CleanList();
        ObservableCollection<string> GetList();
    }
}
