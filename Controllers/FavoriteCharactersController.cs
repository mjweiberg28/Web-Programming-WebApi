using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FavoriteCharacters.Entities;
using FavoriteCharacters.Models;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteCharacters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCharactersController : Controller
    {
        public static List<FavoriteCharacterModel> favoriteCharacters = new List<FavoriteCharacterModel>()
        {
            new FavoriteCharacterModel {FirstName = "Micah", LastName = "Weiberg", Character = "Darth Sidious",
            ViewDate = new List<string>() { "Today" } }
        };

        [HttpGet]
        public IEnumerable<FavoriteCharacterEntity> Get()
        {
            return favoriteCharacters.Select(element => new FavoriteCharacterEntity(element));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            if (id < 0 || id >= favoriteCharacters.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return Json(new FavoriteCharacterEntity(favoriteCharacters[id]));
        }

        [HttpPost]
        public FavoriteCharacterEntity Post([FromBody] FavoriteCharacterEntity favoriteCharacter)
        {
            if (favoriteCharacters.Count() >= 30)
            {
                favoriteCharacters.Clear();
            }

            favoriteCharacters.Add(favoriteCharacter.ToModel());

            return favoriteCharacter;
        }

        [HttpGet("{id:int}/views")]
        public IActionResult GetView(int id)
        {
            if (id < 0 || id >= favoriteCharacters.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return Json(new ViewEntity(favoriteCharacters[id]));
        }

        [HttpPost("{id:int}/views")]
        public ViewEntity PostView([FromBody] ViewEntity entity, int id)
        {
            //favoriteCharacters.Insert(id, entity.ToModel());
            favoriteCharacters.Add(entity.ToModel());

            return entity;
        }

        //[HttpPut("{id:int}")]
        //public IActionResult Put([FromBody] FavoriteCharacterEntity favoriteCharacter, int id)
        //{
        //    if (id < 0 || id >= favoriteCharacters.Count)
        //    {
        //        return StatusCode((int) HttpStatusCode.NotFound);
        //    }

        //    favoriteCharacters[id] = favoriteCharacter.ToModel();

        //    return Json(favoriteCharacter);
        //}

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= favoriteCharacters.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            favoriteCharacters.RemoveAt(id);

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
