using GQ.DAL;
using GQ.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

            if(questionTemplate!=null)
            {
                Console.WriteLine("Шаблон добавлен успешно");
            }
            else
            {
                Console.WriteLine("Шаблон не добавился!");
            }
            return result;
           
        }

        public List<QuestionTemplate> GetTemplates()
        {
            Repository repository = new Repository();

            var result  = repository.GetQuestionTemplates();
            
            return result;
        }


      
       
    }
}
