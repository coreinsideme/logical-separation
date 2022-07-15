using System;
using System.IO;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

using LogicalSeparation.DAL.Entities;
using LogicalSeparation.DAL.Interfaces;

namespace LogicalSeparation.DAL.Repositories
{
	public class CartRepository: ICartRepository
	{
		private readonly string _dbPath = String.Concat(Directory.GetCurrentDirectory(), @"\temp.db");
		private readonly string _collectionName = "carts";

		public Cart GetById(int cartId)
		{
			Cart result = null;
			using (var db = new LiteDatabase(_dbPath))
			{
				var carts = db.GetCollection<Cart>(_collectionName);
				result =  carts.FindOne(c => c.Id == cartId);
			}

			return result;
		}

		public void Update(Cart cart)
		{
			using (var db = new LiteDatabase(_dbPath))
			{
				var carts = db.GetCollection<Cart>(_collectionName);
				var result = carts.FindOne(c => c.Id == cart.Id);
				carts.Update(cart);
			}
		}

		public void Save(Cart cart)
		{
			using (var db = new LiteDatabase(_dbPath))
			{
				var carts = db.GetCollection<Cart>(_collectionName);
				var result = carts.Count(c => c.Id == cart.Id);
				
				if (result > 0)
				{
					carts.Update(cart);
					return;
				}

				carts.Insert(cart);
			}
		}

		public void UpdateItemsWithFunc(Func<CartItem, CartItem> updateFunc)
		{
			using (var db = new LiteDatabase(_dbPath))
			{
				var carts = db.GetCollection<Cart>(_collectionName);
				var dictionary = carts.FindAll().ToDictionary(c => c.Id, c => c.Items.Select(updateFunc).ToList());

				carts.UpdateMany(cart => new Cart() { Items = dictionary.GetValueOrDefault(cart.Id) }, cart => dictionary.Keys.Contains(cart.Id));
			}
		}
	}
}
