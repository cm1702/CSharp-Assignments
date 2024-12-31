using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MVC_Assignment_1.Repositories;
using MVC_Assignment_1.Models;

namespace MVC_Assignment_1.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController()
        {
            _contactRepository = new ContactRepository(new ContactContext()); 
        }

        public async Task<ActionResult> Index()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return View(contacts);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            await _contactRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}