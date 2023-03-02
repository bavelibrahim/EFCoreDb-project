using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDB.Models;
using AutoMapper;
using EFCoreDB.Services;
using EFCoreDB.Util.Exeptions;
using System.Net;
using EFCoreDB.Models.DTOs.Characters;
using EFCoreDB.Models.DTOs.Movies;

namespace EFCoreDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterService _characterService;
        private readonly IMapper _mapper;

        public CharactersController(CharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all the characters in the database with their related data represented as Ids.
        /// </summary>
        /// <returns>List of CharacterDto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
        {
            return Ok(
                _mapper.Map<List<CharacterDto>>(
                    await _characterService.GetAllSync())
                );

        }

        /// <summary>
        /// Gets a single character with the specified Id and maps to CharacterDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single CharacterDto</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<CharacterDto>(
                        await _characterService.GetCharacterById(id))
                    );
            }
            catch (EntityNotFoundExeption ex)
            {

                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }
        }

        /// <summary>
        /// Updates an existing character. Just the values for the character entity. 
        /// The related data can be updated in separate endpoints.
        /// Returns a failed state if the Ids dont match or the character does not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterAsync(int id, CharacterUpdateDto character)
        {
            if (id != character.CharacterId)
                return BadRequest();

            try
            {
                await _characterService.UpdateAsync(
                        _mapper.Map<Character>(character)
                    );
                return NoContent();
            }
            catch (EntityNotFoundExeption ex)
            {

                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }


        }

        /// <summary>
        /// Adds a new character to the database.
        /// </summary>
        /// <param name="characterDto"></param>
        [HttpPost]
        public async Task<IActionResult> PostCharacterAsync(CharacterDto characterDto)
        {
            // Mapping done separately to use the object in created at action
            Character character = _mapper.Map<Character>(characterDto);
            await _characterService.AddAsync(character);
            return CreatedAtAction("GetCharacter", new { id = character.CharacterId }, character);

        }

        /// <summary>
        /// Deletes a character by its Id.
        /// Returns a failed state if the character doesnt exist with the specified Id.
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterAsync(int id)
        {
            try
            {
                await _characterService.DeleteAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundExeption ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }

        }

        /// <summary>
        /// Gets all the movies for a character.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of movies in summary format</returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<MovieSummaryDto>>> GetMoviesForCharacterAsync(int id)
        {
            try
            {
                return Ok(
                        _mapper.Map<List<MovieSummaryDto>>(
                            await _characterService.GetMoviesByCharacterId(id)
                        )
                    );
            }
            catch (EntityNotFoundExeption ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }
        }

        /// <summary>
        /// Updates the movies a character is in. 
        /// Currently only returns an error state if the character doesnt exist, 
        /// but there are provisions to add if a character doesnt exist as well. 
        /// This is to make error handling more extendable.
        /// </summary>
        /// <param name="movieIds"></param>
        /// <param name="id"></param>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesForCharactersAsync(int[] movieIds, int id)
        {
            try
            {
                await _characterService.UpdateMovies(movieIds, id);
                return NoContent();
            }
            catch (EntityNotFoundExeption ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }
        }
    }
}
