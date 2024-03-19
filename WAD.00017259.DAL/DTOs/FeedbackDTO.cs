using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD._00017259.DAL.DTOs
{
    public class FeedbackDTO
    {
        public int FeedbackId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
    }
}
