using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD._00017259.DAL.Interfaces;
using WAD._00017259.Data;
using WAD._00017259.Models;

namespace WAD._00017259.DAL.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> GetAllByProductId(int productId)
        {
            return _context.Feedbacks
                           .Where(f => f.ProductId == productId)
                           .Include(f => f.Product)
                           .ToList();
        }

        public Feedback GetById(int id)
        {
            var result = _context.Feedbacks
                           .Include(f => f.Product)
                           .FirstOrDefault(f => f.Id == id);

            if (result == null)
            {
                return new Feedback();
            }

            return result;
        }

        public void Add(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void Update(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            _context.SaveChanges();
        }

        public void Delete(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
            _context.SaveChanges();
        }
    }
}
