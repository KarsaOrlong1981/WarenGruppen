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
    public partial class PickerPage : ContentPage
    {
        ItemClass item;
        WorkwithDB wwDB;
       
        int wareGroupInt;
        int itemGroup;
        int correctNumber;
        int randomValue;
       
        List<ItemProperties> listTogetItem;
        List<ItemProperties> list1_1;
        List<ItemProperties> list1_2;
        List<ItemProperties> list2_1;
        List<ItemProperties> list3_1;
        List<ItemProperties> list4_1;
        List<ItemProperties> list5_1;

        public PickerPage()
        {
            InitializeComponent();
          
            wwDB = new WorkwithDB();
            item = new ItemClass();
            listTogetItem = new List<ItemProperties>();
            list1_1 = new List<ItemProperties>();
            list1_2 = new List<ItemProperties>();
            list2_1 = new List<ItemProperties>();
            list3_1 = new List<ItemProperties>();
            list4_1 = new List<ItemProperties>();
            list5_1 = new List<ItemProperties>();
            entryGroup.Focus();
        }
     

        private void entryGroup_Completed(object sender, EventArgs e)
        {
            listTogetItem.Clear();
            frame.IsVisible = false;
            wareGroupInt = Convert.ToInt32(entryGroup.Text);

          
            if (wareGroupInt > 0 && wareGroupInt <= 25 && entryGroup.Text != null)
            {
                btn_NewGroup.IsVisible = true;
                entryGroup.IsVisible = false;
                lab_ChooseGroup.IsVisible = false;
                entryAnswer.IsVisible = true;
                lab_Question.IsVisible = true;

                switch (wareGroupInt)
                {
                    case 1:
                        Random random1_1 = new Random();
                        list1_1 = item.WareGroup1Propertys();
                        randomValue = random1_1.Next(0, list1_1.Count);
                        lab_Question.Text = list1_1[randomValue].Item;
                        break;

                    case 2:
                        Random random2 = new Random();
                        list2_1 = item.WareGroup2Propertys();
                        randomValue = random2.Next(0, list2_1.Count);
                        lab_Question.Text = list2_1[randomValue].Item;
                        break;


                    case 3:
                        Random random3 = new Random();
                        list3_1 = item.WareGroup3Propertys();
                        randomValue = random3.Next(0, list3_1.Count);
                        lab_Question.Text = list3_1[randomValue].Item;
                        break;

                    case 4:

                        Random random4 = new Random();
                        list4_1 = item.WareGroup4Propertys();
                        randomValue = random4.Next(0, list4_1.Count);
                        lab_Question.Text = list4_1[randomValue].Item;
                        break;

                    case 5:

                        Random random5 = new Random();
                        list5_1 = item.WareGroup4Propertys();
                        randomValue = random5.Next(0, list5_1.Count);
                        lab_Question.Text = list5_1[randomValue].Item;
                        break;
                }
            }
            else
                Fail();
        }

        private async void Fail()
        {
            await DisplayAlert("Oh Karin, kannst du nicht lesen ???", "Nur Zahlen die oben angegeben sind!!!", "Ok mein Schatz");
            entryGroup.Text = null;
            entryGroup.Focus();
        }
        private async void entryAnswer_Completed(object sender, EventArgs e)
        {
            correctNumber = 0;
            if ((sender as Entry).Text != string.Empty)
            {
                switch (wareGroupInt)
                {
                    case 1:
                                listTogetItem = item.WareGroup1Propertys();
                                break;
                            
                    
                    case 2:
                                listTogetItem = item.WareGroup2Propertys();
                                break;
                       
                        
                    case 3:
                                listTogetItem = item.WareGroup3Propertys();
                                break;
                      
                    case 4:
                        
                                listTogetItem = item.WareGroup4Propertys();
                                break;
                    case 5:

                        listTogetItem = item.WareGroup5Propertys();
                        break;
                }

                foreach (ItemProperties it in listTogetItem)
                {
                    if (lab_Question.Text == it.Item)
                    {
                        correctNumber = it.ItemNumber;
                        itemGroup = it.ItemGroup;
                        break;
                    }
                }
                if (correctNumber == Convert.ToInt32(entryAnswer.Text))
                {
                    await DisplayAlert("Klasse Karini !!!", "Das war richtig,\n\n" + correctNumber + "  " + lab_Question.Text + "\n\nimmer weiter so.....", "Danke mein Schatz");
                    wwDB.AddToDBCorrect(correctNumber, lab_Question.Text, itemGroup);
                }
                else
                {
                   await DisplayAlert("Ohhh neiiiin......", "Das war leider falsch.\ndie Richtige Antwort ist:\n\n" + correctNumber + "  " + lab_Question.Text, "Oh man");
                   wwDB.AddToDBUnCorrect(correctNumber, lab_Question.Text, itemGroup);
                }
                entryAnswer.Text = string.Empty;

                entryGroup_Completed(sender, e);
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