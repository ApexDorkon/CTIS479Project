using System.Linq;
using BLL.Models;
using BLL.DAL.Entities;

namespace BLL.Services.Bases
{
    public interface IAuthor
    {
        /// <summary>
        /// Query all authors.
        /// </summary>
        IQueryable<AuthorModel> Query();

        /// <summary>
        /// Create a new author.
        /// </summary>
        ServiceBase Create(Author record);

        /// <summary>
        /// Update an existing author.
        /// </summary>
        ServiceBase Update(Author record);

        /// <summary>
        /// Delete an author by ID.
        /// </summary>
        ServiceBase Delete(int id);
    }
}
