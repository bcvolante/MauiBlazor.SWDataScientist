using SWDataScientist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDataScientist.Services
{
	public interface IRunesService
    {
        Task<List<RunesModel>> GetRunes();
        Task<int> AddRunes(RunesModel runesModel);
    }
}
