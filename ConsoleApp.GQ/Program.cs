﻿using System;
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


            if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
            {
                string text = Console.ReadLine();

                questionTemplate.category.Name = text;
            }


            else
            {

                Console.WriteLine("Необходимо вести данные");
                string text = Console.ReadLine();






                Console.WriteLine(questionTemplate.category.Name);




            

            }
        }
    }
}