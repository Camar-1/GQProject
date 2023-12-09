using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GQ.BLL;
using GQ.DAL;
using GQ.DAL.Model;

namespace ConsoleApp.GQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
          QuestionService questionService = new QuestionService();
          
          QuestionTemplate questionTemplate = new QuestionTemplate();

            Random rnd = new Random();
            questionTemplate.QuestionText = Console.ReadLine();
            Console.WriteLine(questionTemplate.QuestionText);
            

            
            

   
        }
    }
}
