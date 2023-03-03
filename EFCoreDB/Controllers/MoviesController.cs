using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDB.Models;
using AutoMapper;
using System.Net;
using EFCoreDB.Models.DTOs.Characters;
using EFCoreDB.Models.DTOs.Franchises;
using EFCoreDB.Services;
using EFCoreDB.Util.Exeptions;

namespace EFCoreDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(MovieService movieService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        /// <summary>
        /// Gets all the movies in the database with their related data represented as Ids.
        /// </summary>
        /// <returns>List of MovieDto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            return Ok(
                _mapper.Map<List<MovieDto>>(
                    await  _movieService.GetAllSync())
                );

        }

        /// <summary>
        /// Gets a single movie with the specified Id and maps to MovieDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single MovieDto</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<MovieDto>(
                        await _movieService.GetMovieById(id))
                    );
            }
            catch (EntityNotFoundException ex)
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
        /// Updates an existing movie. Just the values for the movie entity. 
        /// The related data can be updated in separate endpoints.
        /// Returns a failed state if the Ids dont match or the movie does not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieAsync(int id, MovieUpdateDto movie)
        {
            if (id != movie.MovieId)
                return BadRequest();

            try
            {
                await _movieService.UpdateAsync(
                        _mapper.Map<Movie>(movie)
                    );
                return NoContent();
            }
            catch (EntityNotFoundException ex)
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
        /// Adds a new movie to the database.
        /// </summary>
        /// <param name="movieDto"></param>
        [HttpPost]
        public async Task<IActionResult> PostMovieAsync(Movie movieDto)
        {
            // Mapping done separately to use the object in created at action
            Movie movie = _mapper.Map<Movie>(movieDto);
            await _movieService.AddAsync(movie);
            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);

        }

        /// <summary>
        /// Deletes a movie by its Id.
        /// Returns a failed state if the movie doesnt exist with the specified Id.
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                await _movieService.DeleteAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
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
        /// Gets all the characters for a Movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Characters in summary format</returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterSummaryDto>>> GetCharactersForMovieAsync(int id)
        {
            try
            {
                return Ok(
                        _mapper.Map<List<CharacterSummaryDto>>(
                            await _movieService.GetCharactersByMovieId(id)
                        )
                    );
            }
            catch (EntityNotFoundException ex)
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
        /// Gets the franchise for a Movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Franchise in summary format</returns>
        [HttpGet("{id}/franchise")]
        public async Task<ActionResult<IEnumerable<FranchiseSummaryDto>>> GetFranchiseForMovieAsync(int id)
        {
            try
            {
                return Ok(
                        _mapper.Map<FranchiseSummaryDto>(
                            await _movieService.GetFranchiseByMovieId(id)
                        )
                    );
            }
            catch (EntityNotFoundException ex)
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
        /// Updates the characters in movie. 
        /// Currently only returns an error state if the movie doesnt exist, 
        /// but there are provisions to add if a movie doesnt exist as well. 
        /// This is to make error handling more extendable.
        /// </summary>
        /// <param name="characterIds"></param>
        /// <param name="id"></param>
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateCharactersForMoviesAsync(int[] characterIds, int id)
        {
            try
            {
                await _movieService.UpdateCharacters(characterIds, id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
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
