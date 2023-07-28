using MovieStoreApi.DbOperations;

namespace MovieStoreApi.Applications.OrderOperations.Commands.DeleteOrder
{
    public class SoftDeleteOrderCommand
    {
        public int OrderId;
        private readonly IMovieStoreDbContext _dbContext;
        public SoftDeleteOrderCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == OrderId);
            if (order is null)
                throw new InvalidOperationException("ilgili kayda ait veri bulunamadı!");

            order.IsActive = false;
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}
