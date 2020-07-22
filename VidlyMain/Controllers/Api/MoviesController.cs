using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using VidlyMain.Dtos;
//using System.Web.Mvc;
using VidlyMain.Models;

namespace VidlyMain.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly MyDbContext _dbContext;

        public MoviesController()
        {
            this._dbContext = new MyDbContext();
        }
        
        //GET /api/movies
        public IEnumerable<MoviesDto> GetMovies()
        {
            return this._dbContext.Movies.ToList().Select(Mapper.Map<Movies,MoviesDto>);
        }

        //GET /api/movies/1
        public MoviesDto GetMovie(int id)
        {
            var movieFromDB = this._dbContext.Movies.FirstOrDefault(m => m.Id == id);
            if(movieFromDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Movies,MoviesDto>(movieFromDB);
        }

        //POST /api/movies
        [HttpPost]
        public MoviesDto CreateMovie(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movies = Mapper.Map<MoviesDto, Movies>(moviesDto);

            this._dbContext.Movies.Add(movies);
            this._dbContext.SaveChanges();
            moviesDto.Id = movies.Id;
            return moviesDto;

        }

        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MoviesDto moviesDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = this._dbContext.Movies.FirstOrDefault(m => m.Id == id);
            Mapper.Map<MoviesDto, Movies>(moviesDto, movieInDb);

            this._dbContext.SaveChanges();

        }

        //DELETE /api/movies/1

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = this._dbContext.Movies.FirstOrDefault(m => m.Id == id);

          // var mapperMovie= Mapper.Map<MoviesDto, Movies>(movieInDb);
            this._dbContext.Movies.Remove(movieInDb);
            this._dbContext.SaveChanges();
        }
    }
}