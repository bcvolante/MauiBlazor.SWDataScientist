using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Models
{
    public class SettingsModel
    {
        [PrimaryKey, AutoIncrement]
        public int SettingID { get; set; }
        public int SettingTypeID { get; set; }
        public string Description { get; set; }
        public bool IsFix { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

//SETTING TYPE ID : SettingTypeID
//    1 - Setting Type
//    2 - Monster Family Name
//    3 - Type
//    4 - Attribute
//    5 - Rune Type
