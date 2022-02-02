﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Perpustakaan.Data;

namespace Web_Perpustakaan.Controllers
{
    public class PeminjamanController : Controller
    {
        private readonly AppDbContext _context;
        public PeminjamanController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}