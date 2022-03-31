﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Web.Data;
using TigerTix.Web.Data.Entities;
using TigerTix.Web.ViewModels;


namespace TigerTix.Web.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public IActionResult Index(User user)
        {
            _userRepository.SaveUser(user);
            _userRepository.SaveAll();

            return View();
        }

        public IActionResult ShowUsers()
        {
            //LINQ Query
            var results = from u in _userRepository.GetAllUsers() select u;
            return View(results.ToList());
        }

        private readonly IUserRepository _userRepository;
        public AppController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}