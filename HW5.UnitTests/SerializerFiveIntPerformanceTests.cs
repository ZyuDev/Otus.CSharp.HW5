using HW5.Helpers;
using HW5.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HW5.UnitTests
{
 
    [TestFixture]
    public class SerializerFiveIntPerformanceTests
    {

        private List<FiveInt> _collection;

        [SetUp]
        public void SetUp()
        {
            _collection = new List<FiveInt>();
            var n = 100000;

            for (var i = 1; i <= n; i++)
            {
                var item = new FiveInt(1, 2, 3, 4, 5);
                _collection.Add(item);
            }
        }

        [Test]
        public void CsvSerializerPerformance()
        {

            var parser = new CsvSerializer<FiveInt>(true);

            var timer = new Stopwatch();
            timer.Start();

            var csv = parser.SerializeCollection(_collection);

            timer.Stop();
            var timeSpent = timer.ElapsedMilliseconds;

            Console.WriteLine($"Serialize time to CSV {_collection.Count} items: {timeSpent} ms");

            timer.Reset();
            timer.Start();

            var newCollection = parser.DeserializeCollection(csv);

            timer.Stop();
            timeSpent = timer.ElapsedMilliseconds;

            Console.WriteLine($"Time to Deserialize from CSV {_collection.Count} items: {timeSpent} ms");

        }

        [Test]
        public void JsonSerializerPerformance()
        {

            var timer = new Stopwatch();
            timer.Start();


            var json = JsonConvert.SerializeObject(_collection);

            timer.Stop();
            var timeSpent = timer.ElapsedMilliseconds;

            Console.WriteLine($"Serialize time to JSON {_collection.Count} items: {timeSpent} ms");

            timer.Reset();
            timer.Start();

            var restore = JsonConvert.DeserializeObject(json);

            timer.Stop();
            timeSpent = timer.ElapsedMilliseconds;


            Console.WriteLine($"Time to Deserialize from JSON {_collection.Count} items: {timeSpent} ms");


        }

    }
}
