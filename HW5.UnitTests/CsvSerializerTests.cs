using HW5.Helpers;
using HW5.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW5.UnitTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void SerializeObject_Null_ReturnEmptyString()
        {
            var serializer = new CsvSerializer<FiveInt>(true);

            var csvString = serializer.SerializeObject(null);

            Assert.AreEqual("", csvString);
        }

        [Test]
        public void DeserializeObject_Null_ReturnNull()
        {
            var serializer = new CsvSerializer<FiveInt>(true);

            var result = serializer.DeserializeObject(null);

            Assert.IsNull(result);
        }


        [Test]
        public void SerializeCollection_Null_ReturnEmptyString()
        {
            var serializer = new CsvSerializer<FiveInt>(true);

            var csvString = serializer.SerializeCollection(null);

            Assert.AreEqual("", csvString);
        }

        [Test]
        public void DeserializeCollection_Null_ReturnEmptyCollection()
        {
            var serializer = new CsvSerializer<FiveInt>(true);

            var collection = serializer.DeserializeCollection(null);

            Assert.IsNotNull(collection);
            Assert.AreEqual(0, collection.Count);
        }


        [Test]
        public void SerializeObject_FiveInts()
        {

            var entity = new FiveInt(1, 2, 3, 4, 5);
            var serializer = new CsvSerializer<FiveInt>(true);

            var csvString = serializer.SerializeObject(entity);

            Console.WriteLine("Result:");
            Console.WriteLine(csvString);

            var newObj = serializer.DeserializeObject(csvString);

            Assert.AreEqual(entity, newObj);
        }

        [Test]
        public void SerializeCollection_FiveInts()
        {

            var collection = new List<FiveInt>();
            collection.Add(new FiveInt(1, 2, 3, 4, 5));
            collection.Add(new FiveInt(6, 7, 8, 9, 10));

            var serializer = new CsvSerializer<FiveInt>(true);

            var csvString = serializer.SerializeCollection(collection);

            Console.WriteLine("Result:");
            Console.WriteLine(csvString);

            var newCollection = serializer.DeserializeCollection(csvString);

            Assert.AreEqual(2, newCollection.Count());
            Assert.AreEqual(collection[0], newCollection[0]);
            Assert.AreEqual(collection[1], newCollection[1]);

        }

        [Test]
        public void SerializeObject_Product()
        {

            var entity = ProductGenerator.Product1();
            var serializer = new CsvSerializer<Product>(false);

            var csvString = serializer.SerializeObject(entity);

            Console.WriteLine("Result:");
            Console.WriteLine(csvString);

            var newObj = serializer.DeserializeObject(csvString);

            Assert.AreEqual(entity, newObj);
        }

        [Test]
        public void SerializeCollection_Product()
        {

            var collection = new List<Product>();
            collection.Add(ProductGenerator.Product1());
            collection.Add(ProductGenerator.Product2());

            var serializer = new CsvSerializer<Product>(false);

            var csvString = serializer.SerializeCollection(collection);

            Console.WriteLine("Result:");
            Console.WriteLine(csvString);

            var newCollection = serializer.DeserializeCollection(csvString);

            Assert.AreEqual(2, newCollection.Count());
            Assert.AreEqual(collection[0], newCollection[0]);
            Assert.AreEqual(collection[1], newCollection[1]);

        }
    }
}