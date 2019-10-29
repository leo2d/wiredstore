using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;
using Wired.Models.ViewModels;

namespace Wired.Controllers
{
    public class CustomersController : Controller
    {

        private ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int userId = id ?? default(int);

            var customer = await _customerRepository
                .GetById(userId);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel formCustomer)
        {
            ViewBag.Register = true;

            if (ModelState.IsValid)
            {
                try
                {
                    if (await CustomerExists(formCustomer.Cpf))
                    {
                        ViewBag.error = "Já existe um usuário com este CPF";
                        return View("~/Views/Account/Index.cshtml");
                    }

                    await _customerRepository.Create
                         (
                             new Customer()
                             {
                                 Name = formCustomer.Name,
                                 Email = formCustomer.Email,
                                 Cpf = formCustomer.Cpf,
                                 Password = PasswordManager.CalculateSha1(formCustomer.Password, Encoding.Default),
                             }
                         );

                    return View("~/Views/Account/Index.cshtml");
                }
                catch (Exception e)
                {

                    throw;
                }
            }

            return View("~/Views/Account/Index.cshtml");
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            int userId = id ?? default(int);

            try
            {
                var customer = await _customerRepository
               .GetById(userId);

                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,Id,Name,Email,Password")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (customer.Password != null)
                        customer.Password = PasswordManager.CalculateSha1(customer.Password, Encoding.Default);
                    await _customerRepository.Update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception e)
                {

                }
                return View("Index");
                //return View("~/Views/Home/Index.cshtml");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int userId = id ?? default(int);
            var customer = await _customerRepository
              .GetById(userId);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        //// POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);
        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public async Task<JsonResult> CpfExistis(string cpf, int? id)
        {
            //var customer = await _context.Customers
            //    .FirstOrDefaultAsync(m => m.Cpf == cpf);

            var customer = await _customerRepository
                .GetFirstAsync(m => m.Cpf == cpf);

            if (customer == null)
                return Json("False");
            else if (customer.Id != id)
                return Json("True");

            return Json("True");
        }

        private async Task<bool> CustomerExists(int id)
        {
            return await _customerRepository.FindAnyAsync(e => e.Id == id);
        }
        private async Task<bool> CustomerExists(string cpf)
        {
            cpf = cpf.Trim();
            return await _customerRepository.FindAnyAsync(e => e.Cpf == cpf);
        }
    }
}
