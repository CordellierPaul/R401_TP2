using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2_Series_API_Web.Models.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace TP2_Series_API_Web.Controllers.Tests
{
    [TestClass()]
    public class SeriesControllerTests
    {
        private readonly seriesContext _seriesContext;
        private readonly SeriesController _seriesController;
        private readonly Serie _serieTestId1;
        private readonly Serie _serieTestId3;

        public SeriesControllerTests()
        {
            var builder = new DbContextOptionsBuilder<seriesContext>().UseNpgsql("Server=localhost;port=5432;Database=series;uid=postgres;password=postgres;");
            _seriesContext = new seriesContext(builder.Options);
            _seriesController = new SeriesController(_seriesContext);

            _serieTestId1 = new Serie
            {
                Serieid = 1,
                Titre = "Scrubs",
                Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !",
                Nbsaisons = 9,
                Nbepisodes = 184,
                Anneecreation = 2001,
                Network = "ABC (US)"
            };

            _serieTestId3 = new Serie
            {
                Serieid = 3,
                Titre = "True Blood",
                Resume = "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...",
                Nbsaisons = 7,
                Nbepisodes = 81,
                Anneecreation = 2008,
                Network = "HBO"
            };
        }

        [TestMethod()]
        public void ConstructeurTest()
        {
            var builder = new DbContextOptionsBuilder<seriesContext>().UseNpgsql("Server=localhost;port=5432;Database=series;uid=postgres;password=postgres;");
            var seriesContext = new seriesContext(builder.Options);
            var seriesController = new SeriesController(seriesContext);

            // Assert
            Assert.IsNotNull(seriesController, "SeriesController ne doit pas être null après sa construction");
        }

        [TestMethod()]
        public void GetSeriesTest()
        {
            // Act
            ActionResult<IEnumerable<Serie>> actionResult = _seriesController.GetSeries().Result;

            // Assert
            Assert.IsNotNull(actionResult.Value, "La fonction n'a pas renvoyé de résultat : resultat.Value est null");

            List<Serie> listeSeriesRecuperees = actionResult.Value.ToList();

            Assert.AreEqual(_serieTestId1, listeSeriesRecuperees.First(x => x.Serieid == 1), "Comparaison de deux séries d'id 1 a échoué");
            Assert.AreEqual(_serieTestId3, listeSeriesRecuperees.First(x => x.Serieid == 3), "Comparaison de deux séries d'id 3 a échoué");
        }

        [TestMethod()]
        public void GetSerieTest()
        {
            // Act
            Serie? serieId1 = _seriesController.GetSerie(1).Result.Value;
            Serie? serieId3 = _seriesController.GetSerie(3).Result.Value;

            // Assert
            Assert.AreEqual(_serieTestId1, serieId1, "La série à ID 1 n'est pas correcte.");
            Assert.AreEqual(_serieTestId3, serieId3, "La série à ID 3 n'est pas correcte.");
        }

        [TestMethod()]
        public void GetSerieTestEchec()
        {
            // Act
            ActionResult<Serie> resultat = _seriesController.GetSerie(10000).Result;

            // Assert
            NotFoundResult? resultatErreur = resultat.Result as NotFoundResult;
            Assert.IsNotNull(resultatErreur, "Une erreur NotFound doit être renvoyée");
            Assert.AreEqual(resultatErreur.StatusCode, StatusCodes.Status404NotFound, "Une erreur 404 doit être renvoyée");
        }

        [TestMethod()]
        public void DeleteSerieTest()
        {
            // Crée une série fictive pour supprimer
            var serieToDelete = new Serie
            {
                Serieid = 10000,
                Titre = "Série à supprimer",
                Resume = "Résumé de la série à supprimer...",
                Nbsaisons = 5,
                Nbepisodes = 50,
                Anneecreation = 2020,
                Network = "Test Network"
            };

            // Ajoute la série fictive à la base de données pour la supprimer ensuite
            _seriesContext.Series.Add(serieToDelete);
            _seriesContext.SaveChanges();
            _seriesController.DeleteSerie(serieToDelete.Serieid).RunSynchronously();

            List<Serie> listeSeriesRecuperees = _seriesController.GetSeries().Result.Value!.ToList();

            // Vérifie si la série a été supprimée en essayant de la récupérer
            var deletedSerie = listeSeriesRecuperees.FirstOrDefault(s => s.Serieid == serieToDelete.Serieid);
            Assert.IsNull(deletedSerie, "La série n'a pas été supprimée de la base de données.");
        }
    }
}