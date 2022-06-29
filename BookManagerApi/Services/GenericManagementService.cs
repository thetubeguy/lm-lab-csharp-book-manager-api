using BookManagerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookManagerApi.Services
{
    public class GenericManagementService<T> : IGenericManagementService<T> where T : IObjectHasId
    {
        private readonly BookContext _context;

        public GenericManagementService(BookContext context)
        {
            _context = context;
        }

        public bool Create(T Object)
        {
            if (!ObjectExists(Object.Id, Object))
            {
                _context.Add(Object);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool ObjectExists(long id, object _object)
        {
            if(_object is Book)
                return _context.Books.Any(b => b.Id == id);
            return _context.Authors.Any(b => b.Id == id);
        }
    }
}
