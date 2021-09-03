using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }
        public bool CategoryCreate(CategoryCreate cat)
        {
            Categories categories = new Categories()
            {
                Name = cat.Name
            };

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(categories);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Where(e => e.OwnerId == _userId).Select(e => new CategoryListItem
                {
                    Name = e.Name
                });

                return query.ToArray();
            }
        }
    }
}
