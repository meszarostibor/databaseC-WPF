using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;


namespace databaseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listBox1.Items.Clear();
        }


        public void ReadDataBase(string query)
        {
            string connectionString = $"datasource={textBox1.Text};username={username.Text};password={password.Text};database=autok;";//datasource=localhost;port=3306

            //string query = ;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            WriteLog(query);
            listBox1.Items.Clear();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3).ToString() };
                        listBox1.Items.Add($"{row[0]} {row[1]} {row[2]} {row[3]} ");
                    }
                }
                else
                {
                    WriteLog("The table is empty!");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }
        }


        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = $"datasource={textBox1.Text};username={username.Text};password={password.Text};database=autok;";//datasource=localhost;port=3306
            string query = "CREATE DATABASE `autok`;CREATE TABLE `autok`.`auto` (`rendszam` VARCHAR(8) PRIMARY KEY NOT NULL, `marka` VARCHAR(8) NOT NULL, `szin` VARCHAR(8) NOT NULL, `vegsebesseg` INT NOT NULL ) ENGINE = InnoDB;INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('JSV743', 'Nissan', 'Fekete', '205');INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('RPL256', 'Suzuki', 'Ezüst', '175');INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('GSC247', 'Fiat', 'Zöld', '160');INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('LCK647', 'Opel', 'Fehér', '160');INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('DSK111', 'Jaguar', 'Piros', '240');INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('LSF333', 'Audi', 'Kék', '285');INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('MENO01', 'Ferrari', 'Piros', '310');INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('SRT660', 'Mercedes', 'Fehér', '330');INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES('BKD178', 'Fiat', 'Sárga', '130');";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            WriteLog(query);            
            listBox1.Items.Clear();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }

            ReadDataBase("SELECT * FROM `auto`");
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = $"datasource={textBox1.Text};username={username.Text};password={password.Text};database=autok;";//datasource=localhost;port=3306
            string query = "DROP DATABASE `autok`";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            WriteLog(query);
            listBox1.Items.Clear();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3).ToString() };
                        listBox1.Items.Add($"{row[0]} {row[1]} {row[2]} {row[3]} ");
                    }
                }
                else
                {
                    log.AppendText($"\n");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ReadDataBase("SELECT * FROM `auto`");
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (rendszam.Text != "" && marka.Text != "" && szin.Text != "" && vegsebesseg.Text != "")
            {
                string connectionString = $"datasource={textBox1.Text};username={username.Text};password={password.Text};database=autok;";//datasource=localhost;port=3306
                string query = $"INSERT INTO `autok`.`auto` (`rendszam`, `marka`, `szin`, `vegsebesseg`) VALUES ('{rendszam.Text}', '{marka.Text}', '{szin.Text}', '{vegsebesseg.Text}');";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                MySqlDataReader reader;
                WriteLog(query);               
                listBox1.Items.Clear();
                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    WriteLog(ex.Message);
                }

                ReadDataBase("SELECT * FROM `auto`");
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Clear();
            string connectionString = $"datasource={textBox1.Text};username={username.Text};password={password.Text};database=autok;";//datasource=localhost;port=3306

            string query = "SELECT DISTINCT szin FROM `auto`;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            WriteLog(query);
            listBox1.Items.Clear();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader.GetString(0));
                    }
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    log.DataContext = "The table is empty!\n";
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.Text != "")
            {
                ReadDataBase($"SELECT * FROM `auto` WHERE szin like '{comboBox1.Text}';");
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            comboBox2.Items.Clear();
            string connectionString = $"datasource={textBox1.Text};username={username.Text};password={password.Text};database=autok;";//datasource=localhost;port=3306

            string query = "SELECT DISTINCT marka FROM `auto`;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            WriteLog(query);           
            listBox1.Items.Clear();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader.GetString(0));
                    }
                    comboBox2.SelectedIndex = 0;
                }
                else
                {
                    WriteLog("The table is empty!");                    
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);                
            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox2.Text != "")
            {
                ReadDataBase($"SELECT * FROM `auto` WHERE marka like '{comboBox2.Text}';");
            }
        }





        public void WriteLog(string line) 
        {
            log.AppendText(line+"\n");
            log.ScrollToEnd();
        }

    }
}