using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;
namespace MaschinenDiagramm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbMaschinen.DisplayMemberPath = "Value";
            Load();

        }

        private void btnLaden_Click(object sender, RoutedEventArgs e)
        {
            

            
            if (cmbMaschinen.SelectedItem == null || cmbJahre.SelectedItem == null)
            {
                MessageBox.Show("Bitte Maschine und Jahr auswählen.");
                return;
            }

            
            int jahr = int.Parse(cmbJahre.SelectedItem.ToString());

            var ausgewaehlteMaschine = (KeyValuePair<int, string>)cmbMaschinen.SelectedItem;
            int maschinenID = ausgewaehlteMaschine.Key;

            string connectionString = "Server=localhost;Database=produktiondb;Uid=root;Pwd=meinpasswort123;";

            string sql = "SELECT * FROM produktionsjahr WHERE MaschinenID = @maschine AND Jahr = @jahr";

            int[] daten = new int[12];
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    
                    cmd.Parameters.AddWithValue("@maschine", maschinenID);
                    cmd.Parameters.AddWithValue("@jahr", jahr);

                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            daten[0] = reader.GetInt32("Januar");
                            daten[1] = reader.GetInt32("Februar");
                            daten[2] = reader.GetInt32("März");
                            daten[3] = reader.GetInt32("April");
                            daten[4] = reader.GetInt32("Mai");
                            daten[5] = reader.GetInt32("Juni");
                            daten[6] = reader.GetInt32("Juli");
                            daten[7] = reader.GetInt32("August");
                            daten[8] = reader.GetInt32("September");
                            daten[9] = reader.GetInt32("Oktober");
                            daten[10] = reader.GetInt32("November");
                            daten[11] = reader.GetInt32("Dezember");
                        }
                        else
                        {
                            MessageBox.Show("Keine Daten gefunden!");
                        }


                    }
                    
                }
            }

            ZeichneDiagramm(daten);

        }
        private void ZeichneDiagramm(int[] daten, bool farbe = false)
        {
            chartCanvas.Children.Clear();

            double canvasHeight = chartCanvas.ActualHeight;
            double canvasWidth = chartCanvas.ActualWidth;

            int anzahl = daten.Length;
            double maxWert = daten.Max();

            double abstand = 10;
            double saeulenBreite = (canvasWidth - abstand * anzahl) / anzahl;

            for (int i = 0; i < anzahl; i++)
            {
                double wert = daten[i];
                double hoehe = (wert / maxWert) * (canvasHeight - 20);

                Rectangle rect = new Rectangle
                {
                    Width = saeulenBreite,
                    Height = hoehe,
                    Fill = Brushes.SteelBlue
                };

                if (farbe == true) 
                {
                    Rectangle rect1 = new Rectangle
                    {
                        Width = saeulenBreite,
                        Height = hoehe,
                        Fill = Brushes.Red
                    };

                    if (daten[i] == maxWert)
                    {
                        double x1 = i * (saeulenBreite + abstand) + 5;
                        double y1 = canvasHeight - hoehe;

                        Canvas.SetLeft(rect1, x1);
                        Canvas.SetTop(rect1, y1);
                        chartCanvas.Children.Add(rect1);

                        string[] monate = { "Jan", "Feb", "Mrz", "Apr", "Mai", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dez" };
                        TextBlock txt1 = new TextBlock
                        {
                            Text = wert.ToString(),
                            FontWeight = FontWeights.Bold
                        };

                        txt1.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                        double textWidth1 = txt1.DesiredSize.Width;

                        Canvas.SetLeft(txt1, x1 + (saeulenBreite / 2) - (textWidth1 / 2));
                        Canvas.SetTop(txt1, y1 - 20);

                        chartCanvas.Children.Add(txt1);
                        txtErgebnis.Text = string.Format("Der Monat {0} war mit \n{1} am effektivsten", monate[i], maxWert);

                        continue;
                    }

                }
                double x =  i * (saeulenBreite + abstand) + 5;
                double y = canvasHeight - hoehe;

                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                chartCanvas.Children.Add(rect);

                TextBlock txt = new TextBlock
                {
                    Text = wert.ToString(),
                    FontWeight = FontWeights.Bold
                };

                txt.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                double textWidth = txt.DesiredSize.Width;

                Canvas.SetLeft(txt, x + (saeulenBreite / 2) - (textWidth / 2));
                Canvas.SetTop(txt, y - 20);

                chartCanvas.Children.Add(txt);
            }
        }
        private void btnBestesJahr_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMaschinen.SelectedItem == null || cmbJahre.SelectedItem == null)
            {
                MessageBox.Show("Bitte Maschine und Jahr auswählen.");
                return;
            }


            int jahr = int.Parse(cmbJahre.SelectedItem.ToString());

            var ausgewaehlteMaschine = (KeyValuePair<int, string>)cmbMaschinen.SelectedItem;
            int maschinenID = ausgewaehlteMaschine.Key;

            string connectionString = "Server=localhost;Database=produktiondb;Uid=root;Pwd=meinpasswort123;";

            string sql = "SELECT * FROM produktionsjahr WHERE MaschinenID = @maschine AND Jahr = @jahr";

            int[] daten = new int[12];
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();


                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@maschine", maschinenID);
                    cmd.Parameters.AddWithValue("@jahr", jahr);


                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            daten[0] = reader.GetInt32("Januar");
                            daten[1] = reader.GetInt32("Februar");
                            daten[2] = reader.GetInt32("März");
                            daten[3] = reader.GetInt32("April");
                            daten[4] = reader.GetInt32("Mai");
                            daten[5] = reader.GetInt32("Juni");
                            daten[6] = reader.GetInt32("Juli");
                            daten[7] = reader.GetInt32("August");
                            daten[8] = reader.GetInt32("September");
                            daten[9] = reader.GetInt32("Oktober");
                            daten[10] = reader.GetInt32("November");
                            daten[11] = reader.GetInt32("Dezember");
                        }
                        else
                        {
                            MessageBox.Show("Keine Daten gefunden!");
                        }


                    }

                }
            }

            ZeichneDiagramm(daten,true);
           
            
        }

        private void Load()
        {
            cmbMaschinen.Items.Clear();
            string connectionString = "Server=localhost;Database=produktiondb;Uid=root;Pwd=meinpasswort123;";

            string sql = "SELECT * FROM maschinen;";
            string sql1 = "SELECT DiSTINCT Jahr FROM produktionsjahr;";
            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();


                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            cmbMaschinen.Items.Add(new KeyValuePair<int, string>(id, name));
                            
                        }
                 }
               
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                {
                    while (reader1.Read())
                    {
                        int Jahr = reader1.GetInt32(0);
                        cmbJahre.Items.Add(Jahr);

                    }
                }

            }
        }

       
    }
}
