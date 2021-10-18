using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarenGruppen
{
    public class ItemProperties
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ItemNumber { get; set; }
        public string Item { get; set; }
        public int ItemGroup { get; set; }
    }
}
