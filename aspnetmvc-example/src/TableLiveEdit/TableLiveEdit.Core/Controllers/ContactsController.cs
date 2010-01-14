﻿using System.Web.Mvc;
using TableLiveEdit.Core.Lib.Data;
using TableLiveEdit.Core.Models;

namespace TableLiveEdit.Core.Controllers
{
    public class ContactsController : ApplicationController
    {
        private readonly IRepository _repository;

        public ContactsController(IRepository repository)
        {
            _repository = repository;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Contact contact)
        {
            _repository.Insert(contact);
            _repository.Commit();
            if (Request.IsAjaxRequest())
            {
                return PartialView("ShowPartial", contact);
            }
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult Delete(int id)
        {
            var contact = _repository.FindSingle<Contact>(c => c.ContactId == id);
            if (contact == null) return RedirectToAction("Error");
            _repository.Delete(contact);
            _repository.Commit();
            if (Request.IsAjaxRequest()) return new EmptyResult();
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            var contact = _repository.FindSingle<Contact>(c => c.ContactId == id);
            if (contact == null) return RedirectToAction("Error");
            if (Request.IsAjaxRequest()) return PartialView("EditPartial", contact);
            return View(contact);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var contacts = _repository.FindAll<Contact>();
            return View(contacts);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult New()
        {
            var contact = new Contact();
            if (Request.IsAjaxRequest()) return PartialView("NewPartial", contact);
            return View(contact);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Show(int id)
        {
            var contact = _repository.FindSingle<Contact>(c => c.ContactId == id);
            if (contact == null) return RedirectToAction("Error");
            if (Request.IsAjaxRequest()) return PartialView("ShowPartial", contact);
            return View(contact);
        }

        [AcceptVerbs(HttpVerbs.Post|HttpVerbs.Put)]
        public ActionResult Update(Contact contact)
        {
            var original = _repository.FindSingle<Contact>(c => c.ContactId == contact.ContactId);
            if (original == null) return RedirectToAction("Error");
            original.Update(contact);
            _repository.Commit();
            if (Request.IsAjaxRequest()) return PartialView("ShowPartial", original);
            return RedirectToAction("Index");
        }
    }
}
