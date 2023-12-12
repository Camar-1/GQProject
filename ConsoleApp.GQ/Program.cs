using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GQ.BLL;
using GQ.DAL;


namespace ConsoleApp.GQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuestionService questionService = new QuestionService();

            
            List<string> Categories = new List<string> { "Легкие", "Средние", "Тяжелые" };

            while (true)
            {
                Console.WriteLine("Меню:");
                
                Console.WriteLine("1. Добавить шаблон вопроса");
                
                Console.WriteLine("2. Найти шаблон вопроса");
                
                Console.WriteLine("3. Удалить шаблон вопроса");
                
                Console.WriteLine("4. Получить список шаблонов вопросов");

                Console.WriteLine("5. Выход");

                string  Input = Console.ReadLine();

                if (int.TryParse(Input, out int Choice))
                {
                    switch (Choice)
                    {
                        case 1:
                            Console.WriteLine("Введите текст вопроса:");
                            
                            string QuestionText = Console.ReadLine();

                            Console.WriteLine("Введите категорию вопроса:");
                            
                            string CategoryInput = Console.ReadLine();

                            if (Categories.Contains(CategoryInput))
                            {
                                QuestionTemplate newTemplate = new QuestionTemplate
                                {
                                    CreateTime = DateTime.Now,
                                    QuestionText = QuestionText,
                                    Category = CategoryInput
                                };

                                questionService.AddTemplateQuestion(newTemplate);
                            }
                            else
                            {
                                Console.WriteLine("Некорректная категория вопроса.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Введите ID шаблона вопроса:");
                            if (int.TryParse(Console.ReadLine(), out int TemplateId))
                            {
                                questionService.FindTemplateQuestion(TemplateId);
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID шаблона вопроса.");
                            }
                            break;
                        
                        case 3:
                            Console.WriteLine("Введите ID удаления шаблона");
                            if (int.TryParse(Console.ReadLine(), out int DropTemplate))
                            {
                                questionService.DeleteTemplate(DropTemplate);
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID шаблона!");
                            }
                            break;

                        case 4:
                            var templates = questionService.GetTemplates();
                            foreach (var template in templates)
                            {
                                Console.WriteLine($"ID: {template.Id}, Вопрос: {template.QuestionText}, Категория: {template.Category}");
                            }
                            break;

                        


                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите число.");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
               
                Console.ReadKey();
                
                Console.Clear();
            }
        }
    }
}





        
   
    

