﻿using AutoMapper;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Applications.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model;

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == Model.CustomerId);
            var movies = _dbContext.Movies.SingleOrDefault(x => x.ID == Model.MovieId);

            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");


            var result = _mapper.Map<Order>(Model);
            result.purchasedTime = DateTime.Now;
            result.IsActive = true;

            _dbContext.Orders.Add(result);
            _dbContext.SaveChanges();
        }

        public class CreateOrderModel
        {
            public int MovieId { get; set; }
            public int CustomerId { get; set; }
            DateTime purchasedTime = DateTime.Now;
            bool movieStatus = true;
        }
    }
}
