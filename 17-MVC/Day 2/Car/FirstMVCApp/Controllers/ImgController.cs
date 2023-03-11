using FirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp.Controllers
{
    public class ImgController : Controller
    {
        // GET: Img
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult ShowDetails(int id, string name, string selectedImg)
        {

            Img newImg = new Img();

            newImg.Id = id;
            newImg.Name = name;
            newImg.ImgNumber = selectedImg;

            ViewBag.Img = newImg;

            ImgList.Imgs.Add(newImg);   
            return View();
        }
    }
}