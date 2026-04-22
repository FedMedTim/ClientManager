using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ClientManager;

namespace ClientManager.Tests
{
    [TestClass]
    public class BoundaryConditionTests
    {
        private ClientManager _manager;

        [TestInitialize]
        public void SetUp()
        {
            if (File.Exists("clients.txt"))
                File.Delete("clients.txt");
            _manager = new ClientManager();
        }

        [TestCleanup]
        public void TearDown()
        {
            if (File.Exists("clients.txt"))
                File.Delete("clients.txt");
        }

        // Список пуст при запуске
        [TestMethod]
        public void ClientManager_AfterInit_ListIsEmpty()
        {
            Assert.AreEqual(0, _manager.Clients.Count);
        }

        // Добавление и сразу удаление
        [TestMethod]
        public void AddThenRemove_ListIsEmpty()
        {
            // Arrange
            var client = new Client("Тест", "test@mail.ru", "000", "Адрес");
            // Act
            _manager.AddClient(client);
            _manager.RemoveClient(client);
            // Assert
            Assert.AreEqual(0, _manager.Clients.Count);
        }

        // обновление несуществующего клиента
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateClient_ClientNotInList_ThrowsInvalidOperationException()
        {
            // Arrange
            var ghost = new Client("Призрак", "g@mail.ru", "000", "Нигде");
            var newOne = new Client("Новый", "n@mail.ru", "111", "Адрес");
            // Act
            _manager.UpdateClient(ghost, newOne);
        }

        // Поиск в пустом списке - пустой результат
        [TestMethod]
        public void SearchClients_EmptyList_ReturnsEmptyList()
        {
            // Act
            var results = _manager.SearchClients("Кто-то");
            // Assert
            Assert.AreEqual(0, results.Count);
        }

        // С длинной строкой работает также корректно
        [TestMethod]
        public void SearchClients_VeryLongQuery_ReturnsEmptyList()
        {
            // Arrange
            _manager.AddClient(new Client("Ванек", "ivan@mail.ru", "111", "Москва"));
            var longQuery = new string('А', 10000);
            // Act
            var results = _manager.SearchClients(longQuery);
            // Assert
            Assert.AreEqual(0, results.Count);
        }

        // Поиск яерез пробел возвращает всех клиентов
        [TestMethod]
        public void SearchClients_WhitespaceQuery_ReturnsAllClients()
        {
            // Arrange
            _manager.AddClient(new Client("Ванек", "ivan@mail.ru", "111", "Москва"));
            _manager.AddClient(new Client("Катя", "kat@mail.ru", "222", "Питер"));
            // Act
            var results = _manager.SearchClients("   ");
            // Assert
            Assert.AreEqual(2, results.Count);
        }

        // Добавление сразу 100 клиентов
        [TestMethod]
        public void AddClient_100Times_AllAdded()
        {
            // Act
            for (int i = 0; i < 100; i++)
                _manager.AddClient(new Client($"Клиент{i}", $"c{i}@mail.ru", $"{i}", "Адрес"));
            // Assert
            Assert.AreEqual(100, _manager.Clients.Count);
        }
    }
}