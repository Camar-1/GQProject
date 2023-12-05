using System;
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
        private string _Path = @"C:\Users\TEMP\GeneratorQuestions.db";

        public Repository(string path)
        {
            _Path = path;
        }

        public bool AddQuestionTemplate(QuestionTemplate questionTemplate)//add
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(_Path))
                {
                    var res = db.GetCollection<QuestionTemplate>("QuestionTemplate");

                    res.Insert(questionTemplate);
                }

                return true;

            }
            catch (Exception)

            {
                return false;

            }
        }
        
        public  bool UpdateQuestionTemplate(QuestionTemplate questionTemplate)//update
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(_Path))
                {
                    var res = db.GetCollection<QuestionTemplate>("QuestionTemplate");

                    res.Update(questionTemplate);
                }
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteQuestionTemplate(int id)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(_Path))
                {
                    var res =  db.GetCollection<QuestionTemplate>();
                    res.Delete(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
      

        public List<QuestionTemplate> GetQuestionTemplates() //get
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(_Path))
                {
                    var res = db.GetCollection<QuestionTemplate>();

                    return res.FindAll().ToList();
                }
               
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
           
          
