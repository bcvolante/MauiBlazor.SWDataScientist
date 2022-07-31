using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Models
{
	public class RunesModel
    {
        [PrimaryKey, AutoIncrement]
        public int RuneID { get; set; }
        public bool IsAncient { get; set; }
        public int GradeLevel { get; set; }
        public int PowerUpLevel { get; set; }
        public int TypeID { get; set; }
        public int RarityID { get; set; }
        public int Slot { get; set; }
        public int MainStat { get; set; }
        public int PrefixStat { get; set; }
        public int PrefixStatValue { get; set; }
        public int Stat1 { get; set; }
        public int Stat1Value { get; set; }
        public int Stat1Amplify { get; set; }
        public int Stat2 { get; set; }
        public int Stat2Value { get; set; }
        public int Stat2Amplify { get; set; }
        public int Stat3 { get; set; }
        public int Stat3Value { get; set; }
        public int Stat3Amplify { get; set; }
        public int Stat4 { get; set; }
        public int Stat4Value { get; set; }
        public int Stat4Amplify { get; set; }
        public int StatConverted { get; set; }
    }
}
