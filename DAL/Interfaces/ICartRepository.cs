using LogicalSeparation.DAL.Entities;

namespace LogicalSeparation.DAL.Interfaces
{
    public interface ICartRepository
    {
        Cart GetById(int cartId);
        void Update(Cart cart);
        void Save(Cart cart);
    }
}
