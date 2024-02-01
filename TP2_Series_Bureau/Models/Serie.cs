using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Series_Bureau.Models
{
    public class Serie
    {
        public Serie() : this(0, "", "", 0, 0, 0, "") { }

        //public Serie() { }

        public Serie(int serieid, string titre, string resume, int nbsaisons, int nbepisodes, int anneecreation, string network)
        {
            Serieid = serieid;
            Titre = titre;
            Resume = resume;
            Nbsaisons = nbsaisons;
            Nbepisodes = nbepisodes;
            Anneecreation = anneecreation;
            Network = network;
        }

        public int Serieid { get; set; }

        public string Titre { get; set; }

        public string Resume { get; set; }

        public int Nbsaisons { get; set; }

        public int Nbepisodes { get; set; }

        public int Anneecreation { get; set; }

        public string Network { get; set; }
    }
}
