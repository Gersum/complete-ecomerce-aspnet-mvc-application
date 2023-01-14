using eTicket.Data.Base;
using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>,IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context) { }
        
    }
}
