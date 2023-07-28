using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Applications.OrderOperations.Model;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Applications.OrderOperations.Querys
{
    public class GetListOrderQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetListOrderQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public List<OrderViewModel> Handle()
        {
            List<Customer> list = _dbContext.Customers.Include(a => a.Orders).ThenInclude(b => b.Movie).Where(c => c.Orders.Any(d => d.IsActive)).OrderBy(e => e.Id).ToList();
            List<OrderViewModel> vm = _mapper.Map<List<OrderViewModel>>(list);
            return vm;
        }
    }
}
