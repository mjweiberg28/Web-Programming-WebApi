using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteCharacters.Models
{
    public class FavoriteCharacterModel
    {
        public FavoriteCharacterModel()
        {
            this.Views = new int();
            this.ViewDate = new List<string>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Character { get; set; }

        public int Views { get; set; }

        public List<string> ViewDate { get; set; }
    }
}
