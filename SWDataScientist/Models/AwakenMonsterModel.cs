using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Models
{
	public class AwakenMonsterModel
    {
        [PrimaryKey, AutoIncrement]
        public int AwakenMonsterID { get; set; }
        public int FamilyID { get; set; }
        public int AttributeID { get; set; }
        public int TypeID { get; set; }
        public bool IsSecondAwaken { get; set; }
        public string AwakenName { get; set; }
        public int NaturalStarLevel { get; set; }
    }
}
