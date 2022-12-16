using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ropot_Anastasia_Lab2.Data;
using Ropot_Anastasia_Lab2.Models;

namespace Ropot_Anastasia_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Ropot_Anastasia_Lab2.Data.Ropot_Anastasia_Lab2Context _context;

        public IndexModel(Ropot_Anastasia_Lab2.Data.Ropot_Anastasia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public BookData BookD { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            BookD=new BookData()

                //using System
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
            
            CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books.Where(s => s.Author.FirstName.Contains(searchString)

               || s.Author.LastName.Contains(searchString)
               || s.Title.Contains(searchString));
            }

            if (_context.Book != null)
       
                BookD.Books = await _context.Book
                    .Include(b=>b.Publisher)
                    .Include(b => b.Author)
                    .OrderBy(b => b.Title)
                    .ToListAsync();

            switch (sortOrder)
                {
                    case "title_desc":
                        BookD.Books = BookD.Books.OrderByDescending(s => s.Title);
                        break;
                    case "author_desc":
                        BookD.Books = BookD.Books.OrderByDescending(s => s.Author.FullName);
                        break;
                }
            }
        }

    }
}
