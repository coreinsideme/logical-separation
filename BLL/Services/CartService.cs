using System.Collections.Generic;
using System;

using LogicalSeparation.DAL.Entities;
using LogicalSeparation.DAL.Interfaces;
using LogicalSeparation.BLL.Dtos;
using LogicalSeparation.BLL.Interfaces;

namespace LogicalSeparation.BLL.Services
{
	internal class CartService: ICartService
	{
		private readonly ICartRepository _cartRepository;
		private readonly ICartMapper _cartMapper;
        private readonly ICartItemMapper _cartItemMapper;

        public CartService(ICartRepository cartRepository, ICartMapper cartMapper, ICartItemMapper cartItemMapper)
        {
            _cartRepository = cartRepository;
			_cartMapper = cartMapper;
            _cartItemMapper = cartItemMapper;
        }

        public void Create(int id)
		{
			var cart = new Cart { Id = id };
			_cartRepository.Save(cart);
		}

		public IReadOnlyCollection<CartItemDto> GetItems(int cartId)
		{
			var cart = _cartRepository.GetById(cartId);

			if (cart is null) { throw new ArgumentException("No cart with such Id"); }

			return _cartMapper.MapToDto(cart).Items.AsReadOnly();
		}

		public void AddItem(int cartId, CartItemDto item)
		{
			var cart = _cartRepository.GetById(cartId);

			if (cart is null) { throw new ArgumentException("No cart with such Id"); }

			var itemToUpdate = cart?.Items.Find(i => i.Id == item.Id);

			if (itemToUpdate is null) { cart.Items.Add(_cartItemMapper.MapToEntity(item)); }
			else { itemToUpdate.Quantity++; }

			_cartRepository.Update(cart);
		}

		public void RemoveItem(int cartId, int itemId)
		{
			var cart = _cartRepository.GetById(cartId);

			var itemToUpdate = cart?.Items.Find(i => i.Id == itemId);

			if (itemToUpdate is null) { throw new ArgumentException("No cart with such Id or no such item"); }

			cart.Items.RemoveAll(i => i.Id == itemId);

			_cartRepository.Update(cart);
		}
	}
}
