using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(string UserName, string Password)
        {
            User target = _userRepository.GetUserByUserName(UserName);
            if(target != null)
            {
                if (_userRepository.verifyLogin(target, Password))
                {
                    return View("AccountPage",target);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        

        public IActionResult MakeAnAccount()
        {
            return View("MakeAnAccount");
        }

        [HttpPost("/App/MakeAnAccount")]
        public IActionResult MakeAnAccount(User target)
        {
            _userRepository.SaveUser(target);
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
        private readonly IEventRepository _eventRepository;
        public AppController(IUserRepository userRepository, IEventRepository eventRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }
        public IActionResult PostEvent()
        {
            return View("PostEvent");
        }

        [HttpPost("/App/PostEvent")]
        public IActionResult PostEvent(Event even){
            _eventRepository.SaveEvent(even);
            _eventRepository.SaveAll();

            return View("PostEvent");
        }

        public IActionResult ShowEvents()
        {
            //LINQ Query
            var results = from u in _eventRepository.GetAllEvents() select u;
            return View("ShowEvents",results.ToList());
        }

        public IActionResult RemoveEvents()
        {
            return View("RemoveEvents");
        }

        [HttpPost("/App/RemoveEvents")]
        public IActionResult RemoveEvents(int ID)
        {
            _eventRepository.DeleteEvent(_eventRepository.GetEventbyTitle(ID));
            _eventRepository.SaveAll();
            return ShowEvents();
        }

        public IActionResult RemoveUsers()
        {
            return View("RemoveUsers");
        }

        [HttpPost("/App/RemoveUsers")]
        public IActionResult RemoveUsers(int ID) 
        {
            _userRepository.DeleteUser(_userRepository.GetUsersByID(ID));
            _userRepository.SaveAll();
            return ShowUsers();
        }
    }
}