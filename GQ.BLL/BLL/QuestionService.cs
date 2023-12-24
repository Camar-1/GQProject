using GQ.DAL;
using GQ.DAL.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        private Repository repository;
        private HashSet<string> categories;

        public QuestionService(Repository repository, HashSet<string> categories)
        {
            this.repository = repository;
            this.categories = categories;
        }

        public string AddTemplateQuestion(QuestionTemplate questionTemplate, out string error)
        {
            try
            {
                questionTemplate.Category = GetOrCreateCategory(questionTemplate.Category.Name);

                var result = repository.CreateQuestionTemplate(questionTemplate);

                if (result)
                {
                    error = "";
                    return "Шаблон успешно добавлен";
                }
                else
                {
                    error = "";
                    return "Шаблон не добавлен";
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка добавления " + ex.Message;
                return error;
            }
        }

        public string DeleteTemplate(int Id, out string error)
        {
            try
            {
                var result = repository.DeleteQuestionTemplate(Id);

                if (result)
                {
                    error = "";
                    return "Шаблон удален";
                }
                else
                {
                    error = "";
                    return "Шаблон к сожалению не удален";
                }
            }
            catch (Exception ex)
            {
                error = "Ошибка удаления " + ex.Message;
                return error;
            }
        }

        public List<QuestionTemplate> GetTemplates(out string error)
        {
            try
            {
                var result = repository.GetQuestionTemplates();

                error = "";
                return result;
            }
            catch (Exception ex)
            {
                error = "Ошибка при получении шаблонов: " + ex.Message;
                return null;
            }
        }



        public List<QuestionTemplate> GetTemplatesByCategory(string categoryName, out string error)
        {
            try
            {
                var category = GetOrCreateCategory(categoryName);
                var result = repository.GetQuestionTemplatesByCategory(category);

                error = "";
                return result;
            }
            catch (Exception ex)
            {
                error = "Ошибка при получении шаблонов по категории: " + ex.Message;
                return null;
            }
        }
        public bool CreateCategory(Category category)
        {
            try
            {
                return repository.CreateCategory(category);
            }
            catch (Exception)
            {
                return false;
            }
        } //
        public Category GetOrCreateCategory(string categoryName)
        {
            var existingCategory = repository.GetCategoryByName(categoryName);

            if (existingCategory != null)
            {
                return existingCategory;
            }
            else
            {
                var newCategory = new Category
                {
                    CreateTime = DateTime.Now,
                    Name = categoryName
                };

                repository.CreateCategory(newCategory);

                // Добавляем новую категорию в HashSet
                categories.Add(categoryName);

                return newCategory;
            }
        }
    }
}


