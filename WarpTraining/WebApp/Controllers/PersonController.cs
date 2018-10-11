using Library.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Data;
using Library.Data.Models.Common;
using AutoMapper;

namespace WebApp.Controllers
{
    public class PersonController : Controller
    {
		IPersonService _personService;

        public PersonController(IPersonService personService)
		{
			_personService = personService;
		}

        // GET: Person
        public ActionResult Index()
        {
			var people = _personService.GetAll();

            //todo: use automapper
            var model = people.Select(p=> new PersonModel{
				Name = p.Name,
				Email = p.Email
			}).ToList();


            return View(people);
        }

      
        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var person = _personService.GetById(id);

            var model = Mapper.Map<PersonModel>(person);

            return View(model);
        }
        

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            try
            {
                // Add insert logic here

                var person = Mapper.Map<Person>(model);

                _personService.Insert(person);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            // Find person by Id from database , and send to view after using automapper
            var person = _personService.GetById(id);

            var model = Mapper.Map<PersonModel>(person);

            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonModel model)
        {
            try
            {
                // Add update logic here
                var person = _personService.GetById(model.PersonId);
                person.Name = model.Name;
                person.Email = model.Email;

                _personService.Update(person);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var person = _personService.GetById(id);
            var model = Mapper.Map<PersonModel>(person);

            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(PersonModel model)
        {
            try
            {
                var person = _personService.GetById(model.PersonId);
                _personService.Delete(person);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
