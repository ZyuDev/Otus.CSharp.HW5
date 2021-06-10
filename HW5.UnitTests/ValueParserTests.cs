using HW5.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.UnitTests
{

    [TestFixture]
    public class ValueParserTests
    {
        [Test]
        public void Parse_Int_ReturnInt()
        {
            var result = ValueParser.Parse("1", typeof(int));

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Parse_NotInt_ReturnInt()
        {
            var result = ValueParser.Parse("dsfa", typeof(int));

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Parse_True_ReturnTrue()
        {
            var result = ValueParser.Parse("true", typeof(bool));

            Assert.AreEqual(true, result);
        }

        [Test]
        public void Parse_False_ReturnFalse()
        {
            var result = ValueParser.Parse("false", typeof(bool));

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Parse_NotBool_ReturnFalse()
        {
            var result = ValueParser.Parse("fdf", typeof(bool));

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Parse_DecimalStr_ReturnDecimal()
        {
            var result = ValueParser.Parse("123.45", typeof(decimal));

            Assert.AreEqual(123.45, result);
        }

        [Test]
        public void Parse_DecimalStrWithComma_ReturnDecimal()
        {
            var result = ValueParser.Parse("123,45", typeof(decimal));

            Assert.AreEqual(123.45, result);
        }

        [Test]
        public void Parse_NotDecimalStr_ReturnDecimal()
        {
            var result = ValueParser.Parse("jjj", typeof(decimal));

            Assert.AreEqual(0M, result);
        }

        [Test]
        public void Parse_Null_ReturnDecimal()
        {
            var result = ValueParser.Parse(null, typeof(decimal));

            Assert.AreEqual(0M, result);
        }

        [Test]
        public void Parse_GuidStr_ReturnGuid()
        {
            var result = ValueParser.Parse("{0B3A4261-1F6C-4FAF-AA94-809EB6CFE447}", typeof(Guid));

            Assert.AreEqual(Guid.Parse("{0B3A4261-1F6C-4FAF-AA94-809EB6CFE447}"), result);
        }

        [Test]
        public void Parse_NotGuidStr_ReturnDecimal()
        {
            var result = ValueParser.Parse("jjj", typeof(Guid));

            Assert.AreEqual(Guid.Empty, result);
        }
    }
}
