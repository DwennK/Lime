using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lime.SplashScreen
{
    /// <summary>
    /// Logique d'interaction pour SplashScreenLoading.xaml
    /// </summary>
    public partial class SplashScreenLoading : Window
    {

        //Source : https://programmezendotnet.wordpress.com/2014/03/03/un-splashscreen-evolue-en-wpf/

        //Enfin, nous allons modifier le constructeur de notre splashscreen pour lui donner le chemin vers une image qui sera affichée en fond :
        public SplashScreenLoading()
        {
            InitializeComponent();

            Application.Current.Activated += OnAppActivated;
            Application.Current.Deactivated += OnAppDeactivated;
            Application.Current.MainWindow.Activated += OnMainWindowActivated;
        }


        #region //Lorsque l’application sera activée, on placera notre splashscreen au premier plan. Dans le cas inverse, on la replacera en arrière-plan.
        private void OnAppActivated(object sender, EventArgs e)
        {
            this.Topmost = true;
        }
        private void OnAppDeactivated(object sender, EventArgs e)
        {
            this.Topmost = false;
        }
        private void OnMainWindowActivated(object sender, EventArgs e)
        {
            this.Topmost = true;
        }
        #endregion


        #region //Maintenant, il faut passer le splashscreen au premier plan s’il est activé et le repasser en arrière-plan s’il est désactivé.
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.Topmost = true;
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            this.Topmost = false;
        }

        #endregion

        #region //Dernière étape, pour éviter les fuites mémoires et permettre au GC de libérer l’espace utilisé par le splashscreen, il va falloir le désabonner des 3 évènements auxquels on l’a abonné lors de sa création.
        //Pour cela, nous allons le faire en surchargeant la méthode OnClosed :
        protected override void OnClosed(EventArgs e)
        {
            Application.Current.Activated -= OnAppActivated;
            Application.Current.Deactivated -= OnAppDeactivated;
            Application.Current.MainWindow.Activated -= OnMainWindowActivated;

            base.OnClosed(e);
        }

        #endregion


        #region //Notre splashscreen a besoin d’afficher des messages et d’afficher la progression lors du chargement de l’application.
        //Nous allons donc ajouter autant de méthodes que nécessaire.

        //Ajoutez une méthode SetProgress qui va modifier la valeur de la barre de progression
        public void SetProgress(double value)
        {
            this.progress.IsIndeterminate = false;
            this.progress.Value = value;
        }

        //Puis une autre méthode SetProgress qui va modifier la valeur de la barre de progression mais également sa valeur maximale
        public void SetProgress(double value, double maximum)
        {
            this.progress.IsIndeterminate = false;
            this.progress.Value = value;
            this.progress.Maximum = maximum;
        }

        //Répétez ces 2 opérations afin d’ajouter des méthodes qui modifient en plus le message dans le splashscreen
        public void SetProgress(string message, double value)
        {
            this.label.Text = message;
            this.progress.IsIndeterminate = false;
            this.progress.Value = value;
        }

        public void SetProgress(string message, double value, double maximum)
        {
            this.label.Text = message;
            this.progress.IsIndeterminate = false;
            this.progress.Value = value;
            this.progress.Maximum = maximum;
        }


        #endregion














    }
}
