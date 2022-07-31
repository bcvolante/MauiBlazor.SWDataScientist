using SQLite;
using SWDataScientist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Services
{
	public class AwakenMonsterService : IAwakenMonsterService
    {
        private SQLiteAsyncConnection _dbConnection;
        public AwakenMonsterService()
        {
            SetUpDB();
        }
        private async void SetUpDB()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AwakenMonsters.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<AwakenMonsterModel>();
            }
        }

        // Awaken Monster
        public async Task<int> AddAwakenMonster(AwakenMonsterModel awakenMonsterModel)
        {
            return await _dbConnection.InsertAsync(awakenMonsterModel);
        }
        public async Task<AwakenMonsterModel> GetAwakenMonsterByAttributeID(int attributeID, int settingID)
        {
            var awakenMonster = await _dbConnection.QueryAsync<AwakenMonsterModel>($"SELECT * FROM {nameof(AwakenMonsterModel)} " +
                $"WHERE FamilyID = {settingID} AND attributeID = {attributeID}");
            return awakenMonster.FirstOrDefault();
        }
        public async Task<int> UpdateAwakenMonster(AwakenMonsterModel awakenMonsterModel)
        {
            return await _dbConnection.UpdateAsync(awakenMonsterModel);
        }
    }
}