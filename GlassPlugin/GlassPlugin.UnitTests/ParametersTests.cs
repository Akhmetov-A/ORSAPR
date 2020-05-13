using System;
using GlassParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace GlassPlugin.UnitTests
{
    [TestClass]
    public class ParametersTests
    {
        private Parameters _parameters;
        [SetUp]
        public void InitParameters()
        {
            _parameters = new Parameters();
        }

        [TestCase(0, "Должно возникать исключение, если диаметр подставки меньше 100",
            TestName ="Присвоение диаметра подставки меньше 100")]
        [TestCase(200, "Должно возникать исключение, если диаметр подставки больше 180",
            TestName ="Присвоение диаметра подставки больше 180")]
        public void TestD1_SetArgumentException(int wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(() => { _parameters.StandDiameter = wrongValue; }, message);
        }

        [Test(Description ="Позитивный тест сеттера StandDiameter")]
        public void TestD1_SetCorrectValue()
        {
            var expected = 150;
            Assert.DoesNotThrow(() => { _parameters.StandDiameter = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description ="Позитивный тест геттера StandDiameter")]
        public void TestD1_GetCorrectValue()
        {
            var expected = 150;
            _parameters.StandDiameter = expected;
            var actual = _parameters.StandDiameter;
            Assert.AreEqual(expected, actual, "Геттер StandDiameter возвращает неправильное значение");
        }

        [TestCase(0, "Должно возникать исключение, если диаметр ножки меньше 10",
            TestName = "Присвоение диаметра ножки меньше 10")]
        [TestCase(25, "Должно возникать исключение, если диаметр ножки больше 20",
            TestName = "Присвоение диаметра ножки больше 20")]
        public void TestD2_SetArgumentException(int wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(() => { _parameters.LegDiameter = wrongValue; }, message);
        }

        [Test(Description = "Позитивный тест сеттера LegDiameter")]
        public void TestD2_SetCorrectValue()
        {
            var expected = 15;
            Assert.DoesNotThrow(() => { _parameters.LegDiameter = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера LegDiameter")]
        public void TestD2_GetCorrectValue()
        {
            var expected = 15;
            _parameters.LegDiameter = expected;
            var actual = _parameters.LegDiameter;
            Assert.AreEqual(expected, actual, "Геттер LegDiameter возвращает неправильное значение");
        }

        [TestCase(0, "Должно возникать исключение, если диаметр скругления меньше 10",
            TestName = "Присвоение диаметра скругления меньше 10")]
        [TestCase(40, "Должно возникать исключение, если диаметр скругления больше 30",
            TestName = "Присвоение диаметра скругления больше 30")]
        public void TestD3_SetArgumentException(int wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(() => { _parameters.RoundingDiameter = wrongValue; }, message);
        }

        [Test(Description = "Позитивный тест сеттера RoundingDiameter")]
        public void TestD3_SetCorrectValue()
        {
            var expected = 20;
            Assert.DoesNotThrow(() => { _parameters.RoundingDiameter = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера RoundingDiameter")]
        public void TestD3_GetCorrectValue()
        {
            var expected = 20;
            _parameters.RoundingDiameter = expected;
            var actual = _parameters.RoundingDiameter;
            Assert.AreEqual(expected, actual, "Геттер RoundingDiameter возвращает неправильное значение");
        }

        [TestCase(0, "Должно возникать исключение, если высота ножки меньше 100",
            TestName = "Присвоение высоты ножки меньше 100")]
        [TestCase(250, "Должно возникать исключение, если высота ножки больше 200",
            TestName = "Присвоение высоты ножки больше 200")]
        public void TestH1_SetArgumentException(int wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(() => { _parameters.LegHeight = wrongValue; }, message);
        }

        [Test(Description = "Позитивный тест сеттера LegHeight")]
        public void TestH1_SetCorrectValue()
        {
            var expected = 150;
            Assert.DoesNotThrow(() => { _parameters.LegHeight = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера LegHeight")]
        public void TestH1_GetCorrectValue()
        {
            var expected = 150;
            _parameters.LegHeight = expected;
            var actual = _parameters.LegHeight;
            Assert.AreEqual(expected, actual, "Геттер LegHeight возвращает неправильное значение");
        }

        [TestCase(0, "Должно возникать исключение, если диаметр бокала меньше 100",
            TestName = "Присвоение диаметра бокала меньше 100")]
        [TestCase(300, "Должно возникать исключение, если диаметр бокала больше 250",
            TestName = "Присвоение диаметра бокала больше 250")]
        public void TestD4_SetArgumentException(int wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(() => { _parameters.GlassDiameter = wrongValue; }, message);
        }

        [Test(Description = "Позитивный тест сеттера GlassDiameter")]
        public void TestD4_SetCorrectValue()
        {
            var expected = 200;
            Assert.DoesNotThrow(() => { _parameters.GlassDiameter = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера GlassDiameter")]
        public void TestD4_GetCorrectValue()
        {
            var expected = 200;
            _parameters.GlassDiameter = expected;
            var actual = _parameters.GlassDiameter;
            Assert.AreEqual(expected, actual, "Геттер GlassDiameter возвращает неправильное значение");
        }

        [TestCase(0, "Должно возникать исключение, если высота нижнего бокала меньше 100",
            TestName = "Присвоение высоты нижнего бокала меньше 100")]
        [TestCase(250, "Должно возникать исключение, если высота нижнего бокала больше 200",
            TestName = "Присвоение высоты нижнего бокала больше 200")]
        public void TestH2_SetArgumentException(int wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(() => { _parameters.LowerGlassHeight = wrongValue; }, message);
        }

        [Test(Description = "Позитивный тест сеттера LowerGlassHeight")]
        public void TestH2_SetCorrectValue()
        {
            var expected = 150;
            Assert.DoesNotThrow(() => { _parameters.LowerGlassHeight = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера LowerGlassHeight")]
        public void TestH2_GetCorrectValue()
        {
            var expected = 150;
            _parameters.LowerGlassHeight = expected;
            var actual = _parameters.LowerGlassHeight;
            Assert.AreEqual(expected, actual, "Геттер LowerGlassHeight возвращает неправильное значение");
        }

        [TestCase(0, "Должно возникать исключение, если диаметр горлышка меньше 100",
            TestName = "Присвоение диаметра горлышка меньше 100")]
        [TestCase(300, "Должно возникать исключение, если диаметр горлышка больше 180",
            TestName = "Присвоение диаметра горлышка больше 180")]
        public void TestD5_SetArgumentException(int wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(() => { _parameters.GlassNeckDiameter = wrongValue; }, message);
        }

        [Test(Description = "Позитивный тест сеттера GlassNeckDiameter")]
        public void TestD5_SetCorrectValue()
        {
            var expected = 150;
            Assert.DoesNotThrow(() => { _parameters.GlassNeckDiameter = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера GlassNeckDiameter")]
        public void TestD5_GetCorrectValue()
        {
            var expected = 150;
            _parameters.GlassNeckDiameter = expected;
            var actual = _parameters.GlassNeckDiameter;
            Assert.AreEqual(expected, actual, "Геттер GlassNeckDiameter возвращает неправильное значение");
        }

        [TestCase(0, "Должно возникать исключение, если высота верхнего бокала меньше 100",
            TestName = "Присвоение высоты верхнего бокала меньше 100")]
        [TestCase(250, "Должно возникать исключение, если высота верхнего бокала больше 200",
            TestName = "Присвоение высоты верхнего бокала больше 200")]
        public void TestH3_SetArgumentException(int wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(() => { _parameters.UpperGlassHeight = wrongValue; }, message);
        }

        [Test(Description = "Позитивный тест сеттера UpperGlassHeight")]
        public void TestH3_SetCorrectValue()
        {
            var expected = 150;
            Assert.DoesNotThrow(() => { _parameters.UpperGlassHeight = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера UpperGlassHeight")]
        public void TestH3_GetCorrectValue()
        {
            var expected = 150;
            _parameters.UpperGlassHeight = expected;
            var actual = _parameters.UpperGlassHeight;
            Assert.AreEqual(expected, actual, "Геттер UpperGlassHeight возвращает неправильное значение");
        }
    }
}
