using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactNC6FTS_Full.Models;
using ReactNC6FTS_Full.ViewModels;

using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;


namespace ReactNC6FTS_Full.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesDBContext _context;

        public MovieController(MoviesDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetMovies")]
        public async Task<IActionResult> GetMovies()
        {      
            List<Movie> lista = await _context.Movies.OrderByDescending(c => c.Id).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("FindMoviesFullTextSearch/{searchterm}")]
        public async Task<IActionResult> FindMoviesFullTextSearch(string searchterm)
        {

            var output = string.Empty;
            var mclist = new List<MovieCastVM>();

            var castMovies = await _context.Movies
                .Join(_context.MovieCasts, m => m.Id, mc => mc.MovieId, (m, mc) => new { m, mc })
                .Join(_context.Casts, mmc => mmc.mc.CastId, c => c.Id, (mmc, c) => new { mmc, c })
                .Where(x => EF.Functions.Contains(x.mmc.m.Title, searchterm) || EF.Functions.Contains(x.mmc.m.Genre, searchterm) || EF.Functions.Contains(x.c.FirstName, searchterm) || EF.Functions.Contains(x.c.LastName, searchterm))
                .Select(mv => new
                {
                    MovId = mv.mmc.m.Id,
                    Title = mv.mmc.m.Title,
                    Genre = mv.mmc.m.Genre,
                    CastId = mv.mmc.mc.CastId,
                    FirstName = mv.c.FirstName,
                    LastName = mv.c.LastName
                }).ToListAsync();

            foreach (var movieid in castMovies.Select(o => o.MovId).Distinct().ToList())
            {
                output = string.Empty;
                var mc = new MovieCastVM();

                mc.MovieId = movieid;

                mc.Title = castMovies.OrderByDescending(c => c.MovId).Where(x => x.MovId == movieid).Select(d => d.Title).FirstOrDefault();
                mc.Genre = castMovies.OrderByDescending(c => c.MovId).Where(x => x.MovId == movieid).Select(d => d.Genre).FirstOrDefault();

                foreach (var casmember in castMovies.Where(x => x.MovId == movieid).ToList())
                {
                    dynamic jsonObject = new JObject();

                    jsonObject.CastId = casmember.CastId;
                    jsonObject.FirstName = castMovies.OrderByDescending(c => c.CastId).Where(x => x.CastId == casmember.CastId).Select(d => d.FirstName).FirstOrDefault();
                    jsonObject.LastName = castMovies.OrderByDescending(c => c.CastId).Where(x => x.CastId == casmember.CastId).Select(d => d.LastName).FirstOrDefault();

                    output = output + JsonConvert.SerializeObject(jsonObject);

                }
                mc.CastByMovie = output;
                mclist.Add(mc);
            }

            return StatusCode(StatusCodes.Status200OK, mclist);
        }


        [HttpPost]
        [Route("SaveMovie")]
        public async Task<IActionResult> SaveMovie([FromBody] Movie request)
        {
            await _context.Movies.AddAsync(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("EditMovie")]
        public async Task<IActionResult> EditMovie([FromBody] Movie request)
        {
            _context.Movies.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("DeleteMovie/{id:int}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            Movie movie = _context.Movies.Find(id);

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

    }
}
