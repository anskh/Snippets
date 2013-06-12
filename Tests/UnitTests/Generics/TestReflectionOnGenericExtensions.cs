using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snippets.Generics.Extensions;
using Snippets.Common.DomainObjects.Entities;
using Snippets.Common.DomainObjects.Models;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace TestExtensions
{
    [TestClass]
    public class TestReflectionOnGenericsExtensions
    {
        [TestMethod]
        public void TestLinqQueryGenericExtension() {
            var personEntity = new PersonEntity() { Name = "Me", 
                                                    Age = 1, 
                                                    //Movies = new Collection<MovieEntity>() { new MovieEntity(){ Name = "Rambo", Id = 1 } },
                                                    Location = new Location(){ Address1 = "abc", Address2 = "def", City = "ghij", State = "kl", Zip = 12345 } 
            };

            PersonModel personModel = personEntity.ConvertUsingLinqQuery<PersonEntity, PersonModel>();

            Assert.IsTrue(personModel.Name == personEntity.Name
                && personEntity.Location.Address1 == personModel.Location.Address1);
        }

        [TestMethod]
        public void TestLambdaExpressionGenericExtension() {
            var personEntity = new PersonEntity() {
                Name = "Me",
                Age = 1,
                //Movies = new Collection<MovieEntity>() { new MovieEntity() { Name = "Rambo", Id = 1 } },
                Location = new Location() { Address1 = "abc", Address2 = "def", City = "ghij", State = "kl", Zip = 12345 } 
            };

            PersonModel personModel = personEntity.ConvertUsingLambdaNotation<PersonEntity, PersonModel>();
            Assert.IsTrue(personModel.Name == personEntity.Name 
                && personEntity.Location.Address1 == personModel.Location.Address1);
        }
    }
}
