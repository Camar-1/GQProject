using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace GQ.DAL
{
    public class Repository
    {
        private string Path = @"C:\Temp\GQ.db";
        public bool CreateQuestionTemplate(QuestionTemplate questionTemplate)//add
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
                {
                    var res = db.GetCollection<QuestionTemplate>("QuestionTemplate");

                    res.Insert(questionTemplate);
                }

                return true ;

            }
            catch (Exception ex)

            {
                Console.WriteLine("Нет доступа к хосту"+ex);
                return false;

            }
        }
        
        public  bool UpdateQuestionTemplate(QuestionTemplate questionTemplate)//update
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
                {
                    var res = db.GetCollection<QuestionTemplate>("QuestionTemplate");

                    res.Update(questionTemplate);
                }
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Нет доступа к хосту"+ex);
                return false;
            }
        }

        public bool DeleteQuestionTemplate(int id)//drop
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
                {
                    var res = db.GetCollection<QuestionTemplate>();
                    res.Delete(id);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Нет доступа к хосту"+ex);
                return false;
            }
        }    

        public List<QuestionTemplate> GetQuestionTemplates() //get
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
                {
                    var res = db.GetCollection<QuestionTemplate>();

                    return res.FindAll().ToList();
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Нет доступа к хосту"+ ex);
                return null;
            }
        }

    }
}
           
          
