using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public MovieRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await appDbContext.Movies.ToListAsync();
        }

        public async Task<Movie> Get(int id)
        {
            return await appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie> Add(Movie movie)
        {
            var result = await appDbContext.Movies.AddAsync(movie);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Movie> Update(Movie movie)
        {
            var result = await appDbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == movie.Id);

            if (result != null)
            {
                result.Name = movie.Name;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Movie> Delete(int id)
        {
            var result = await appDbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (result != null)
            {
                appDbContext.Movies.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

      
    }
}
