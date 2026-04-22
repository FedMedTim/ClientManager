using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClientManager;

namespace ClientManager.Tests
{
    [TestClass]
    public class ClientTests
    {
        // у ToString возвращает правильный формат 
        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var client = new Client("Ванек", "ivan@mail.ru", "89001234567", "Москва");
            // Act
            var result = client.ToString();
            // Assert
            StringAssert.Contains(result, "Ванек");
            StringAssert.Contains(result, "ivan@mail.ru");
            StringAssert.Contains(result, "89001234567");
        }

        // Свойства задаются правильно и без ошибок 
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            var client = new Client("Катя", "kat@mail.ru", "89009999999", "Питер");
            // Assert
            Assert.AreEqual("Катя", client.Name);
            Assert.AreEqual("kat@mail.ru", client.Email);
            Assert.AreEqual("89009999999", client.Phone);
            Assert.AreEqual("Питер", client.Address);
        }

        // Проврека на то, что свойства можно изменять 
        [TestMethod]
        public void Properties_CanBeChanged()
        {
            // Arrange
            var client = new Client("Старое", "old@mail.ru", "000", "Старый адрес");
            // Act
            client.Name = "Новое";
            client.Email = "new@mail.ru";
            client.Phone = "111";
            client.Address = "Новый адрес";
            // Assert
            Assert.AreEqual("Новое", client.Name);
            Assert.AreEqual("new@mail.ru", client.Email);
            Assert.AreEqual("111", client.Phone);
            Assert.AreEqual("Новый адрес", client.Address);
        }

        //  Проврека на то, что пустые строки тоже допускаются 
        [TestMethod]
        public void Constructor_WithEmptyStrings_DoesNotThrow()
        {
            // Arrange & Act
            var client = new Client("", "", "", "");

            // Assert
            Assert.AreEqual("", client.Name);
            Assert.AreEqual("", client.Email);
        }
    }
}