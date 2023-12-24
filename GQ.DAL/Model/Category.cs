using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GQ.DAL.Model
{
    public class Category
    {

        /// <summary>
        /// Свойства категории вопросов
        /// </summary>
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public string Name { get; set; }
    }
}

