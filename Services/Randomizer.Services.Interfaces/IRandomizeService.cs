using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Randomizer.Services.Interfaces
{
    public interface IRandomizeService
    {
        string GetRandomItem(ObservableCollection<string> itemsList);
    }
}
