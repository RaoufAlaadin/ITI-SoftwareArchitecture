using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVCApp.Models
{
    public class ImgList
    {
        public static List<Img> Imgs = new List<Img>()
            {
                new Img() {Id = 5 , Name ="Raouf" ,ImgNumber = "1.jpg"},
                
            };
    }
}