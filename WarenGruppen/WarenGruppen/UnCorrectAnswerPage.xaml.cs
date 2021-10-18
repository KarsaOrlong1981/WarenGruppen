using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarenGruppen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnCorrectAnswerPage : ContentPage
    {
        List<ItemProperties> list;
        WorkwithDB wwDB;
        private int correctNumber;
        private int itemGroup;
        bool backToMain;
        public UnCorrectAnswerPage()
        {
            InitializeComponent();
            backToMain = false;
            wwDB = new WorkwithDB();
            list = new List<ItemProperties>();
            GetlistfromDB();
           
            
        }

        public bool GetBackTomainResult()
        {
            return backToMain;
        }
        private void GetlistfromDB()
        {
            try
            {
                int result = 0;
                
                     result = App.Database1.GetWGAsync().Result.Count;
                if (!(result == 0))
                {    
                    for (int i = 0; i < result; i++)
                    {

                        int id = App.Database1.GetWGAsync().Result[i].ID;
                        int number = App.Database1.GetWGAsync().Result[i].ItemNumber;
                        string item = App.Database1.GetWGAsync().Result[i].Item;
                        int wareGroup = App.Database1.GetWGAsync().Result[i].ItemGroup;
                        list.Add(new ItemProperties() { ID = id, ItemNumber = number, Item = item, ItemGroup = wareGroup });

                    }

                    SetRandomItem();
                }
                else
                    backToMain = true;
            }
             catch
            {
                backToMain = true;
            }

        }

        private void SetRandomItem()
        {
            Random random = new Random();
            int count = list.Count;
            
            
            if (!(count == 0))
            {
                int randomNumber = random.Next(0, count - 1);
                lab_Question.Text = list[randomNumber].Item;
            }
        }
        private async void EntryAnswer_Completed(object sender, EventArgs e)
        {
            if ((sender as Entry).Text != string.Empty)
            {
                foreach (ItemProperties it in list)
                {
                    if (lab_Question.Text == it.Item)
                    {
                        correctNumber = it.ItemNumber;// hier holt er die nr und die Gruppe
                        itemGroup = it.ItemGroup;
                        break;
                    }
                }
                if (correctNumber == Convert.ToInt32(entryAnswer.Text))
                {
                    await DisplayAlert("Klasse Karini !!!", "Das war richtig,\n\n" + correctNumber + "  " + lab_Question.Text + "\n\nimmer weiter so.....", "OK");

                    wwDB.AddCorrectInUnCorrectDB(correctNumber, lab_Question.Text, itemGroup, list);
                 
                    foreach (ItemProperties it in list)
                    {
                        if (lab_Question.Text == it.Item)
                        {
                            list.Remove(it);
                            break;
                        }
                    }
                    if (list.Count == 0)
                    {
                        Navigation.RemovePage(this);
                        CallMainPage();
                       
                    }
                }
                else
                {
                    await DisplayAlert("Ohhh neiiiin......", "Das war leider falsch.\ndie Richtige Antwort ist:\n\n" + correctNumber + "  " + lab_Question.Text, "OK");
                   
                }

                entryAnswer.Text = string.Empty;
                SetRandomItem();
                //entryAnswer_Completed(sender, e);
                entryAnswer.Focus();
            }
            else
                await DisplayAlert("Felerhafte Eingabe!!!", "Bitte einen eintrag vornehmen.", "OK");
        }

        private void btn_NewGroup_Clicked(object sender, EventArgs e)
        {
            CallMainPage();
        }

        private async void CallMainPage()
        {
            MainPage call = new MainPage();
            await Navigation.PushAsync(call);
        }
    }
}