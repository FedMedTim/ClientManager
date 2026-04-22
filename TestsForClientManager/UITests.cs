using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Windows.Forms;
using ClientManager;

namespace ClientManager.Tests
{
    [TestClass]
    public class UITests
    {
        private Form1 _form;

        [TestInitialize]
        public void SetUp()
        {
            if (File.Exists("clients.txt"))
                File.Delete("clients.txt");

            _form = new Form1();
            _form.Show();
        }

        [TestCleanup]
        public void TearDown()
        {
            _form.Dispose();

            if (File.Exists("clients.txt"))
                File.Delete("clients.txt");
        }

        // Элементы формы видимы и доступны
        [TestMethod]
        public void NameTextBox_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.nameTextBox.Visible);
            Assert.IsTrue(_form.nameTextBox.Enabled);
        }

        [TestMethod]
        public void EmailTextBox_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.emailTextBox.Visible);
            Assert.IsTrue(_form.emailTextBox.Enabled);
        }

        [TestMethod]
        public void PhoneTextBox_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.phoneTextBox.Visible);
            Assert.IsTrue(_form.phoneTextBox.Enabled);
        }

        [TestMethod]
        public void AddressTextBox_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.addressTextBox.Visible);
            Assert.IsTrue(_form.addressTextBox.Enabled);
        }

        [TestMethod]
        public void AddClientButton_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.addClientButton.Visible);
            Assert.IsTrue(_form.addClientButton.Enabled);
        }

        [TestMethod]
        public void RemoveClientButton_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.removeClientButton.Visible);
            Assert.IsTrue(_form.removeClientButton.Enabled);
        }

        [TestMethod]
        public void EditClientButton_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.editClientButton.Visible);
            Assert.IsTrue(_form.editClientButton.Enabled);
        }

        [TestMethod]
        public void SearchTextBox_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.searchTextBox.Visible);
            Assert.IsTrue(_form.searchTextBox.Enabled);
        }

        [TestMethod]
        public void SearchButton_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.searchButton.Visible);
            Assert.IsTrue(_form.searchButton.Enabled);
        }

        [TestMethod]
        public void ClientsListBox_IsVisibleAndEnabled()
        {
            Assert.IsTrue(_form.clientsListBox.Visible);
            Assert.IsTrue(_form.clientsListBox.Enabled);
        }

        // Нажатие "Добавить" с заполненными полями добавляет клиента
        [TestMethod]
        public void AddButton_Click_WithValidData_AddsClientToList()
        {
            // Arrange
            _form.nameTextBox.Text = "Иван";
            _form.emailTextBox.Text = "ivan@mail.ru";
            _form.phoneTextBox.Text = "89001234567";
            _form.addressTextBox.Text = "Москва";
            // Act
            _form.addClientButton_Click(null, EventArgs.Empty);
            // Assert
            Assert.AreEqual(1, _form.clientManager.Clients.Count);
        }

        // Нажатие "Добавить" с пустыми полями не добавляет клиента
        [TestMethod]
        public void AddButton_Click_WithEmptyFields_DoesNotAddClient()
        {
            // Arrange
            _form.nameTextBox.Text = "";
            _form.emailTextBox.Text = "";
            _form.phoneTextBox.Text = "";
            _form.addressTextBox.Text = "";
            // Act
            _form.addClientButton_Click(null, EventArgs.Empty);
            // Assert
            Assert.AreEqual(0, _form.clientManager.Clients.Count);
        }

        // После добавления поля очищаются
        [TestMethod]
        public void AddButton_Click_WithValidData_ClearsInputFields()
        {
            // Arrange
            _form.nameTextBox.Text = "Иван";
            _form.emailTextBox.Text = "ivan@mail.ru";
            _form.phoneTextBox.Text = "89001234567";
            _form.addressTextBox.Text = "Москва";
            // Act
            _form.addClientButton_Click(null, EventArgs.Empty);
            // Assert
            Assert.AreEqual("", _form.nameTextBox.Text);
            Assert.AreEqual("", _form.emailTextBox.Text);
            Assert.AreEqual("", _form.phoneTextBox.Text);
            Assert.AreEqual("", _form.addressTextBox.Text);
        }

        // Удаление без выбора не ломает все
        [TestMethod]
        public void RemoveButton_Click_WithNoSelection_DoesNotThrow()
        {
            // Assert
            _form.removeClientButton_Click(null, EventArgs.Empty);
        }

        // Поиск заполняет ListBox корректно
        [TestMethod]
        public void SearchButton_Click_WithEmptyQuery_ShowsAllClients()
        {
            // Arrange
            _form.clientManager.AddClient(
                new Client("Иван", "ivan@mail.ru", "111", "Москва"));
            _form.clientManager.AddClient(
                new Client("Мария", "maria@mail.ru", "222", "Питер"));
            _form.searchTextBox.Text = "";
            // Act
            _form.searchButton_Click(null, EventArgs.Empty);
            // Assert
            Assert.AreEqual(2, _form.clientsListBox.Items.Count);
        }
    }
}