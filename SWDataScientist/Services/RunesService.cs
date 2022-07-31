using SQLite;
using SWDataScientist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Services
{
	public class RunesService : IRunesService
    {
        private SQLiteAsyncConnection _dbConnection;
        public RunesService()
        {
            SetUpDB();
        }
        private async void SetUpDB()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Runes.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<RunesModel>();
            }
        }
        public async Task<int> AddRunes(RunesModel runesModel)
        {
            return await _dbConnection.InsertAsync(runesModel);
        }

		public async Task<List<RunesModel>> GetRunes()
        {
            return await _dbConnection.Table<RunesModel>().ToListAsync();
        }
	}
}
