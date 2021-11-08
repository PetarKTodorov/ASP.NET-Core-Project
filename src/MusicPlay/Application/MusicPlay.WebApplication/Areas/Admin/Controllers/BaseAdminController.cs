﻿namespace MusicPlay.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MusicPlay.Database;

    [Area("Admin")]
    //[Authorize(Roles = "admin")]
    public class BaseAdminController : Controller
    {
        public BaseAdminController(MusicPlayDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public MusicPlayDbContext DbContext { get; set; }
    }
}