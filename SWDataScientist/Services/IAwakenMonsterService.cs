using SWDataScientist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Services
{
	public interface IAwakenMonsterService
    {
        // Awaken Monster
        Task<int> AddAwakenMonster(AwakenMonsterModel awakenMonsterModel);
        Task<int> UpdateAwakenMonster(AwakenMonsterModel awakenMonsterModel);
        Task<AwakenMonsterModel> GetAwakenMonsterByAttributeID(int attributeID, int settingID);
        Task<List<AwakenMonsterModel>> GetAwakenMonster();
    }
}
