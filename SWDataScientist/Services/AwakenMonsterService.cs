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

        //public async Task<List<AwakenMonsterModel>> GetAwakenMonster(int AwakenMonsterID)
        //{
        //    return await _dbConnection.QueryAsync<AwakenMonsterModel>($"SELECT amm.*,f.Description FamilyName,a.Description AttributeName,t.Description TypeName" +
        //        $"FROM {nameof(AwakenMonsterModel)} amm" +
        //        $"LEFT JOIN {nameof(SettingsModel)} f ON amm.FamilyID = f.SettingID" +
        //        $"LEFT JOIN {nameof(SettingsModel)} a ON amm.AttributeID = a.SettingID" +
        //        $"LEFT JOIN {nameof(SettingsModel)} t ON amm.TypeID = t.SettingID" +
        //        $" where amm.AwakenMonsterID = IIF({AwakenMonsterID} = 0,amm.AwakenMonsterID,{AwakenMonsterID})");
        //}
        public async Task<List<AwakenMonsterModel>> GetAwakenMonster()
        {
            return await _dbConnection.Table<AwakenMonsterModel>().ToListAsync();

        }
    }
}