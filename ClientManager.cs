using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClientManager
{
    public class ClientManager
    {
        public List<Client> Clients { get; private set; }
        private const string FilePath = "clients.txt";

        public ClientManager()
        {
            Clients = new List<Client>();
            LoadClients();
        }

        public void AddClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client), "Клиент не может быть null.");
            Clients.Add(client);
            SaveClients();
        }

        public void RemoveClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client), "Клиент не может быть null.");
            if (!Clients.Remove(client))
                throw new InvalidOperationException("Клиент не найден в списке.");
            SaveClients();
        }

        public void UpdateClient(Client oldClient, Client newClient)
        {
            if (oldClient == null) throw new ArgumentNullException(nameof(oldClient));
            if (newClient == null) throw new ArgumentNullException(nameof(newClient));

            int index = Clients.IndexOf(oldClient);
            if (index < 0)
                throw new InvalidOperationException("Клиент не найден в списке.");

            Clients[index] = newClient;
            SaveClients();
        }

        public List<Client> SearchClients(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<Client>(Clients);

            return Clients
                .Where(c =>
                    c.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    c.Email.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    c.Phone.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    c.Address.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        private void SaveClients()
        {
            File.WriteAllLines(FilePath,
                Clients.Select(c => $"{c.Name}|{c.Email}|{c.Phone}|{c.Address}"));
        }

        private void LoadClients()
        {
            if (!File.Exists(FilePath)) return;

            foreach (var line in File.ReadAllLines(FilePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                    Clients.Add(new Client(parts[0], parts[1], parts[2], parts[3]));
            }
        }
    }
}