using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestClassRoom
{
    [TestClass]
    public class UnitTestClassRoom
    {
        [DataTestMethod]
        [DataRow(null,1)]
        [DataRow(" ",1)]
        [DataRow("",1)]
        [DataRow("11",-1)]
        [DataRow("11",0)]
        public void TestConstructorIsException(string name, int number)
        {
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new ClassRoom.ClassRoom(name, number));
        }
        [DataTestMethod]
        [DataRow("@31313", 1)]
        [DataRow("11", 10000)]
        public void TestConstructorIsTrue(string name, int number)
        {
            //assert
            var classRoom = new ClassRoom.ClassRoom(name, number);
        }


        [DataTestMethod]
        [DataRow("Audit 1", 100 , "Аудитория Audit 1 вмещает 100.")]
        [DataRow("Audit 2", 300 , "Аудитория Audit 2 вмещает 300.")]
        [DataRow("Audit 4", 1 , "Аудитория Audit 4 вмещает 1.")]
        public void TestToString(string name, int number, string toString)
        {
            //arrange
            var classRoom = new ClassRoom.ClassRoom(name, number);
            //act
            var str =classRoom.ToString();
            //assert
            Assert.AreEqual(str, toString);


        }
    }
}
