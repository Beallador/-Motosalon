using Microsoft.AspNetCore.Mvc;
using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Controllers
{
    public class HomeController:Controller
    {
        private readonly IAllMoto _motoRepository;

        public HomeController(IAllMoto motoRepository)
        {
            _motoRepository = motoRepository;
        }


        public ViewResult Index()
        {
            var homeMoto = new HomeViewModel
            {
                favMoto = _motoRepository.GetFavoriteMotos
            };
            return View(homeMoto);
        }

        public ViewResult About()
        { return View(); }


    }
}
