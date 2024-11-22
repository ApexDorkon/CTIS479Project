using BLL.DAL;
using BLL.DAL.Entities;
using System.ComponentModel;

namespace BLL.Models
{
    public class BookModel
    {
        public Book Record { get; set; }

        [DisplayName("Book Name")]
        public string Name => Record?.Name ?? "N/A";

        [DisplayName("Pages")]
        public string NumberOfPages => Record?.NumberOfPages != null ? Record.NumberOfPages.ToString() : "N/A";

        [DisplayName("Publication Date")]
        public string PublishDate => Record?.PublishDate != null ? Record.PublishDate.ToString("MM/dd/yyyy") : "N/A";

        [DisplayName("Price (USD)")]
        public string Price => (Record?.Price) != null ? Record.Price.ToString("C2") : "N/A";

        [DisplayName("Best Seller")]
        public string IsTopSeller => Record != null && Record.IsTopSeller ? "Yes" : "No";

        [DisplayName("Author Identifier")]
        public string AuthorID => Record?.Author?.Id != null ? Record.Author.Id.ToString() : "N/A";

        [DisplayName("Author Full Name")]
        public string Author => Record?.Author != null ? $"{Record.Author.Name} {Record.Author.Surname}" : "N/A";
    }
}