﻿using DynamicDataCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicDataCore.ViewComponents
{
    public class CoreAdminMenuViewComponent : ViewComponent
    {
        private readonly IEnumerable<DiscoveredDbSetEntityType> dbSetEntities;

        public CoreAdminMenuViewComponent(IEnumerable<DiscoveredDbSetEntityType> dbContexts)
        {
            this.dbSetEntities = dbContexts;
        }

        public IViewComponentResult Invoke()
        {
            MenuViewModel viewModel = new MenuViewModel();

            foreach(DiscoveredDbSetEntityType dbSetEntity in dbSetEntities)
            {
                viewModel.DbContextNames.Add(dbSetEntity.DbContextType.Name);
                viewModel.DbSetNames.Add(dbSetEntity.Name);
            }    

            return View(viewModel);
        }
    }
}
