﻿using System;
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

        public Task<Serie?> GetSerieAsync(int id);

        public Task PutSerieAsync(int id, Serie serie);

        public Task PostSerieAsync(Serie serie);

        public Task DeleteSerieAsync(int id);
    }
}
