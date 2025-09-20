using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebLabsV05.DAL.Entities;
using WebLabsV05.Models;
using WebLabsV05.Extensions;
using WebLabsV05.DAL.Data;
using Microsoft.Extensions.Logging;

namespace WebLabsV05.Controllers
{
    public class ProductController : Controller
    {
        public List<Dish> _dishes { get; set; }
        List<DishGroup> _dishGroups;
        ApplicationDbContext _context;
        private ILogger _logger;

        int _pageSize;

        public ProductController(ApplicationDbContext context, 
                ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
            //SetupData();
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo=1}")]
        public IActionResult Index(int? group, int pageNo)
        {
            var groupMame = group.HasValue
                ? _context.DishGroups.Find(group.Value)?.GroupName
                : "all groups";
           // _logger.LogInformation("info: group={groupMame},  page={pageNo}",groupMame,pageNo);

            var dishesFiltered = _context.Dishes
                .Where(d => !group.HasValue || d.DishGroupId == group.Value);

            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DishGroups;

            // Получить id текущей группы и поместить в TempData
            var currentGroup = group.HasValue
                ? group.Value
                : 0;
            
            ViewData["CurrentGroup"] = currentGroup;


            //if (Request.Headers["x-requested-with"] == "XMLHttpRequest")
            if (Request.IsAjaxRequest())
                    return PartialView("_ListPartial", ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
            return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _dishGroups = new List<DishGroup>
            {
                new DishGroup {DishGroupId=1, GroupName="Стартеры"},
                new DishGroup {DishGroupId=2, GroupName="Салаты"},
                new DishGroup {DishGroupId=3, GroupName="Супы"},
                new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
                new DishGroup {DishGroupId=5, GroupName="Напитки"},
                new DishGroup {DishGroupId=6, GroupName="Десерты"}
            };

            _dishes = new List<Dish>
            {
                new Dish { DishId = 1, DishName="Суп-харчо", Description="Очень острый, невкусный",
                                Calories =200, DishGroupId=3, Image="Суп.jpg" },
                            new Dish {DishId = 2, DishName="Борщ", Description="Много сала, без сметаны",
                                Calories =330, DishGroupId=3, Image="Борщ.jpg" },
                            new Dish {DishId = 3, DishName="Котлета пожарская", Description="Хлеб - 80%, Морковь - 20%",
                                Calories =635, DishGroupId=4, Image="Котлета.jpg" },
                            new Dish {DishId = 4 ,DishName="Макароны по-флотски", Description="С охотничьей колбаской",
                                Calories =524, DishGroupId=4, Image="Макароны.jpg" },
                            new Dish {DishId = 5, DishName="Компот", Description="Быстро растворимый, 2 литра",
                                Calories =180, DishGroupId=5, Image="Компот.jpg" }
            };
        }
    }
}