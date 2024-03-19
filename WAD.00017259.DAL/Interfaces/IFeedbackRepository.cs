using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD._00017259.Models;

namespace WAD._00017259.DAL.Interfaces
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAllByProductId(int productId);
        Feedback GetById(int id);
        void Add(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(Feedback feedback);
    }
}
