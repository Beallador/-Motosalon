using Microsoft.AspNetCore.Mvc;
using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Controllers
{
    public class MotoController : Controller
    {
        private readonly IAllMoto _allMoto;
        private readonly IMotosCategory _motosCategory;

        public MotoController(IMotosCategory iMotoCategory, IAllMoto iAllMoto)
        {
            _allMoto = iAllMoto;
            _motosCategory = iMotoCategory;
        }

        public ViewResult ViewMoto()
        {
            MotoViewModel obj = new MotoViewModel();
            obj.allMoto = _allMoto.Motos;
            obj.currCategory = "";
            return View(obj);
        }
    }
}
