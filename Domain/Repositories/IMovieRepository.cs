using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
       
         Task<IEnumerable<Movie>> GetAll();
         Task<Movie> Get(int id);
         Task<Movie> Add(Movie m);
         Task<Movie> Update(Movie m);
         Task<Movie> Delete(int id);
        
    }
}
