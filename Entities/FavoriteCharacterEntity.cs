using FavoriteCharacters.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteCharacters.Entities
{
    public class FavoriteCharacterEntity
    {
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [MinLength(1)]
        [Required]
        public string Character { get; set; }

        public int Views { get; internal set; }

        public FavoriteCharacterModel ToModel()
        {
            return new FavoriteCharacterModel
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Character = this.Character
            };
        }

        public FavoriteCharacterEntity()
        {
        }

        public FavoriteCharacterEntity(FavoriteCharacterModel favoriteCharacterModel)
        {
            this.FirstName = favoriteCharacterModel.FirstName;
            this.LastName = favoriteCharacterModel.LastName;
            this.Character = favoriteCharacterModel.Character;
            this.Views = favoriteCharacterModel.ViewDate.Count();
        }
    }
}
