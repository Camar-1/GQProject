﻿using GQ.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GQ.BLL
{
    public class QuestionService
    {
        public bool AddTemplateQuestion(QuestionTemplate questionTemplate)
        {
            Repository repository = new Repository();

            var result = repository.CreateQuestionTemplate(questionTemplate);

            if (questionTemplate != null)

                if (result == true)
                {
                    Console.WriteLine("Шаблон добавлен успешно");

                    return true;
                }


                else
                {

                    Console.WriteLine("Шаблон не добавился!");


                }
            return false;

        }

        public bool DeleteTemplate(int Id)
        {
            Repository repository = new Repository();

            var result = repository.DeleteQuestionTemplate(Id);

            if (result == true)
            {
                Console.WriteLine("Шаблон удален");
                return true;
            }
            else
            {
                Console.WriteLine("Шаблон не найден");

            }
            return false;
        }

        public List<QuestionTemplate> GetTemplates()
        {
          

            Repository repository = new Repository();

            var result  = repository.GetQuestionTemplates();

            return result;
        }


      
       
    }
}
