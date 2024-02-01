using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Series_Bureau.Models;

namespace TP2_Series_Bureau.Services
{
    public interface ISerieService
    {
        public Task<IEnumerable<Serie>?> GetSeriesAsync();

        public Task<Serie?> GetSerieAsync();

        public Task PutSerieAsync();

        public Task<Serie?> PostSerieAsync();

        public Task DeleteSerieAsync();
    }
}
