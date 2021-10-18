using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarenGruppen.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarenGruppen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompleteListPage : ContentPage
    {
        public ItemProperties Property { get; set; }
      
        List<ItemProperties> completeList;
        public CompleteListPage()
        {
            InitializeComponent();
          
            BindingContext = new CompleteListVM(Navigation, collectionView);
            
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}