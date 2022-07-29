using SWDataScientist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Services
{ 
    public interface ISettingsService
    {
        Task<List<SettingsModel>> GetSetting();
        Task<List<SettingsModel>> GetSettingType();
        Task<SettingsModel> GetSettingByID(int SettingID);
        Task<List<SettingsModel>> GetSettingBySettingTypeID(int SettingTypeID, int isDeleted);
        Task<SettingsModel> DeleteSetting(int SettingID, bool isDeleted);
        Task<SettingsModel> UpdateActiveSetting(int SettingID, bool IsActive);
        Task<int> AddSetting(SettingsModel settingsModel);
        Task<SettingsModel> UpdateSetting(int SettingID, string description);
        //Task<int> DeleteSetting(SettingsModel settingsModel);
    }
}
