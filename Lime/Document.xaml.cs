﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Telerik.Windows.Controls;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.ObjectModel;

namespace Lime
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class Document
    {
        //Globals
        public PriseEnCharge priseEnCharge = new PriseEnCharge();
        public Client client = new Client();
        public List<Documents_Lignes> Lignes;

        public IList<Documents_Lignes> Lignesx = new ObservableCollection<Documents_Lignes>();

        public Document(PriseEnCharge priseEnCharge)
        {
            InitializeComponent();
            Lignes = Connexion.maBDD.GetAll<Documents_Lignes>().ToList();
            var xx = Connexion.maBDD.GetAll<Documents_Lignes>();
            foreach (Documents_Lignes value in xx)
            {
                Lignesx.Add(value);
            }

            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder auy souséléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                priseEnCharge = priseEnCharge,
                client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients),
                Lignes = Connexion.maBDD.GetAll<Documents_Lignes>().ToList(),
                Lignesx
            };


            //TEST //
            //this.radGridViewx.ItemsSource = MessageViewModel.Generate();
            //RowReorderBehavior.SetIsEnabled(this.radGridViewx, true);
            this.radGridView.ItemsSource = Lignesx;
            RowReorderBehavior.SetIsEnabled(this.radGridView, true);
            //FIN /

        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            



            this.Close();
        }

        public class MessageViewModel
        {
            public static IList Generate()
            {
                IList data = new ObservableCollection<MessageViewModel>();
                data.Add(new MessageViewModel("tom@hanna-barbera.com", "Cats are cool", 100));
                data.Add(new MessageViewModel("jerry@hanna-barbera.com", "Mice are cool", 100));
                data.Add(new MessageViewModel("spike@hanna-barbera.com", "Dogs are cool", 100));
                data.Add(new MessageViewModel("jerry2@hanna-barbera.com", "2Mice are cool", 200));
                data.Add(new MessageViewModel("spike2@hanna-barbera.com", "2Dogs are cool", 200));
                data.Add(new MessageViewModel("jerry3@hanna-barbera.com", "3Mice are cool", 300));
                data.Add(new MessageViewModel("spike3@hanna-barbera.com", "3Dogs are cool", 300));
                data.Add(new MessageViewModel("spike3@hanna-barbera.com", "3Dogs are cool", 300));
                data.Add(new MessageViewModel("spike3@hanna-barbera.com", "3Dogs are cool", 300));
                return data;
            }
            public MessageViewModel(string sender, string subject, int size)
            {
                this.Sender = sender;
                this.Subject = subject;
                this.Size = size;
            }
            public string Subject
            {
                get;
                set;
            }
            public string Sender
            {
                get;
                set;
            }
            public int Size
            {
                get;
                set;
            }
            public override string ToString()
            {
                return this.Sender;
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Documents_Lignes item = new Documents_Lignes();
            this.Lignesx.Add(item);

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Duplicate_Click(object sender, RoutedEventArgs e)
        {
            Documents_Lignes item = new Documents_Lignes();
            var xx = ((Lime.Documents_Lignes)radGridView.SelectedItem);





            this.Lignesx.Add(item);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.Lignesx.Remove((Lime.Documents_Lignes)radGridView.SelectedItem);
        }
    }
}

