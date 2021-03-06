﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Models;

namespace WebDeveloper.Areas.Person.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly PersonRepository _personRepository;
        public PersonController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public ActionResult Index()
        {
            return View(_personRepository.GetListDto());
        }

        public PartialViewResult EmailList(int? id)
        {
            if(!id.HasValue) return null;
            return PartialView("_EmailList",_personRepository.EmailList(id.Value));
        }
    }
}