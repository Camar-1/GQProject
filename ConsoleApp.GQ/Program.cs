using System;
using System.Collections.Generic;
using GQ.BLL;
using GQ.DAL;
using GQ.DAL.Model;

namespace ConsoleApp.GQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\TEMP\GeneratorQuestion.db";

            HashSet<string> Categories = new HashSet<string> { };

            Repository repository = new Repository(path);
            QuestionService questionService = new QuestionService(repository, Categories);

            while (true)
            {
                Console.WriteLine("Меню:");

                Console.WriteLine("1. Добавить новую категорию");
                Console.WriteLine("2. Добавить шаблон вопроса");
                Console.WriteLine("3. Удалить шаблон вопроса");
                Console.WriteLine("4. Получить список шаблонов по категории");
                Console.WriteLine("5. Выход");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 2:
                            string Error;

                            Console.WriteLine("Введите текст вопроса:");
                            string questionText = Console.ReadLine();

                            Console.WriteLine("Введите категорию вопроса:");
                            string categoryInput = Console.ReadLine();

                            if (Categories.Contains(categoryInput))
                            {
                                Category newCategoryTemplate = new Category
                                {
                                    CreateTime = DateTime.Now,
                                    Name = categoryInput
                                };

                                QuestionTemplate newQTemplate = new QuestionTemplate
                                {
                                    CreateTime = DateTime.Now,
                                    QuestionText = questionText,
                                    Category = newCategoryTemplate
                                };

                                string resultMessage1 = questionService.AddTemplateQuestion(newQTemplate, out Error);
                                Console.WriteLine(resultMessage1);
                            }
                            else
                            {
                                Console.WriteLine("Некорректная категория вопроса.");
                            }
                            break;

                        case 3:
                            Console.WriteLine("Введите ID удаления шаблона");

                            if (int.TryParse(Console.ReadLine(), out int dropTemplate))
                            {
                                string resultMessage2 = questionService.DeleteTemplate(dropTemplate, out Error);
                                Console.WriteLine(resultMessage2);
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID шаблона!");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Выберите категорию для вывода:");
                            string selectedCategory1 = Console.ReadLine();

                            if (Categories.Contains(selectedCategory1))
                            {
                                List<QuestionTemplate> categoryTemplates = questionService.GetTemplatesByCategory(selectedCategory1, out Error);

                                if (categoryTemplates != null)
                                {
                                    foreach (QuestionTemplate template in categoryTemplates)
                                    {
                                        Console.WriteLine($"ID: {template.Id}, Вопрос: {template.QuestionText}, Категория: {template.Category.Name}");
                                    }
                                }

                                else
                                {
                                    Console.WriteLine($"Ошибка: {Error}");
                                }
                            }

                            else
                            {
                                Console.WriteLine("Выбрана новая категория. Введите название новой категории:");
                                string newTemplateCategoryName = Console.ReadLine();

                                if (!string.IsNullOrEmpty(newTemplateCategoryName))
                                {
                                    Category new22Category = questionService.GetOrCreateCategory(newTemplateCategoryName);

                                    if (new22Category != null)
                                    {
                                        Categories.Add(newTemplateCategoryName);

                                        List<QuestionTemplate> categoryTemplates = questionService.GetTemplatesByCategory(newTemplateCategoryName, out Error);

                                        if (categoryTemplates != null)
                                        {
                                            foreach (QuestionTemplate template in categoryTemplates)
                                            {
                                                Console.WriteLine($"ID: {template.Id}, Вопрос: {template.QuestionText}, Категория: {template.Category.Name}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Ошибка: {Error}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ошибка при создании новой категории.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректное название новой категории.");
                                }
                            }
                            break;
                        case 1:
                            Console.WriteLine("Введите название новой категории:");
                            string newCategoryName = Console.ReadLine();

                            // Добавление новой категории через GetOrCreateCategory
                            Category newCategory = questionService.GetOrCreateCategory(newCategoryName);

                            if (newCategory != null)
                            {
                                Console.WriteLine($"Категория '{newCategoryName}' успешно добавлена.");
                            }
                            else
                            {
                                Console.WriteLine($"Ошибка при добавлении категории '{newCategoryName}'.");
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
            }//
        }
    }
}


