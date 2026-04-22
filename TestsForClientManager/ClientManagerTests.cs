using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ClientManager;

namespace ClientManager.Tests
{
    [TestClass]
    public class ClientManagerTests
    {
        private ClientManager _manager;

        [TestInitialize]
        public void SetUp()
        {
            // Удаляем файл перед каждым тестом, чтобы начинать полностью с начала
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

        // AddClient клиент добавляется в список 
        [TestMethod]
        public void AddClient_ValidClient_AddsToList()
        {
            // Arrange
            var client = new Client("Ванек", "ivan@mail.ru", "89001234567", "Москва");
            // Act
            _manager.AddClient(client);
            // Assert
            Assert.AreEqual(1, _manager.Clients.Count);
        }

        // AddClient несколько клиентов добавляются исправно  
        [TestMethod]
        public void AddClient_MultipleClients_AllAdded()
        {
            // Arrange
            var c1 = new Client("Ванек", "ivan@mail.ru", "111", "Москва");
            var c2 = new Client("Катя", "kat@mail.ru", "222", "Питер");
            var c3 = new Client("Петя", "petr@mail.ru", "333", "Казань");
            // Act
            _manager.AddClient(c1);
            _manager.AddClient(c2);
            _manager.AddClient(c3);
            // Assert
            Assert.AreEqual(3, _manager.Clients.Count);
        }

        // AddClient null выбрасывает ArgumentNullException
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddClient_NullClient_ThrowsArgumentNullException()
        {
            // Act
            _manager.AddClient(null);
        }

        // RemoveClient клиент удаляется из списка 
        [TestMethod]
        public void RemoveClient_ExistingClient_RemovesFromList()
        {
            // Arrange
            var client = new Client("Ванек", "ivan@mail.ru", "89001234567", "Москва");
            _manager.AddClient(client);
            // Act
            _manager.RemoveClient(client);
            // Assert
            Assert.AreEqual(0, _manager.Clients.Count);
        }

        // RemoveClient null выбрасывает ArgumentNullException 
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveClient_NullClient_ThrowsArgumentNullException()
        {
            // Act
            _manager.RemoveClient(null);
        }

        // RemoveClient несуществующий клиент и выборс InvalidOperationException
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveClient_NotExistingClient_ThrowsInvalidOperationException()
        {
            // Arrange
            var client = new Client("НоуНейм", "ghost@mail.ru", "000", "Нигде");
            // Act
            _manager.RemoveClient(client);
        }

        // UpdateClient данные клиента обновляются 
        [TestMethod]
        public void UpdateClient_ValidData_UpdatesCorrectly()
        {
            // Arrange
            var oldClient = new Client("Старый", "old@mail.ru", "000", "Старый адрес");
            _manager.AddClient(oldClient);
            var newClient = new Client("Новый", "new@mail.ru", "111", "Новый адрес");
            // Act
            _manager.UpdateClient(oldClient, newClient);
            // Assert
            Assert.AreEqual("Новый", _manager.Clients[0].Name);
            Assert.AreEqual("new@mail.ru", _manager.Clients[0].Email);
        }

        // UpdateClient oldClient == null — ArgumentNullException 
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateClient_NullOldClient_ThrowsArgumentNullException()
        {
            // Arrange
            var newClient = new Client("Новый", "new@mail.ru", "111", "Адрес");
            // Act
            _manager.UpdateClient(null, newClient);
        }

        // UpdateClient newClient == null — ArgumentNullException
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateClient_NullNewClient_ThrowsArgumentNullException()
        {
            // Arrange
            var oldClient = new Client("Старый", "old@mail.ru", "000", "Адрес");
            _manager.AddClient(oldClient);
            // Act
            _manager.UpdateClient(oldClient, null);
        }

        // SearchClients поиск по имени находит клиента 
        [TestMethod]
        public void SearchClients_ByName_ReturnsMatchingClient()
        {
            // Arrange
            _manager.AddClient(new Client("Ванек", "ivan@mail.ru", "111", "Москва"));
            _manager.AddClient(new Client("Катя", "kat@mail.ru", "222", "Питер"));
            // Act
            var results = _manager.SearchClients("Ванек");
            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Ванек", results[0].Name);
        }

        // SearchClients поиск по email находит клиента
        [TestMethod]
        public void SearchClients_ByEmail_ReturnsMatchingClient()
        {
            // Arrange
            _manager.AddClient(new Client("Ванек", "ivan@mail.ru", "111", "Москва"));
            _manager.AddClient(new Client("Катя", "kat@mail.ru", "222", "Питер"));
            // Act
            var results = _manager.SearchClients("kat@mail.ru");
            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Катя", results[0].Name);
        }

        // SearchClients поиск по телефону находит клиента 
        [TestMethod]
        public void SearchClients_ByPhone_ReturnsMatchingClient()
        {
            // Arrange
            _manager.AddClient(new Client("Петя", "petr@mail.ru", "89005551234", "Казань"));
            // Act
            var results = _manager.SearchClients("89005551234");
            // Assert
            Assert.AreEqual(1, results.Count);
        }

        // SearchClients поиск по адресу находит клиента 
        [TestMethod]
        public void SearchClients_ByAddress_ReturnsMatchingClient()
        {
            // Arrange
            _manager.AddClient(new Client("Анна", "anna@mail.ru", "333", "Новосибирск"));
            // Act
            var results = _manager.SearchClients("Новосибирск");
            // Assert
            Assert.AreEqual(1, results.Count);
        }

        // SearchClients поиск без учёта регистра
        [TestMethod]
        public void SearchClients_CaseInsensitive_ReturnsResult()
        {
            // Arrange
            _manager.AddClient(new Client("Ванек", "ivan@mail.ru", "111", "Москва"));
            // Act
            var results = _manager.SearchClients("Ванек");
            // Assert
            Assert.AreEqual(1, results.Count);
        }

        // SearchClients пустой запрос возвращает всех клиентов
        [TestMethod]
        public void SearchClients_EmptyQuery_ReturnsAllClients()
        {
            // Arrange
            _manager.AddClient(new Client("Ванек", "ivan@mail.ru", "111", "Москва"));
            _manager.AddClient(new Client("Катя", "kat@mail.ru", "222", "Питер"));
            // Act
            var results = _manager.SearchClients("");
            // Assert
            Assert.AreEqual(2, results.Count);
        }

        // SearchClients несуществующий запрос возвращает пустой список
        [TestMethod]
        public void SearchClients_NoMatch_ReturnsEmptyList()
        {
            // Arrange
            _manager.AddClient(new Client("Ванек", "ivan@mail.ru", "111", "Москва"));
            // Act
            var results = _manager.SearchClients("ХХХнесуществует");
            //Assert
            Assert.AreEqual(0, results.Count);
        }

        // Сохранение и загрузка из файла работают правильно 
        [TestMethod]
        public void SaveAndLoad_ClientsPersistedToFile()
        {
            // Arrange
            _manager.AddClient(new Client("Ванек", "ivan@mail.ru", "111", "Москва"));
            // Act — создаём новый менеджер, он должен загрузить из файла
            var newManager = new ClientManager();
            // Assert
            Assert.AreEqual(1, newManager.Clients.Count);
            Assert.AreEqual("Ванек", newManager.Clients[0].Name);
        }
    }
}