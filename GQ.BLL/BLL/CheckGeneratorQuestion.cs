using GQ.DAL;
using GQ.DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GQ.BLL
{
    public class CheckGeneratorQuestion
    {
        private readonly Repository _repository;

        public CheckGeneratorQuestion()
        {
            _repository = new Repository();
        }   
        public bool AddQuestionTemplate(QuestionTemplate questionTemplate)
        {
            if (questionTemplate == null)
                
                throw new ArgumentNullException("Пустой");

            return _repository.CreateQuestionTemplate(questionTemplate);
        }

        public List<QuestionTemplate> GetAllQuestionTemplates()

            
        {
            return _repository.GetQuestionTemplates();  
        }
        
       
    }
    
}
