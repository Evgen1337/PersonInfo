using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PeopleInfo.DAL;
using PeopleInfo.Models;

namespace PeopleInfo.Controllers
{
    public class HomeController : Controller
    {
        

        IUserRepository userRepository;

         

        public HomeController()
        {
            userRepository = new UserRepository(new UserContext());

            //Mapper.CreateMap<User, UserViewModel>();           
        }


        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Index", ""));
            }
            
        }

        /// <summary>
        /// Гет метод получения данных
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult GetData()
        {
            try
            {
                List<User> data = userRepository.GetAll().ToList<User>();
                List<UserViewModel> userViewModels = new List<UserViewModel>();
                //foreach (var user in data)
                //{
                //    userViewModels.Add(new UserViewModel
                //    {
                //        Id = user.Id,
                //        Name = user.Name,
                //        LastName = user.LastName,
                //        FatherName = user.FatherName,
                //        Email = user.Email,
                //        Number = user.Number,
                //        BirthDay = user.BirthDay,
                //        Inn = user.Inn

                //    });
                //}
                userViewModels = AutoMapper.Mapper.Map<List<User>, List<UserViewModel>>(data);

                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Index", "GetData"));
            }     
        }

       /// <summary>
       /// Post метод удаления данных
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>

        [HttpPost]
        public JsonResult DeleteData(int id)
        {
            try
            {
                User d = userRepository.GetAll().Where(m => m.Id == id).FirstOrDefault<User>();
                List<User> userViewModels = new List<User>();
                userRepository.Remove(d);
                userRepository.SaveChanges();

                return Json(new { result = true, message = "Данные успешно удалены" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
            
        }

        /// <summary>
        /// Post метод обновления или записи в бд
        /// </summary>
        /// <param name="user_C"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult PostData(User user_C)
        {
            try
            {
                
                ///Не проходит валидацию т.к. при создании нового контакта  присылается Id = 0 и к сожалению не смог решить эту проблему
                ///проблема возникает только при создании - при перезаписи валидация успешна
                //if (ModelState.IsValid)
                //{

                    if (user_C.Id > 0)
                        {
                            User crud = userRepository.GetAll().Where(model => model.Id == user_C.Id).FirstOrDefault<User>();


                            crud.Name = user_C.Name;
                            crud.LastName = user_C.LastName;
                            crud.FatherName = user_C.FatherName;
                            crud.Email = user_C.Email;
                            crud.Number = user_C.Number;
                            crud.BirthDay = user_C.BirthDay;
                            crud.Gender = user_C.Gender;
                            crud.Inn = user_C.Inn;
                            userRepository.SaveChanges();

                            return Json(new { result = true, message = "Данные успешно обновленны" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            User checkInn = null;
                            User checkNFB = null;
                            User checkNFN = null;

                            using (UserContext userRepository = new UserContext())
                            {
                                checkInn = userRepository.User.FirstOrDefault(u => u.Inn == user_C.Inn);
                                checkNFB = userRepository.User.FirstOrDefault(u => u.Name == user_C.Name && u.LastName == user_C.LastName && u.BirthDay == user_C.BirthDay);
                                checkNFN = userRepository.User.FirstOrDefault(u => u.Name == user_C.Name && u.LastName == user_C.LastName && u.Number == user_C.Number);
                            }


                            if (checkInn == null && checkNFB == null && checkNFN == null)
                            {


                                User obb = new User();


                                obb.Name = user_C.Name;
                                obb.LastName = user_C.LastName;
                                obb.Email = user_C.Email;
                                obb.FatherName = user_C.FatherName;
                                obb.Number = user_C.Number;
                                obb.BirthDay = user_C.BirthDay;
                                obb.Gender = user_C.Gender;
                                obb.Inn = user_C.Inn;
                                userRepository.Add(obb);
                                userRepository.SaveChanges();

                                return Json(new { result = true, message = "Данные успешно сохранены" }, JsonRequestBehavior.AllowGet);
                            }


                        }

                        return Json(new { result = false, message = "Такой пользователь уже существует" }, JsonRequestBehavior.AllowGet);

                //}

                return Json(new { result = false, message = "Sore" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Get метод перезаписи данных
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult GetEdit(int id)
        {
            try
            {
                var de = userRepository.GetAll().Where(model => model.Id == id).FirstOrDefault();
                return Json(de, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Index", "GetData"));
            }
            
        }

        /// <summary>
        /// Метод отображения данных
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult ShowInfo(int id)
        {
            try
            {
                var sh = userRepository.GetAll().Where(model => model.Id == id).FirstOrDefault();
                return Json(sh, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Index", "GetData"));
            }

        }

        //public JsonResult DeleteDataRow(string[] rows)
        //{
        //    int[] getId = null;
        //    if (rows != null)
        //    {
        //        getId = new int[rows.Length];
        //        int j = 0;
        //        foreach (string i in rows)
        //        {
        //            int.TryParse(i, out getId[j++]);
        //        }

        //        List<User> getRows = new List<User>();
        //        getRows = userRepository.GetAll().Where(x => getId.Contains(x.Id)).ToList();

        //        foreach (var s in getId)
        //        {
        //            userRepository.Remove(s);

        //        }
        //        userRepository.SaveChanges();
        //    }
        //    return Json(JsonRequestBehavior.AllowGet);
        //}


        /// <summary>
        /// Post метод проверки на наличия в бд ИНН
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckInnAvailability(string user)
        {
            

            var SeachData1 = userRepository.GetAll().Where(x => x.Inn.ToString() == user).SingleOrDefault();
                

                if (SeachData1 != null)
                {
                    return Json(1);
                }
                else
                {
                    return Json(0);
                }

        }


        /// <summary>
        /// Post метод проверки на наличие в бд Номера телефона
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public JsonResult CheckNumberAvailability(string user)
        {

            var SeachData1 = userRepository.GetAll().Where(x => x.Number.ToString() == user).SingleOrDefault();
          

            if (SeachData1 != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }

        /// <summary>
        /// Post метод проверки на наличие в бд Имени+Фамилии+Даты рождения
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        [AllowAnonymous]
        public JsonResult CheckNameLastNDateBirthAvailability(User user)
        {
            var SeachData2 = userRepository.GetAll().Where(x => x.Name == user.Name && x.LastName == user.LastName && x.BirthDay == user.BirthDay).SingleOrDefault();
            
            if (SeachData2 != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

    }
}