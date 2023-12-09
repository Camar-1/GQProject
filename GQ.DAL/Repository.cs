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
        public bool CreateQuestionTemplate(QuestionTemplate questionTemplate)//add
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(@"C:\Users\TEMP\GeneratorQuestions.db"))
                {
                    var res = db.GetCollection<QuestionTemplate>("QuestionTemplate");

                    res.Insert(questionTemplate);
                }

                return true ;

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
                using (LiteDatabase db = new LiteDatabase(@"C:\Users\TEMP\GeneratorQuestions.db"))
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

        public bool DeleteQuestionTemplate(int id)//drop
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(@"C:\Users\TEMP\GeneratorQuestions.db"))
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
        public bool  FindQuestionTemplate(int id)
        {
            try
            {
                using(LiteDatabase db = new LiteDatabase(@"C:\Users\TEMP\GeneratorQuestions.db"))
                {
                    var res = db.GetCollection<QuestionTemplate>();
                    res.FindById(id); 
                   
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
                using (LiteDatabase db = new LiteDatabase(@"C:\Users\TEMP\GeneratorQuestions.db"))
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
           
          
