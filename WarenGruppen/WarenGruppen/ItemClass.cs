using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WarenGruppen
{
    public class ItemClass
    {
        List<ItemProperties> list1_1;
        List<ItemProperties> list2_1;
        List<ItemProperties> list3_1;
        List<ItemProperties> list4_1;
        List<ItemProperties> list5_1;
        ItemProperties itemsProp;
        int counter;
       
        string[] wareGroup1_1 = { "Aufschnitt gemischt", "Lyoner Aufschnitt", "Spießbratenwurst", "Schinkenwurst", "Jagdwurst", "Bierwurst", "Broccolipastete", "Lyoner mit Ei", "Champignons-Lyoner",
                                "Paprika-Lyoner", "Lyoner Aufschnittwürstchen", "Pizza/Zwiebel/Spießbraten FK am Stück", "Pastete gemischt", "Fleischkäse am Stück", "Fleischkäse geschnitten",
                                "Zwiebelfleischkäse geschnitten", "Pizzafleischkäse", "Wildschweinpastet imit.", "Fleischkäsemasse roh", "Hackbraten geschnitten", "Mini Fleischkäse am Stück",
                                "Fleischwurst im Ring", "Knoblauchfleischwurst", "Krakauer", "Käsefleischwurst", "Wienerwürstchen", "Fleischwürstchen Dick", "Mettwurst", "Käsemettwurst", "Bratwurst fein",
                                "Bratwurst Grob", "Bratwurst Mini", "Käsebratwurst", "Rostbratwurst", "Weißwurst", "Spießbratenfleischkäse", "Grillwurstscheiben", "Gefüllter Bauch", "Frikadelle", "Pizzawürstchen",
                                 "Fleischkäseaufschnitt gemischt", "Wiener Würstchen im Glas", "Bratwurst Großhandel" ,"Mettwurst Großhandel", "Fleischwürstchen Großhandel","Wiener Großhandel",
                                 "Spießbraten Aufschnittwürstchen", "Mini Rostbratwurst", "Schweinemett Großhandel", "Brötchen mit Aufschnitt","Frikadellen Großhandel","Spießbratenwurst","Schnittchen mit Aufschnitt", "Flitbrot mit Aufschnitt ohne H.M", "Flitbrot mit Schinken,Salami o.Braten","Putenfleischkäse 100% Pute",
                                  "Putenwiener im Glas", "Salsicha Bratwurst", "Bratwurst grob Großhandel", "Käsebratwurst Großhandel", "Puten Pizzafleischkäse", "Knobling", "Gulaschsuppe groß", "Gulaschsuppe klein",
                                  "Gulaschsuppe Großhandel"};
        
        // Warengruppe 2 hat nur 1 eintrag, dieser wurde hard codiert...
        string[] wareGroup3_1 = { "Chorizo Scharfe Stange", "Brötschen mit Salami", "Test", "Fenchelsalami", "Salamiring Milano", "Südländische Salami", "Oliven Salami", "Sasalito" };
        string[] wareGroup4_1 = { "Leberknödel vorgegart", "Schinken/Jagdwurst Aufschnittwürstchen", "Leberknödel", "Käsemettwurst Großhandel", "Blutwurst im Ring", "Leberwurst im Ring", "Blutwurst dick geschnitten",
                                  "Leberwurst dick geschnitten", "Ein.Hausm.Leberwurst", "Kartoffelwurst", "Schwartenmagen geräuchert", "Schwartenmagen frisch", "Feine Leberwurst", "Truthahnleberwurst PUR",
                                  "Zwiebling", "Schlachtplatte", "Bauerntaler", "Bauernfrühstück vom Schwein", "Gefüllte Klöße", "Partyfrikadellen", "Preiselbeerpastete", "Kirschpastete mittelgrob",
                                  "Nuss-Kastanien Pastete", "Deutsches Cornedbeef", "Leberpastete mit Steinpilzen", "Tomate Mozzarella Pastete", "Trüffelkugeln", "Schnittlauchkugeln", "Spargeltröpfchen in Balsamico-Gelee",
                                  "Hähnchenfleisch in Ananas", "Sommersülze Kalb & Schwein", "Lauchsülze", "Schinkenröllchen Meerettich", "Weinsülze-Delikatess", "Hubertusschmalz", "Sülze gem.Kalb,Pute,Mix",
                                  "Tannenbaum Salami mit Bärlauch", "Truthahn Sauerfleisch", "Chili con Carne", "Chili con Carne Großhandel"};
        string[] wareGroup5_1 = { "Rohesser Großhandel", "Bierknacker Großhandel", "Salami gemischt", "Rindersalami", "Pfeffersalami", "Peperonisalami", "Salami am Stück", "Hirschsalami klein",
                                  "Sportsalami", "Putensalami Hukki", "Putensalami hausgemacht", "Salami Mailänder art", "Salami Weiss", "Salami im Ring", "Haussalami klein", "Schweinemettwurst",
                                  "Salami Endstück", "Bierknacker", "Braunschweiger", "Rohesser dünn", "Teewurst Rügenwälderart fein", "Teewurst Rügenwälderart grob", "Vesperwurst", "Pfeffersäckchen",
                                  "Andouille", "Grand Talerino Pfeffer", "Salami-Zipfel", "VDK Salamiringe", "Nikolaussalami", "Rinder Bierknacker", "Walnusssalami", "Wellness-Salami", "Gefüllte Klöße Großhandel",
                                  "Saltufo mit Sommertrüffel und Parmigiano"};
        public ItemClass()
        {
            list1_1 = new List<ItemProperties>();
          
            list2_1 = new List<ItemProperties>();
            list3_1 = new List<ItemProperties>();
            list4_1 = new List<ItemProperties>();
            list5_1 = new List<ItemProperties>();
            itemsProp = new ItemProperties();
          
            
           
        }

        
        public List<ItemProperties> WareGroup1Propertys()
        {
            list1_1.Clear();
            counter = 1;
            for (int i = 0; i < wareGroup1_1.Length; i++)
            {
                if (counter == 5)
                    counter++;
                if (counter == 13)
                    counter = counter + 5;
                if (counter == 27)
                    counter++;
                if (counter == 42)
                    counter++;
                if (counter == 48)
                    counter = counter + 2;
                if (counter == 51)
                    counter = counter + 2;
                if (counter == 59)
                    counter = counter + 2;
                if (counter == 67)
                    counter = counter + 5;
                if (counter == 73)
                    counter = counter + 2;
                if (counter == 83)
                    counter = counter + 31;
                if (counter == 115)
                    counter = counter + 146;
                if (counter == 263)
                    counter = counter + 5;

                list1_1.Add(new ItemProperties() {ItemNumber = counter, Item = wareGroup1_1[i], ItemGroup = 1 });
                counter++;
            }
            return list1_1;
        }

        

        public List<ItemProperties> WareGroup2Propertys()
        {
            list2_1.Clear();
            list2_1.Add(new ItemProperties() { ItemNumber = 15, Item = "Blutzungenwurst", ItemGroup = 2 });
            return list2_1;
        }

        public List<ItemProperties> WareGroup3Propertys()
        {
            list3_1.Clear();
            counter = 49;
            for (int i = 0; i < wareGroup3_1.Length; i++)
            {
                if (counter == 50)
                    counter = counter + 17;
                if (counter == 68)
                    counter = counter + 84;
                if (counter == 153)
                    counter = counter + 40;
                if (counter == 195)
                    counter = counter + 3;
                if (counter == 200)
                    counter = counter + 19;
                list3_1.Add(new ItemProperties() { ItemNumber = counter, Item = wareGroup3_1[i], ItemGroup = 3 });
                counter++;
            }
            return list3_1;
        }

        public List<ItemProperties> WareGroup4Propertys()
        {
            list4_1.Clear();
            counter = 93;
            for (int i = 0; i < wareGroup4_1.Length; i++)
            {
                if (counter == 94)
                    counter++;
                if (counter == 96)
                    counter = counter + 2;
                if (counter == 109)
                    counter = counter + 2;
                if (counter == 112)
                    counter++;
                if (counter == 114)
                    counter++;
                if (counter == 116)
                    counter++;
                if (counter == 121)
                    counter++;
                if (counter == 130)
                    counter = counter + 2;
                if (counter == 135)
                    counter = counter + 2;
                if (counter == 138)
                    counter++;
                if (counter == 140)
                    counter = counter + 2;
                if (counter == 143)
                    counter = counter + 3;
                if (counter == 147)
                    counter = counter + 43;
                if (counter == 193)
                    counter = counter + 74;
                if (counter == 268)
                    counter = counter + 10;
                list4_1.Add(new ItemProperties() { ItemNumber = counter, Item = wareGroup4_1[i], ItemGroup = 4 });
                counter++;
            }
            return list4_1;
        }

        public List<ItemProperties> WareGroup5Propertys()
        {
            list5_1.Clear();
            counter = 59;
            for (int i = 0; i < wareGroup5_1.Length; i++)
            {
                if (counter == 61)
                    counter = counter + 89;
                if (counter == 152)
                    counter++;
                if (counter == 158)
                    counter++;
                if (counter == 161)
                    counter++;
                if (counter == 164)
                    counter = counter + 2;
                if (counter == 167)
                    counter++;
                if (counter == 169)
                    counter++;
                list5_1.Add(new ItemProperties() { ItemNumber = counter, Item = wareGroup5_1[i], ItemGroup = 5 });
                counter++;
            }
            return list5_1;
        }
    }
}
