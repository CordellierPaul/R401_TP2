using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2_Series_API_Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP2_Series_API_Web.Models.EntityFramework;

namespace TP2_Series_API_Web.Controllers.Tests
{
    [TestClass()]
    public class SeriesControllerTests
    {
        public void ConstructeurTest()
        {
            var builder = new DbContextOptionsBuilder<seriesContext>().UseNpgsql("Server=localhost;port=5432;Database=series;uid=postgres;password=postgres;");
            var context = new seriesContext(builder.Options);

            SeriesController controller = new SeriesController(context);
            Assert.IsNotNull(controller, "SeriesController ne doit pas être null");
        }

        [TestMethod()]
        public void GetSeriesTest()
        {
        }

        [TestMethod()]
        public void GetSeriesTestEchec()
        {

        }
    }
}