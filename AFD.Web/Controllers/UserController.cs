using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AFD.Data.EntityFramework;
using AFD.Model;
using AFD.Services.Implementation;
using AFD.Web.Models;

namespace AFD.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService = new UserService();

        public UserController()
        {
        }

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            List<User> users = _userService.ReadUsers();

            if (users == null) return View();

            var viewModel = users
                .ToList()
                .Select(
                    x =>
                        new UserViewModels
                        {
                            Address = x.Address,
                            Id = x.Id,
                            Name = x.Name,
                            PhoneNumber = x.PhoneNumber
                        });
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult CreateUser(UserViewModels objUser)
        {
            try
            {
                if (objUser.Name.Equals(string.Empty) && objUser.Address.Equals(string.Empty) &&
                    objUser.PhoneNumber.Equals(string.Empty))
                {
                    return null;
                }

                _userService.CreateUser(new User(objUser.Name, objUser.Address, objUser.PhoneNumber));
                return Json(objUser, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        public JsonResult EditUser(int id)
        {
            try
            {
                var user = _userService.FindUser(id);
                var usr = new UserViewModels();

                if (user != null)
                {
                    usr.Address = user.Address;
                    usr.Name = user.Name;
                    usr.Id = user.Id;
                    usr.PhoneNumber = user.PhoneNumber;

                    return Json(usr, JsonRequestBehavior.AllowGet);
                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpPost]
        public JsonResult EditUser(User objUser)
        {
            try
            {
                _userService.UpdateUser(objUser);
                return Json(objUser, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public JsonResult GetDetails(int id)
        {
            try
            {
                var user = _userService.FindUser(id);
                return user != null ? Json(user, JsonRequestBehavior.AllowGet) : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            try
            {
                using (JsonContext context = new JsonContext())
                {
                    var user = context.ObjUser.Find(id);
                    if (user != null)
                    {
                        context.ObjUser.Remove(user);
                        context.SaveChanges();
                        return Json(user, JsonRequestBehavior.AllowGet);
                    }
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}