using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GQ.DAL.Model;
using LiteDB;
namespace GQ.DAL
{
    public class Repository
    {
        private string Path;

        public Repository(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// добавление шаблона в  базу данных
        /// </summary>
        /// <param name="questionTemplate"></param>
        /// <returns></returns>
        public bool CreateQuestionTemplate(QuestionTemplate questionTemplate)//add
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
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
        /// <summary>
        /// Удаление шаблона по ID
        /// </summary>
        /// <param name="questionTemplate"></param>
        /// <returns></returns>

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
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// Создание категории шаблона
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool CreateCategory(Category category)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
                {
                    var res = db.GetCollection<Category>("Category");
                    res.Insert(category);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Получение/добавление нового шаблона если не существует текущий введеный
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<QuestionTemplate> GetQuestionTemplatesByCategory(Category category)
        {

            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
                {
                    var res = db.GetCollection<QuestionTemplate>();
                    return res.Find(x => x.Category.Id == category.Id).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Получение по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Category GetCategoryByName(string name)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
                {
                    var res = db.GetCollection<Category>();
                    return res.FindOne(c => c.Name == name);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}



//