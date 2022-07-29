using SWDataScientist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Services
{
    public interface IMonsterService
    {
        Task<List<MonsterModel>> GetMonster();
        Task<MonsterModel> GetMonsterByID(int MonsterID);
        Task<int> AddMonster(MonsterModel monsterModel);
        Task<int> UpdateMonster(MonsterModel monsterModel);
        Task<int> DeleteMonster(MonsterModel monsterModel);
    }
}
