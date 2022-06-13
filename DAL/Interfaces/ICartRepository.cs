using LogicalSeparation.DAL.Entities;

namespace LogicalSeparation.DAL.Interfaces
{
    internal interface ICartRepository
    {
        Cart GetById(int cartId);
        void Update(Cart cart);
        void Save(Cart cart);
    }
}
