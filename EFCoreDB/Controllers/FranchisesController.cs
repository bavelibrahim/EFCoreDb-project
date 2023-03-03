using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDB.Models;
using EFCoreDB.Services;
using AutoMapper;
using EFCoreDB.Models.DTOs.Franchises;
using EFCoreDB.Util.Exeptions;
using System.Net;
using EFCoreDB.Models.DTOs.Characters;
using EFCoreDB.Models.DTOs.Movies;

namespace EFCoreDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly FranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(FranchiseService franchiseService, IMapper mapper)
        {
            _mapper = mapper;
            _franchiseService= franchiseService;
        }

        /// <summary>
        /// Gets all the franchises in the database with their related data represented as Ids.
        /// </summary>
        /// <returns>List of FranchiseDto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDto>>> GetFranchises()
        {
            return Ok(
                _mapper.Map<List<FranchiseDto>>(
                    await _franchiseService.GetAllSync())
                );
        }

        /// <summary>
        /// Gets a single franchise with the specified Id and maps to FranchiseDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single FranchiseDto</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDto>> GetFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<FranchiseDto>(
                        await _franchiseService.GetFranchiseById(id))
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
        /// Updates an existing franchise. Just the values for the franchise entity. 
        /// The related data can be updated in separate endpoints.
        /// Returns a failed state if the Ids dont match or the franchise does not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchiseAsync(int id, FranchiseUpdateDto franchise)
        {
            if (id != franchise.FranchiseId)
                return BadRequest();

            try
            {
                await _franchiseService.UpdateAsync(
                        _mapper.Map<Franchise>(franchise)
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
        /// Adds a new franchise to the database.
        /// </summary>
        /// <param name="franchiseDto"></param>
        [HttpPost]
        public async Task<IActionResult> PostFranchiseAsync(FranchiseCreateDto franchiseDto)
        {
            // Mapping done separately to use the object in created at action
            Franchise franchise = _mapper.Map<Franchise>(franchiseDto);
            await _franchiseService.AddAsync(franchise);
            return CreatedAtAction("GetFranchise", new { id = franchise.FranchiseId }, franchise);

        }

        /// <summary>
        /// Deletes a franchise by its Id.
        /// Returns a failed state if the franchise doesnt exist with the specified Id.
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete("{id}")]
        public async Task<IActionResult> FranchiseMovieAsync(int id)
        {
            try
            {
                await _franchiseService.DeleteAsync(id);
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
        /// Gets all the movies for a Franchise.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Movies in summary format</returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieSummaryDto>>> GetMoviesForFranchiseAsync(int id)
        {
            try
            {
                return Ok(
                        _mapper.Map<List<MovieSummaryDto>>(
                            await _franchiseService.GetMoviesByFranchiseId(id)
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
        /// Updates the movies in a franchise. 
        /// Currently only returns an error state if the franchise doesnt exist, 
        /// but there are provisions to add if a franchise doesnt exist as well. 
        /// This is to make error handling more extendable.
        /// </summary>
        /// <param name="movieIds"></param>
        /// <param name="id"></param>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesForFranchiseAsync(int[] movieIds, int id)
        {
            try
            {
                await _franchiseService.UpdateMovies(movieIds, id);
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

