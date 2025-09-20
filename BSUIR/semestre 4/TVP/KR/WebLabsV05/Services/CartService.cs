using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using WebLabsV05.DAL.Entities;
using WebLabsV05.Extensions;
using WebLabsV05.Models;

namespace WebLabsV05.Services
{
    public class CartService:Cart
    {
        /// <summary>
        /// Объект сессии
        /// Не записывается в сессию вместе с CartService
        /// </summary>
        [JsonIgnore]
        public ISession Session;

        // переопределение методов класса Cart
        // для сохранения результатов в сессии
        public override void AddToCart(Dish dish)
        {
            base.AddToCart(dish);
            Session?.Set<CartService>("Cart", this);
        }
        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>("Cart", this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>("Cart", this);
        }
        /// <summary>
        /// Получение объекта класса CartService
        /// </summary>
        /// <param name="serviceProvider">объект IserviceProvider</param>
        /// <returns>объекта класса CartService, приведенный к типу Cart</returns>
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            // получение сессии
            var session = serviceProvider
                .GetRequiredService<IHttpContextAccessor>()?
                .HttpContext
                .Session;
            // получение объекта CartService из сессии
            // или создание нового объекта (для возможности тестирования)
            var cartService = session?.Get<CartService>("Cart")
                ?? new CartService();
            cartService.Session = session;
            return cartService;
        }
    }
}
