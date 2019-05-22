using System;
using System.Linq;
using lab5.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    public class DbSetStudentsTest : TestDbSet<Student> 
    {
        public override Student Find(params object[] keyValues)
        {
            return this.SingleOrDefault(item => item.Id == (int)keyValues.Single());
        }
    }
}
