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
    public class GroupController : Controller
    {

        IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: Group
        public ActionResult Index()
        {
            var people = _groupService.GetAll();

            //todo: use automapper
            var model = people.Select(g => new GroupModel
            {
                Name = g.Name,
            
            }).ToList();


            return View(people);
        }


        // GET: Group/Details/5
        public ActionResult Details(int id)
        {
            var group = _groupService.GetById(id);

            var model = Mapper.Map<GroupModel>(group);

            return View(model);
        }


        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        public ActionResult Create(GroupModel model)
        {
            try
            {
                // Add insert logic here

                var group = Mapper.Map<Group>(model);

                _groupService.Insert(group);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int id)
        {
            // Find group by Id from database , and send to view after using automapper
            var group = _groupService.GetById(id);

            var model = Mapper.Map<GroupModel>(group);

            return View(model);
        }

        // POST: Group/Edit/5
        [HttpPost]
        public ActionResult Edit(GroupModel model)
        {
            try
            {
                // Add update logic here
                var group = _groupService.GetById(model.GroupId);
                group.Name = model.Name;
              
                _groupService.Update(group);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int id)
        {
            var group = _groupService.GetById(id);
            var model = Mapper.Map<GroupModel>(group);

            return View(model);
        }

        // POST: Group/Delete/5
        [HttpPost]
        public ActionResult Delete(GroupModel model)
        {
            try
            {
                var group = _groupService.GetById(model.GroupId);
                _groupService.Delete(group);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}