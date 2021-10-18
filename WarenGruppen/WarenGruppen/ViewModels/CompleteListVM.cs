using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WarenGruppen.ViewModels
{
    class CompleteListVM : BaseVM
    {
        public INavigation Navigation { get; set; }
        List<ItemProperties> completeList;
        ItemClass item;
       
        public CompleteListVM(INavigation navigation, CollectionView collectionView)
        {
            this.Navigation = navigation;
            item = new ItemClass();
            completeList = new List<ItemProperties>();
            CreateCompleteList(collectionView);
        }

        private void CreateCompleteList(CollectionView collection)
        {
            for (int i = 0; i < item.WareGroup1Propertys().Count; i++)
            {
                completeList.Add(item.WareGroup1Propertys()[i]);
            }
            for (int i = 0; i < item.WareGroup2Propertys().Count; i++)
            {
                completeList.Add(item.WareGroup2Propertys()[i]);
            }
            for (int i = 0; i < item.WareGroup3Propertys().Count; i++)
            {
                completeList.Add(item.WareGroup3Propertys()[i]);
            }
            for (int i = 0; i < item.WareGroup4Propertys().Count; i++)
            {
                completeList.Add(item.WareGroup4Propertys()[i]);
            }
            for (int i = 0; i < item.WareGroup5Propertys().Count; i++)
            {
                completeList.Add(item.WareGroup5Propertys()[i]);
            }

            collection.ItemsSource = completeList;
        }
    }
}
