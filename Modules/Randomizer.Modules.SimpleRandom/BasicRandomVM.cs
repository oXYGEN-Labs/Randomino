using Prism.Commands;
using Prism.Mvvm;
using Randomizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Modules.SimpleRandom
{
    public class BasicRandomVM : BindableBase
    {

        private IRandomizeService _randomizeService;

        private IListService _listService;

        private ObservableCollection<string> _itemsList;
        public ObservableCollection<string> ItemsList
        {
            get { return _itemsList; }
            set { SetProperty(ref _itemsList, value); }
        }

        private string _item;
        public string Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        /// <summary>
        /// DelegateCommand for the Add button
        /// </summary>
        private DelegateCommand _addItemToList;
        public DelegateCommand AddItemToList =>
            _addItemToList ?? (_addItemToList = new DelegateCommand(ExecuteAddItemToList, CanAddItem)
            .ObservesProperty(() => Item));

        /// <summary>
        /// Delegate Command for the Random button
        /// </summary>
        private DelegateCommand _getRandomItemFromList;
        public DelegateCommand GetRandomItemFromList =>
            _getRandomItemFromList ?? (_getRandomItemFromList = new DelegateCommand(ExecuteGetRandomItemFromList, CanExecuteGetRandomItemFromList)
            .ObservesProperty(() => ItemsList.Count));



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="randomizeService">Randomization service</param>
        /// <param name="listService">List Service</param>
        public BasicRandomVM(IRandomizeService randomizeService, IListService listService)
        {
            // Services Interfaces
            _randomizeService = randomizeService;
            _listService = listService;

            // List Init
            ItemsList = new ObservableCollection<string>();
        }


        /// <summary>
        /// Executed when button "Add" is pressed
        /// </summary>
        void ExecuteAddItemToList()
        {
            // Add item to the list
            _listService.AddItem(Item);

            // Get updated list from service
            ItemsList = _listService.GetList();

            // Reset the textbox text
            Item = null;
        }        

        /// <summary>
        /// Validation method for the "Add" button
        /// </summary>
        /// <returns>False if textbox is empty</returns>
        private bool CanAddItem()
        {
            return !(Item is null);
        }

        /// <summary>
        /// Executed when button "Random" is pressed
        /// </summary>
        void ExecuteGetRandomItemFromList()
        {
            Result = _randomizeService.GetRandomItem(ItemsList);
        }

        /// <summary>
        /// Validation method for the "Randomize" button
        /// </summary>
        /// <returns>False if list contain less than 2 items</returns>
        bool CanExecuteGetRandomItemFromList()
        {
            return _itemsList.Count > 1;
        }
    }
}
