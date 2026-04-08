using System;
using System.Windows.Forms;

namespace ClientManager
{
    public partial class Form1 : Form
    {
        private ClientManager clientManager;

        public Form1()
        {
            InitializeComponent();
            clientManager = new ClientManager();
            UpdateClientsList();
        }

        // Обновление ListBox
        private void UpdateClientsList()
        {
            clientsListBox.Items.Clear();
            foreach (var client in clientManager.Clients)
                clientsListBox.Items.Add(client.ToString());
        }

        // Добавить клиента
        private void addClientButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newClient = new Client(
                nameTextBox.Text.Trim(),
                emailTextBox.Text.Trim(),
                phoneTextBox.Text.Trim(),
                addressTextBox.Text.Trim());

            try
            {
                clientManager.AddClient(newClient);
                ClearInputFields();
                UpdateClientsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удалить клиента
        private void removeClientButton_Click(object sender, EventArgs e)
        {
            if (clientsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите клиента для удаления!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = clientsListBox.SelectedIndex;
            var clientToRemove = clientManager.Clients[index];

            try
            {
                clientManager.RemoveClient(clientToRemove);
                UpdateClientsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Редактировать клиента
        private void editClientButton_Click(object sender, EventArgs e)
        {
            if (clientsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите клиента для редактирования!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                MessageBox.Show("Заполните все поля для редактирования!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = clientsListBox.SelectedIndex;
            var oldClient = clientManager.Clients[index];
            var newClient = new Client(
                nameTextBox.Text.Trim(),
                emailTextBox.Text.Trim(),
                phoneTextBox.Text.Trim(),
                addressTextBox.Text.Trim());

            try
            {
                clientManager.UpdateClient(oldClient, newClient);
                ClearInputFields();
                UpdateClientsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Поиск
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                UpdateClientsList();
                return;
            }

            var results = clientManager.SearchClients(searchTextBox.Text.Trim());
            clientsListBox.Items.Clear();
            foreach (var client in results)
                clientsListBox.Items.Add(client.ToString());
        }

        // Выбор клиента из списка → заполнение полей
        private void clientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientsListBox.SelectedIndex == -1) return;

            var client = clientManager.Clients[clientsListBox.SelectedIndex];
            nameTextBox.Text = client.Name;
            emailTextBox.Text = client.Email;
            phoneTextBox.Text = client.Phone;
            addressTextBox.Text = client.Address;
        }

        // Очистка полей ввода
        private void ClearInputFields()
        {
            nameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            addressTextBox.Clear();
        }
    }
}