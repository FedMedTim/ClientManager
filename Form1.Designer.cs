namespace ClientManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Button addClientButton;
        private System.Windows.Forms.Button removeClientButton;
        private System.Windows.Forms.Button editClientButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox clientsListBox;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.addClientButton = new System.Windows.Forms.Button();
            this.removeClientButton = new System.Windows.Forms.Button();
            this.editClientButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.clientsListBox = new System.Windows.Forms.ListBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // labelName
            this.labelName.Text = "Имя:";
            this.labelName.Location = new System.Drawing.Point(12, 15);
            this.labelName.AutoSize = true;

            // nameTextBox
            this.nameTextBox.Location = new System.Drawing.Point(12, 33);
            this.nameTextBox.Width = 140;

            // labelEmail
            this.labelEmail.Text = "Email:";
            this.labelEmail.Location = new System.Drawing.Point(162, 15);
            this.labelEmail.AutoSize = true;

            // emailTextBox
            this.emailTextBox.Location = new System.Drawing.Point(162, 33);
            this.emailTextBox.Width = 160;

            // labelPhone
            this.labelPhone.Text = "Телефон:";
            this.labelPhone.Location = new System.Drawing.Point(332, 15);
            this.labelPhone.AutoSize = true;

            // phoneTextBox
            this.phoneTextBox.Location = new System.Drawing.Point(332, 33);
            this.phoneTextBox.Width = 130;

            // labelAddress
            this.labelAddress.Text = "Адрес:";
            this.labelAddress.Location = new System.Drawing.Point(12, 65);
            this.labelAddress.AutoSize = true;

            // addressTextBox
            this.addressTextBox.Location = new System.Drawing.Point(12, 83);
            this.addressTextBox.Width = 450;
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Height = 40;

            // addClientButton
            this.addClientButton.Text = "Добавить";
            this.addClientButton.Location = new System.Drawing.Point(12, 135);
            this.addClientButton.Width = 100;
            this.addClientButton.Click +=
                new System.EventHandler(this.addClientButton_Click);

            // editClientButton
            this.editClientButton.Text = "Изменить";
            this.editClientButton.Location = new System.Drawing.Point(122, 135);
            this.editClientButton.Width = 100;
            this.editClientButton.Click +=
                new System.EventHandler(this.editClientButton_Click);

            // removeClientButton
            this.removeClientButton.Text = "Удалить";
            this.removeClientButton.Location = new System.Drawing.Point(232, 135);
            this.removeClientButton.Width = 100;
            this.removeClientButton.Click +=
                new System.EventHandler(this.removeClientButton_Click);

            // labelSearch
            this.labelSearch.Text = "Поиск:";
            this.labelSearch.Location = new System.Drawing.Point(12, 175);
            this.labelSearch.AutoSize = true;

            // searchTextBox
            this.searchTextBox.Location = new System.Drawing.Point(12, 193);
            this.searchTextBox.Width = 300;

            // searchButton
            this.searchButton.Text = "Найти";
            this.searchButton.Location = new System.Drawing.Point(322, 191);
            this.searchButton.Width = 80;
            this.searchButton.Click +=
                new System.EventHandler(this.searchButton_Click);

            // clientsListBox
            this.clientsListBox.Location =
                new System.Drawing.Point(12, 230);
            this.clientsListBox.Width = 450;
            this.clientsListBox.Height = 180;
            this.clientsListBox.SelectedIndexChanged +=
                new System.EventHandler(this.clientsListBox_SelectedIndexChanged);

            // Form1
            this.Text = "Управление клиентами";
            this.ClientSize = new System.Drawing.Size(480, 430);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.labelName,    this.nameTextBox,
                this.labelEmail,   this.emailTextBox,
                this.labelPhone,   this.phoneTextBox,
                this.labelAddress, this.addressTextBox,
                this.addClientButton,
                this.editClientButton,
                this.removeClientButton,
                this.labelSearch,  this.searchTextBox,
                this.searchButton,
                this.clientsListBox
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}