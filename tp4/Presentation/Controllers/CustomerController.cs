using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tp4.Core.Entities;
using tp4.Application.Services;
using tp4.Core.Interfaces.Services;

namespace tp4.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        public IActionResult Create()
        {
            PopulateMembershipTypes();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.CreateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            PopulateMembershipTypes(customer.MembershipTypeId);
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            PopulateMembershipTypes(customer.MembershipTypeId);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.UpdateCustomer(customer);
                }
                catch (Exception)
                {
                    if (_customerService.GetCustomerById(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateMembershipTypes(customer.MembershipTypeId);
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _customerService.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }

        private void PopulateMembershipTypes(int? selectedTypeId = null)
        {
            ViewData["MembershipTypeId"] = new SelectList(_customerService.GetCustomersWithMembershipType(), "Id", "Name", selectedTypeId);
        }

        public IActionResult FavoriteMovies(int customerId)
        {
            var favoriteMovies = _customerService.GetFavoriteMovies(customerId);
            return View(favoriteMovies);
        }

        public IActionResult GetFavoriteMovies(int customerId)
        {
            var favoriteMovies = _customerService.GetFavoriteMovies(customerId);
            return View(favoriteMovies);
        }


    }
}
