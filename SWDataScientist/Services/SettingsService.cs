using SQLite;
using SWDataScientist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Services
{
    public class SettingsService : ISettingsService
    {
        private SQLiteAsyncConnection _dbConnection;
        public SettingsService()
        {
            SetUpDB();
        }
        private async void SetUpDB()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Setting.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<SettingsModel>();
            }
        }
        public async Task<int> AddSetting(SettingsModel settingsModel)
        {
            return await _dbConnection.InsertAsync(settingsModel);
        }

        public async Task<SettingsModel> DeleteSetting(int SettingID, bool isDeleted)
        {
            //var settings = await _dbConnection.QueryAsync<SettingsModel>($"UPDATE {nameof(SettingsModel)} SET isDeleted = false");
            var settings = await _dbConnection.QueryAsync<SettingsModel>($"UPDATE {nameof(SettingsModel)} SET isDeleted = {isDeleted} where SettingID = {SettingID} ");
            return settings.FirstOrDefault();

        }
        public async Task<SettingsModel> UpdateActiveSetting(int SettingID, bool IsActive)
        {
            var settings = await _dbConnection.QueryAsync<SettingsModel>($"UPDATE {nameof(SettingsModel)} SET isActive = {IsActive} WHERE SettingID = {SettingID} ");
            return settings.FirstOrDefault();

        }

        public async Task<List<SettingsModel>> GetSetting()
        {
            //return await _dbConnection.QueryAsync<SettingsModel>($"SELECT * FROM {nameof(SettingsModel)} where IsDeleted = False");
            return await _dbConnection.Table<SettingsModel>().ToListAsync();
        }
        public async Task<List<SettingsModel>> GetSettingType()
        {
            return await _dbConnection.QueryAsync<SettingsModel>($"SELECT * FROM {nameof(SettingsModel)} WHERE SettingTypeID = 5 AND isActive = true");
            //return await _dbConnection.Table<SettingsModel>().ToListAsync();
        }

        public async Task<SettingsModel> GetSettingByID(int SettingID)
        {
            var setting = await _dbConnection.QueryAsync<SettingsModel>($"SELECT * FROM {nameof(SettingsModel)} WHERE SettingID = {SettingID} ");
            return setting.FirstOrDefault();
        }

        public async Task<List<SettingsModel>> GetSettingBySettingTypeID(int SettingTypeID, int isDeleted)
        {
            return await _dbConnection.QueryAsync<SettingsModel>($"SELECT * FROM {nameof(SettingsModel)} WHERE SettingTypeID = IIF({SettingTypeID} = -1,SettingTypeID,{SettingTypeID}) AND isDeleted = CASE WHEN {isDeleted} = 2 THEN isDeleted WHEN {isDeleted} = 1 THEN true ELSE false END");
        }

        public async Task<SettingsModel> UpdateSetting(int SettingID, string description)
        {
            var settings = await _dbConnection.QueryAsync<SettingsModel>($"UPDATE {nameof(SettingsModel)} SET description = '{description}' WHERE SettingID = {SettingID} ");
            return settings.FirstOrDefault();
        }
    }
}
