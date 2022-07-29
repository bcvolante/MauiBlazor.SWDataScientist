using SQLite;
using SWDataScientist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Services
{
    public class MonsterService : IMonsterService
    {
        private SQLiteAsyncConnection _dbConnection;
        public MonsterService()
        {
            SetUpDB();
        }
        private async void SetUpDB()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Monster.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<MonsterModel>();
            }
        }
        public async Task<int> AddMonster(MonsterModel monsterModel)
        {
            return await _dbConnection.InsertAsync(monsterModel);
        }

        public async Task<int> DeleteMonster(MonsterModel monsterModel)
        {
            return await _dbConnection.DeleteAsync(monsterModel);
        }

        public async Task<List<MonsterModel>> GetMonster()
        {
            return await _dbConnection.Table<MonsterModel>().ToListAsync();
        }

        public async Task<MonsterModel> GetMonsterByID(int MonsterID)
        {
            var student = await _dbConnection.QueryAsync<MonsterModel>($"SELECT * FROM {nameof(MonsterModel)} where MonsterID = {MonsterID} ");
            return student.FirstOrDefault();
        }

        public async Task<int> UpdateMonster(MonsterModel monsterModel)
        {
            return await _dbConnection.UpdateAsync(monsterModel);
        }
    }
}
