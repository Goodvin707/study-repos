using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLabsV05.Models;

namespace WebLabsV05.Controllers
{
    public class HomeController : Controller
    {
        private List<ListDemo> _listDemo;

        [ViewData]
        public string Text { get; set; }

        public HomeController()
        {            
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Item 2"},
                new ListDemo{ ListItemValue=3, ListItemText="Item 3"}
            };
        }
        
        public IActionResult Index()
        {            
            ViewData["Lst"] = new SelectList(_listDemo,"ListItemValue","ListItemText");
            return View();
        }        
        
    }




    public class ListDemo
    {
        public int ListItemValue { get; set; }
        public string ListItemText { get; set; }
    }
}
