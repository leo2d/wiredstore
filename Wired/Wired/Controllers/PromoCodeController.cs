using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;
using Wired.Models.ViewModels;

namespace Wired.Controllers
{
    public class PromoCodeController : Controller
    {
        private readonly IPromoCodeRepository _promoCodeRepository;

        public PromoCodeController(IPromoCodeRepository promoCodeRepository)
        {
            _promoCodeRepository = promoCodeRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var viewPromos = await GetPromoCodes();

                return View(viewPromos);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        private async Task<IEnumerable<PromoCodeViewModel>> GetPromoCodes()
        {
            var promos = await _promoCodeRepository.GetAll();

            var viewPromos = new List<PromoCodeViewModel>();

            foreach (var promo in promos)
            {
                viewPromos.Add
                    (
                        new PromoCodeViewModel()
                        {
                            Id = promo.Id,
                            Coupon = promo.Coupon,
                            DiscountPercent = promo.DiscountPercent,
                            Amount = promo.Amount,
                            UsedAmount = promo.UsedAmount
                        }
                    );
            }

            return viewPromos;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PromoCodeViewModel promoCodeView)
        {
            if (ModelState.IsValid)
            {
                var promoCode = new PromoCode()
                {
                    Amount = promoCodeView.Amount,
                    Coupon = promoCodeView.Coupon,
                    DiscountPercent = promoCodeView.DiscountPercent,
                };

                await _promoCodeRepository.Create(promoCode);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var promoId = id ?? default(int);
                var promoCode = await _promoCodeRepository.GetById(promoId);

                if (promoCode == null)
                {
                    return NotFound();
                }

                var promoView = new PromoCodeViewModel()
                {
                    Amount = promoCode.Amount,
                    Id = promoCode.Id,
                    Coupon = promoCode.Coupon,
                    DiscountPercent = promoCode.DiscountPercent,
                    UsedAmount = promoCode.UsedAmount
                };

                return View(promoView);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PromoCodeViewModel promoCodeView)
        {

            if (id != promoCodeView.Id)
            {
                return NotFound();
            }

            try
            {
                var promocode = await _promoCodeRepository.GetById(id);

                promocode.Amount = promoCodeView.Amount;
                promocode.Coupon = promoCodeView.Coupon;
                promocode.DiscountPercent = promoCodeView.DiscountPercent;

                await _promoCodeRepository.Update(promocode);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> ValidateCoupon(string coupon)
        {
            if (!string.IsNullOrEmpty(coupon))
            {
                try
                {
                    var code = await _promoCodeRepository.FindOne(x => x.Coupon.Equals(coupon, StringComparison.InvariantCultureIgnoreCase));

                    if (code != null && code.UsedAmount < code.Amount)
                    {
                        return Ok(code);
                    }
                    return NotFound();
                }
                catch (Exception e)
                {
                    return View("Error");
                }
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var promoCode = await _promoCodeRepository.GetById(id);
                await _promoCodeRepository.Delete(promoCode);
            }
            catch (Exception e)
            {
                return View("Error");
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int nId = id ?? default(int);
            var promoCode = await _promoCodeRepository.GetById(nId);

            if (promoCode == null)
            {
                return NotFound();
            }

            var promoView = new PromoCodeViewModel()
            {
                Amount = promoCode.Amount,
                Coupon = promoCode.Coupon,
                DiscountPercent = promoCode.DiscountPercent,
                Id = promoCode.Id,
                UsedAmount = promoCode.UsedAmount
            };

            return View(promoView);
        }
    }
}