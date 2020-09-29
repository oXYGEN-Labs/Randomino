using Randomizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Randomizer.Services
{
    public class RandomizeService : IRandomizeService
    {
        public string GetRandomItem(ObservableCollection<string> itemsList)
        {
            Random rand = new Random();

            int rnumber = rand.Next(0, itemsList.Count);

            return itemsList[rnumber];
        }
    }
}
