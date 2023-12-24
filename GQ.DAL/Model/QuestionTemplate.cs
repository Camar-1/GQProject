using GQ.DAL;
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
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public string QuestionText { get; set; }

        public Category Category { get; set; }
    }

}
//