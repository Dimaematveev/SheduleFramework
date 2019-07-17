using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGender
{
    [TestClass]
    public class UnitTestGender
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow(" ")]
        [DataRow("")]
        [DataRow("\n")]
        [DataRow("\t")]
        public void TestConstructorIsException(string name)
        {
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new Gender.Gender(name));
        }
        [DataTestMethod]
        [DataRow("Man")]
        [DataRow("Мужчина")]
        [DataRow("Жен")]
        [DataRow("аывфыв")]
        [DataRow("'!21")]
        public void TestConstructorIsTrue(string name)
        {
            //assert
            var gender = new Gender.Gender(name);
        }
        [DataTestMethod]
        [DataRow("Man", "Man")]
        [DataRow("Мужчина", "Мужчина")]
        [DataRow("Жен", "Жен")]
        [DataRow("аывфыв", "аывфыв")]
        [DataRow("'!21", "'!21")]
        public void TestToString(string name, string toString)
        {
            //arrange
            var gender = new Gender.Gender(name);
            //act
            var str = gender.ToString();
            //assert
            Assert.AreEqual(str, toString);
        }
    }
}
