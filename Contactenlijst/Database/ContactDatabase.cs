using Contactenlijst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore02.Database
{
    public interface IContactDatabase
    {
        Contact Insert(Contact contact);
        IEnumerable<Contact> GetContacts();
        Contact GetContact(int id);
        void Delete(int id);
        void Update(int id, Contact movie);
    }

    public class ContactDatabase : IContactDatabase
    {
        private int _counter;
        private readonly List<Contact> _contacts;

        public ContactDatabase()
        {
            if (_contacts == null)
            {
                _contacts = new List<Contact>();

                // Dummy entries
                _contacts.Add(new Contact { Name = "Test", Surname = "Dummy" });
            }
        }

        public Contact GetContact(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public Contact Insert(Contact contact)
        {
            _counter++;
            contact.Id = _counter;
            _contacts.Add(contact);
            return contact;
        }

        public void Delete(int id)
        {
            var contact = _contacts.SingleOrDefault(x => x.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public void Update(int id, Contact updatedContact)
        {
            var contact = _contacts.SingleOrDefault(x => x.Id == id);
            if (contact != null)
            {
                contact.Name = updatedContact.Name;
                contact.Surname = updatedContact.Surname;
                contact.BirthDate = updatedContact.BirthDate;
                contact.Email = updatedContact.Email;
                contact.TelNr = updatedContact.TelNr;
                contact.Address = updatedContact.Address;
                contact.Annotation = updatedContact.Annotation;
            }
        }
    }
}
