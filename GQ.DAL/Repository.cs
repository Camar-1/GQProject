﻿using System;
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

        public bool UpdateQuestionTemplate(QuestionTemplate questionTemplate)//update
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

            catch (Exception)
            {

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
            catch (Exception)
            {

                return false;
            }
        }
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
            catch (Exception)
            {

                return null;
            }
        }
    }
}



//