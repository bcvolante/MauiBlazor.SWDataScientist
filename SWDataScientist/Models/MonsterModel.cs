using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Models
{
    public class MonsterModel
    {
        [PrimaryKey, AutoIncrement]
        public int MonsterID { get; set; }
        public int FamilyID { get; set; }
        public int AttributeID { get; set; }
        public string AwakenName { get; set; }
        public bool IsSecondAwaken { get; set; }
        public int TypeID { get; set; }
    }
}
