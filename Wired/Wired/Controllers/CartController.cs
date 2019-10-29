using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;
using System.Linq;
using Wired.Extensions;
using Wired.Models.ViewModels;

namespace Wired.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartIemRepository _cartIemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IPromoCodeRepository _promoCodeRepository;

        public CartController(ICartRepository cartRepository, ICartIemRepository cartIemRepository,
            ICustomerRepository customerRepository, IGameRepository gameRepository, IPromoCodeRepository promoCodeRepository)
        {
            _cartRepository = cartRepository;
            _cartIemRepository = cartIemRepository;
            _customerRepository = customerRepository;
            _gameRepository = gameRepository;
            _promoCodeRepository = promoCodeRepository;
        }

        private int _itemId = 0;

        public IActionResult Index()
        {
            var cart = GetCart();

            ViewBag.total = CalculateTotalFromCart(cart);
            return View(cart);
        }

        public async Task<IActionResult> AddToCart([FromQuery]int gameId)
        {
            if (gameId > 0)
            {
                try
                {
                    var game = await _gameRepository.GetById(gameId);


                    if (game != null)
                    {
                        _itemId++;
                        var cartItem = new CartItem()
                        {
                            Id = _itemId,
                            Amount = 1,
                            Game = game,
                            GameID = game.Id
                        };

                        var cart = GetCart();
                        cart.Games.Add(cartItem);
                        SaveCart(cart);
                    }

                    return Ok();
                }
                catch (Exception e)
                {

                    throw;
                }
            }

            return NoContent();
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart() { Games = new List<CartItem>() };

            return cart;
        }

        public async Task<RedirectToActionResult> RemoveFromCart(int id)
        {
            if (id > 0)
            {
                try
                {
                    var cart = GetCart();
                    var item = cart.Games.FirstOrDefault(x => x.Id == id);

                    if (item != null)
                    {
                        int userId = String.IsNullOrEmpty(HttpContext.Session.GetString("_userId")) ? 0 : int.Parse(HttpContext.Session.GetString("_userId"));

                        if (userId != 0 && cart.CustomerId == userId)
                        {
                            await _cartIemRepository.GetById(id);
                            await _cartIemRepository.Delete(item);
                        }

                        cart.Games.Remove(item);
                        SaveCart(cart);

                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception e)
                {
                    // return View("Error");
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        public IActionResult Checkout()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("_userName")))
            {
                ViewBag.Message = "Faça login para continuar.";
                return View("../Account/Index");
            }

            var cart = GetCart();

            if (!cart.Games.Any())
                return View("Index");

            var total = CalculateTotalFromCart(cart); ;

            ViewBag.subtotal = total;
            ViewBag.total = total;
            ViewBag.discount = 0;

            return View("Checkout", new CheckoutViewModel() { Cart = cart });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyDiscount(CheckoutViewModel viewModel)
        {
            try
            {
                var cart = GetCart();
                viewModel.Cart = cart;
                var subtotal = CalculateTotalFromCart(cart);

                ViewBag.total = subtotal;
                ViewBag.subtotal = subtotal;
                ViewBag.discount = 0;

                var promoCode = await GetPromocode(viewModel.Coupon);

                if (promoCode != null)
                {
                    //foreach (var item in cart.Games)
                    //{
                    //    item.Game.Price -= (promoCode.DiscountPercent * item.Game.Price / 100);
                    //}

                    var discount = (promoCode.DiscountPercent * subtotal / 100);

                    ViewBag.total = subtotal - discount;
                    ViewBag.discount = discount;

                }
                viewModel.Coupon = promoCode != null ? promoCode.Coupon : "Cupom Inválido!";
                return View("Checkout", viewModel);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private async Task<PromoCode> GetPromocode(string coupon)
        {
            if (!string.IsNullOrEmpty(coupon))
            {
                try
                {
                    var code = await _promoCodeRepository.FindOne(x => x.Coupon.Equals(coupon, StringComparison.InvariantCultureIgnoreCase));

                    if (code != null && code.UsedAmount < code.Amount)
                        return code;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return null;
        }

        private double CalculateTotalFromCart(Cart cart)
        {
            return cart.Games.Any() ? cart.Games.Sum(item => item.Game.Price * item.Amount) : 0;
        }
    }
}