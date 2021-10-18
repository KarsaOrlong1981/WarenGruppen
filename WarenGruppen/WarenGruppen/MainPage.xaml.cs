using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WarenGruppen
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_GroupSelect_Clicked(object sender, EventArgs e)
        {
           
            CallPickerPage();
        }

        private void btn_GroupRandom_Clicked(object sender, EventArgs e)
        {
            CallCorrectAnswerPage();
        }
        private async void CallPickerPage()
        {
            PickerPage call = new PickerPage();
            await Navigation.PushAsync(call);
        }
        private async void CallCompleteListPage()
        {
            CompleteListPage call = new CompleteListPage();
            await Navigation.PushAsync(call);
        }
        private async void CallCorrectAnswerPage()
        {
            bool a = new CorrectAnswerPage().GetBackTomainResult();
            if (a == false)
            await Navigation.PushAsync(new CorrectAnswerPage());
            else
                await DisplayAlert("Noch keine Einträge", "Entweder noch nicht genug gelernt oder du bist einfach nicht gut genug", "Tja......");
        }

        private async void CallUnCorrectAnswerPage()
        {
            bool a = new UnCorrectAnswerPage().GetBackTomainResult();
            if (a == false)
            await Navigation.PushAsync(new UnCorrectAnswerPage());
            else
               await DisplayAlert("Noch keine Einträge", "Entweder noch nicht genug gelernt oder du bist einfach zu gut", "Tja......");
        }

        private void btn_Uncorrect_Clicked(object sender, EventArgs e)
        {
            CallUnCorrectAnswerPage();
        }

        private void btn_List_Clicked(object sender, EventArgs e)
        {
            CallCompleteListPage();
        }
    }
}
