using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace Stationery_company2
{
    class Stationery : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string type;
        private int count;
        private string selers_menager;
        private int cost;
        private string name_buyers_company;
        private string menager_made_the_sale;
        private int number_sold;
        private decimal price;
        private string date;

        public int Id {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public string Selers_menager
        {
            get { return selers_menager; }
            set
            {
                selers_menager = value;
                OnPropertyChanged("Selers_menager");
            }
        }

        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public string Name_buyers_company
        {
            get { return name_buyers_company; }
            set
            {
                name_buyers_company = value;
                OnPropertyChanged("Name_buyer's_company");
            }
        }
        public string Menager_made_the_sale
        {
            get { return menager_made_the_sale; }
            set
            {
                menager_made_the_sale = value;
                OnPropertyChanged("Menager_made_the_sale's_company");
            }
        }

        public int Number_sold
        {
            get { return number_sold; }
            set
            {
                number_sold = value;
                OnPropertyChanged("Number_sold");
            }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public Stationery(int id, string name, string type, int count, string selerd_manager ,int cost, string name_boyer, string menager, int number_sold, decimal price, string date) 
        {
            Id = id;
            Name = name;
            Type = type;
            Count = count;
            Selers_menager = selerd_manager;
            Cost = cost;
            Name_buyers_company = name_boyer;
            Menager_made_the_sale = menager;
            Number_sold = number_sold;
            Price = price;
            Date = date;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Type: {Type}, Count: {Count}, Selers_menager: {Selers_menager}, Cost: {Cost}, Name_buyer's_company: {Name_buyers_company}, Menager_made_the_sale: {Menager_made_the_sale}, Number_sold: {Number_sold}, Price: {Price}, Date: {Date}";
        }
    }
}
