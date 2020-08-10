using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArtikliNestoNesto
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Artikal> Artikli = new ObservableCollection<Artikal>();
		public MainWindow()
		{
			InitializeComponent();
			Artikli.Add(new Artikal("Plazam", 100, 25));
			Artikli.Add(new Artikal("Nesto", 50, 100));
			Artikli.Add(new Artikal("Nesto drugo", 200, 50));
			dg.ItemsSource = Artikli;

		}

		private void Promena(object sender, SelectionChangedEventArgs e)
		{
			DataContext = dg.SelectedItem;

			Artikal a = new Artikal("Nesto drugo", 200, 50);

		}
	}

	public class Artikal : INotifyPropertyChanged
	{
		private string _naziv;
		public string Naziv 
		{ 
			get => _naziv; 
			set
			{
				_naziv = value;
				Change("Naziv");
			}
		}

		private decimal _ucena;
		public decimal Ucena 
		{ 
			get => _ucena; 
			set
			{
				_ucena = value;
				string[] niz = { "Ucena", "IzlaznaCena" };
				Change(niz);
			}
		}

		private int _marza;
		public int Marza 
		{ 
			get => _marza; 
			set
			{
				_marza = value;
				string[] niz = { "Marza", "IzlaznaCena" };
				Change(niz);
			}
		}

		public decimal IzlaznaCena { get => Ucena * ((decimal)Marza / 100 + 1); }

		public Artikal(string n, decimal c, int m)
		{
			Naziv = n;
			Ucena = c;
			Marza = m;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void Change(string[] prop)
		{
			foreach(string p in prop)
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
		}

		public void Change(string prop)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
