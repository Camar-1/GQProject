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
                    Console.WriteLine("Шаблон не добавился");
                    return false;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Нет доступа к хосту" + ex.Message);

                return false;

            }

        }

        public bool UpdateTemplate(QuestionTemplate questionTemplate)
        {
            try
            {
                Repository repository = new Repository();
                var result = repository.UpdateQuestionTemplate(questionTemplate);

                if (result)
                {
                    Console.WriteLine("Шаблон обновился!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Шаблоне не удалось обновить");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Нет доступа к хосту!" + ex.Message);
                return false;
            }
        }



        public bool DeleteTemplate(int Id)
        {
            try
            {
                Repository repository = new Repository();

                var result = repository.DeleteQuestionTemplate(Id);

                if (result == true)
                {
                    Console.WriteLine("Шаблон удален!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Шаблон не удалось удалить");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Нет доступа к хосту" + ex.Message);
                return false;

            }
        }

        public List<QuestionTemplate> GetByCategoryTemplates(QuestionTemplate templates, string category){

            try
            {
                Repository repository = new Repository();

                var result = repository.GetQuestionTemplates();

                   foreach (QuestionTemplate template in result)
                {
                  if(template.Category == category)
                    {
                        return result;
                    }

                    
                }

                 return null; 
            }
            catch(Exception ex)
            {
                Console.WriteLine("Пустой"+ex.Message);
                return null;
            }
        }
            






        public List<QuestionTemplate> GetTemplates()
        {
            try
            {

                Repository repository = new Repository();

                var result = repository.GetQuestionTemplates();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Нет доступа к хосту!" + ex.Message);
                return null;
            }
        }
    }
}
