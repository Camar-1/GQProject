using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GQ.DAL
{
    public class Repository
    {
        private string _Path = @"C:\Users\TEMP\GeneratorQuestions.db";

        public Repository(string path)
        {
            _Path = path;
        }
    }
}
