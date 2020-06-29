using FavoriteCharacters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteCharacters.Entities
{
    public class ViewEntity
    { 
        public List<string> ViewDate { get; internal set; }

        public FavoriteCharacterModel ToModel()
        {
            return new FavoriteCharacterModel
            {
                ViewDate = this.ViewDate
            };
        }

        public ViewEntity()
        {
        }

        public ViewEntity(FavoriteCharacterModel favoriteCharacterModel)
        {
            this.ViewDate = favoriteCharacterModel.ViewDate;
        }
    }
}
