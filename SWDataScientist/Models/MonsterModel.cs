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
        public int MonsterLevel { get; set; }
        public int AwakenMonsterID { get; set; }
        public int AwakenLevel { get; set; }
        public int StarLevel { get; set; }
    }
}
