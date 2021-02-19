﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjektSemestralnyCSharp
{
    //Representation of Clients table in Database
    public class Client
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public Client()
        {
            Orders = new ObservableCollection<Order>();
        }

    }
}
