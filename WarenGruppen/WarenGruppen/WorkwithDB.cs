using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WarenGruppen
{
    public class WorkwithDB
    {
      
        public async void AddToDBUnCorrect(int number, string item, int wareGroup)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                int task = App.Database1.GetWGAsync().Result.Count;
                int taskInOther = App.Database.GetWGAsync().Result.Count;
                int id = 0;
                //Datenbank durchsuchen ob das aktuelle item schon vorhanden ist 
                bool hitSame = false;
                bool hitinOther = false;
                for (int i = 0; i < task; i++)
                {
                    if (item == App.Database1.GetWGAsync().Result[i].Item)
                    {
                        hitSame = true;
                        break;
                    }
                }
                for (int i = 0; i < taskInOther; i++)
                {
                    if (item == App.Database.GetWGAsync().Result[i].Item)
                    {
                        hitinOther = true;
                        id = App.Database.GetWGAsync().Result[i].ID;
                        break;
                    }
                }
                //wenn nicht vorhanden dann einen neuen eintrag vornehmen
                if (hitSame == false && hitinOther == false)
                {
                    await App.Database1.SaveWGAsync(new ItemProperties
                    {

                        ItemNumber = number,
                        Item = item,
                        ItemGroup = wareGroup
                    });
                }
                // Wenn das item in der Richtig DB enhalten ist wird es dort gelöscht und in Falsch DB hinzugefügt
                if (hitinOther == true)
                {
                    await App.Database.DeleteItemAsync(id);

                    await App.Database1.SaveWGAsync(new ItemProperties
                    {
                        ID = id,
                        ItemNumber = number,
                        Item = item,
                        ItemGroup = wareGroup
                    });
                }

            }
        }

        public async void AddToDBCorrect(int number, string item, int wareGroup)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                //noch prüfen ob item schon in der Datenbank vorhanden ist,
                //wenn Ja nicht hinzufügen wenn nein hinzufügen
                int  task = App.Database.GetWGAsync().Result.Count;
                int taskInOther = App.Database1.GetWGAsync().Result.Count;
                int id = 0;
                bool hit = false;
                bool hitinOther = false;
                //Hier prüft er ob das aktuelle Item schon in der Richtig DB enthalten ist
                for (int i = 0; i < task; i++)
                {
                    if (item == App.Database.GetWGAsync().Result[i].Item)
                    {
                        hit = true;
                        break;
                    }
                }
                //prüfen ob das Item schon in der Falsch DB enthalten ist
                for (int i = 0; i < taskInOther; i++)
                {
                    if (item == App.Database1.GetWGAsync().Result[i].Item)
                    {
                        hitinOther = true;
                        id = App.Database1.GetWGAsync().Result[i].ID;
                        break;
                    }
                }
                // Wenn das Item noch nicht in einer DB enthalten ist zu Richtig DB hinzufügen
                if (hit == false && hitinOther == false)
                {
                    await App.Database.SaveWGAsync(new ItemProperties
                    {

                        ItemNumber = number,
                        Item = item,
                        ItemGroup = wareGroup
                    });
                }
                // Wenn das item in der Falsch DB enhalten ist wird es dort gelöscht und in Richtig hinzugefügt
                if(hitinOther == true)
                {
                    await App.Database1.DeleteItemAsync(id);
                   
                    await App.Database.SaveWGAsync(new ItemProperties
                    {
                        ID = id,
                        ItemNumber = number,
                        Item = item,
                        ItemGroup = wareGroup
                    });
                }

            }
        }
        public async void AddUncorrectInCorrectDB(int number, string item, int wareGroup, List<ItemProperties> list)
        {
            int result = list.Count;

            bool hit = false;
            int id = 0;
            for (int i = 0; i < result; i++)
            {
                if (item == App.Database.GetWGAsync().Result[i].Item)
                {
                    hit = true;
                    id = App.Database.GetWGAsync().Result[i].ID;
                    break;
                }
            }

            if (hit == true)
            {
                await App.Database.DeleteItemAsync(id);
             
                await App.Database1.SaveWGAsync(new ItemProperties
                {
                    ID = id,
                    ItemNumber = number,
                    Item = item,
                    ItemGroup = wareGroup
                });

            }
            
        }
            public async void AddCorrectInUnCorrectDB(int number, string item, int wareGroup, List<ItemProperties> list)
            {
                   int result = list.Count;

                   bool hit = false;
                   int id = 0;
                   for (int i = 0; i < result; i++)
                   {
                       if (item == App.Database1.GetWGAsync().Result[i].Item)
                       {
                          hit = true;
                          id = App.Database1.GetWGAsync().Result[i].ID;
                          break;
                       }
                   }

                   if (hit == true)
                   {
                       await App.Database1.DeleteItemAsync(id);
                      
                       await App.Database.SaveWGAsync(new ItemProperties
                       {
                             ID = id,
                             ItemNumber = number,
                             Item = item ,
                             ItemGroup = wareGroup
                       });

                   }
            }
        
    }
}
