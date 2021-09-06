using NUnit.Framework;
using RomanNumbersApp.APIs;
using RomanNumbersApp.Logic;

namespace NUnitTestProject
{
    public class Tests
    {
        private IRomanNumInterface _rmnNumbers = null;
        [SetUp]
        public void Setup()
        {
            _rmnNumbers = new  RomanNumber();
        }

        [Test]
        public void AddRomansSuccess()
        {
            RomansController _number = new RomansController(_rmnNumbers);
            RomansRequest romansRequest = new RomansRequest() { value1="LV",value2="V"};
            var result=_number.Add(romansRequest);
            Assert.IsNotNull(result);
            if (result.ToString()!="0")
            Assert.Pass();
        }
        [Test]
        public void AddRomansFail()
        {
            RomansController _number = new RomansController(_rmnNumbers);
            RomansRequest romansRequest = new RomansRequest() { value1 = "1X", value2 = "23" };
            var result = _number.Add(romansRequest);
            if (result.ToString() == "0")
                Assert.AreEqual(0, result);

        }
    }
}