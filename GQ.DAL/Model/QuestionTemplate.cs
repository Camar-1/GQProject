﻿using GQ.DAL;
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
        /// Свойства Шаблона вопросов с получение идентификатора, созданием экземпляра категории шаблона
        /// </summary>
        public int Id { get; set; }


        public DateTime CreateTime { get; set; }

        public string QuestionText { get; set; }

        public Category Category { get; set; }
    }

}
//