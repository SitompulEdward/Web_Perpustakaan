﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Perpustakaan.Controllers
{
    public class PengembalianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}