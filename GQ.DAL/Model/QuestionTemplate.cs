using GQ.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GQ.DAL
{
    public class QuestionTemplate
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string QuestionText { get; set; }
        public Category category { get; set; }
        public List<string> Blanks { get; set; }

    }
}
