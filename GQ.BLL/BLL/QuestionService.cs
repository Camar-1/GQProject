using GQ.DAL;
using System;
using System.CodeDom;
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
            try
            {
                Repository repository = new Repository();

                var result = repository.CreateQuestionTemplate(questionTemplate);

                if (result)
                {
                    Console.WriteLine("Шаблон  добавился");
                    return true;
                }
                else
                {
                    Console.WriteLine("Шаблон не добавился, попробуйте еще раз");
                    return false;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Нет доступа к хосту" + ex);
                
                return false ;

            }
            
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
