using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            CategoryService categoryService = new CategoryService(userId);
            return categoryService;
        }
       
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var cats = categoryService.GetCats();
            return Ok(cats);
        }

        public IHttpActionResult Post (CategoryCreate cat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CategoryService service = CreateCategoryService();

            if (!service.CategoryCreate(cat))
                return InternalServerError();

            return Ok();
        }

    }
}
