using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore02.Database;
using Contactenlijst.Domain;
using Contactenlijst.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contactenlijst.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactDatabase _contactDatabase;
        public ContactController(IContactDatabase contactDatabase)
        {
            _contactDatabase = contactDatabase;
        }
        public IActionResult Index()
        {

            var contacts = _contactDatabase.GetContacts().Select(x => new ContactListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Telnr = x.TelNr
            });


            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ContactCreateViewModel contact)
        {
            if (TryValidateModel(contact))
            {
                _contactDatabase.Insert(new Contact
                {
                    Name = contact.Name,
                    Surname = contact.Surname,
                    Email = contact.Email,
                    BirthDate = contact.BirthDate,
                    TelNr = contact.TelNr,
                    Address = contact.Address,
                    Annotation = contact.Annotation
                });

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Details([FromRoute] int id)
        {
            Contact contact = _contactDatabase.GetContact(id);

            return View(new ContactDetailViewModel
            {
                Id = contact.Id,
                Name = contact.Name,
                Surname = contact.Surname,
                BirthDate = contact.BirthDate,
                Email = contact.Email,
                TelNr = contact.TelNr,
                Address = contact.Address,
                Annotation = contact.Annotation
            });
        }
        public IActionResult Update([FromRoute] int id)
        {
            Contact contact = _contactDatabase.GetContact(id);
            return View(new ContactEditViewModel
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Email = contact.Email,
                BirthDate = contact.BirthDate,
                TelNr = contact.TelNr,
                Address = contact.Address,
                Annotation = contact.Annotation
            });
        }
        [HttpPost]
        public IActionResult Update([FromForm] ContactEditViewModel vm, [FromRoute] int id)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            _contactDatabase.Update(id, new Contact
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                BirthDate = vm.BirthDate,
                TelNr = vm.TelNr,
                Address = vm.Address,
                Annotation = vm.Annotation
            });

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete([FromRoute] int id)
        {
            var contact = _contactDatabase.GetContact(id);

            return View(new ContactDeleteViewModel
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Id = contact.Id
            });
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int id)
        {
            _contactDatabase.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
