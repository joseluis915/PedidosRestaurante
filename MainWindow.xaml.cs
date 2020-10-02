using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PedidosRestaurante
{
    public partial class MainWindow : Window
    {
        private int cPostre = 3;

        private TimeSpan tiempo;
        private DispatcherTimer Temporizador;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EntregaButton_Click(object sender, RoutedEventArgs e)
        {
            //—————————————————————————————————————————————————————————[ Cubierto ]—————————————————————————————————————————————————————————
            if (Cubierto_CheckBox.IsChecked == true)
            {
                tiempo = new TimeSpan(0, 0, 15);
                Temporizador = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    TiempoCubiertosLabel.Content = tiempo.ToString("c");
                    if (tiempo == TimeSpan.Zero)
                    {
                        Temporizador.Stop();
                        MessageBox.Show("El utencilio esta libre.", "Termino", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    tiempo = tiempo.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);


            }


            //—————————————————————————————————————————————————————————[ Cuchara ]—————————————————————————————————————————————————————————
            if (Cuchara_CheckBox.IsChecked == true)
            {
                tiempo = new TimeSpan(0, 0, 20);
                Temporizador = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    TiempoCucharasLabel.Content = tiempo.ToString("c");
                    if (tiempo == TimeSpan.Zero)
                    {
                        Temporizador.Stop();
                        MessageBox.Show("El utencilio esta libre.", "Termino", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    tiempo = tiempo.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);
            }


            //—————————————————————————————————————————————————————————[ CucharaPostre ]—————————————————————————————————————————————————————————
            if (CucharaPostre_CheckBox.IsChecked == true)
            {
                ///—————————————————————————————————[ Temporizador ]—————————————————————————————————
                tiempo = new TimeSpan(0, 0, 20);
                Temporizador = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    TiempoCucharasPostreLabel.Content = tiempo.ToString("c");
                    if (tiempo == TimeSpan.Zero)
                    {
                        Temporizador.Stop();
                        MessageBox.Show("Hay una nueva (Cuchara Postre) libre.", "Termino", MessageBoxButton.OK, MessageBoxImage.Information);
                        cPostre++;
                        CucharasPostreLabel.Content = cPostre.ToString();
                    }
                    tiempo = tiempo.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);

                ///—————————————————————————————————[ Restar utencilio ]—————————————————————————————————
                if (cPostre <= 0)
                {
                    MessageBox.Show("Todos los utencilios estan ocupados.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    cPostre--;
                    CucharasPostreLabel.Content = cPostre.ToString();
                }
            }


            //—————————————————————————————————————————————————————————[ Cuchillo ]—————————————————————————————————————————————————————————
            if (Cuchillo_CheckBox.IsChecked == true)
            {
                tiempo = new TimeSpan(0, 0, 20);
                Temporizador = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    TiempoCuchillosLabel.Content = tiempo.ToString("c");
                    if (tiempo == TimeSpan.Zero)
                    {
                        Temporizador.Stop();
                        MessageBox.Show("El utencilio esta libre.", "Termino", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    tiempo = tiempo.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);
            }

        }

        //—————————————————————————————————————————————————————————[ CheckBox ]—————————————————————————————————————————————————————————
        private void DefaultCheckBox()
        {
            Cubierto_CheckBox.IsEnabled = true;
            Cuchara_CheckBox.IsEnabled = true;
            CucharaPostre_CheckBox.IsEnabled = true;
            Cuchillo_CheckBox.IsEnabled = true;
        }

        private void EntradaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (EntradaRadioButton.IsChecked == true)
            {
                DefaultCheckBox();
            }
        }

        private void PlatoFuerteRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (PlatoFuerteRadioButton.IsChecked == true)
            {
                DefaultCheckBox();
                CucharaPostre_CheckBox.IsEnabled = false;
            }
        }
        private void PostreRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (PostreRadioButton.IsChecked == true)
            {
                DefaultCheckBox();
                Cubierto_CheckBox.IsEnabled = false;
                Cuchara_CheckBox.IsEnabled = false;
                Cuchillo_CheckBox.IsEnabled = false;
            }
        }

    }
}
