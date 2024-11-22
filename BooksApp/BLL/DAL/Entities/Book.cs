using System;
using System.Collections.Generic;

namespace BLL.DAL.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short? NumberOfPages { get; set; }

    public DateTime PublishDate { get; set; }

    public decimal Price { get; set; }

    public bool IsTopSeller { get; set; }

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}
