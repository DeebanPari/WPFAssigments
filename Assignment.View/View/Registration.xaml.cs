using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Assignment.View.View
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        //temporary solution
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter Username";
                textBoxUsername.Focus();
            }
            else
            {
                {
                    string Username = textBoxUsername.Text;
                    string Lastname = textBoxLastname.Text;
                    string Email = textBoxEmail.Text;
                    string Password = textBlockPassword.Text;
                    string Conformpass = textBlockConformpass.Text;
                }
            }
            if (textBoxLastname.Text.Length == 0)
            {
                errormessage.Text = "Enter Lastname";
                textBoxLastname.Focus();
            }
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string Username = textBoxUsername.Text;
                string Lastname = textBoxLastname.Text;   
                string Email = textBoxEmail.Text;
                string Password = textBoxPassword.Password;
                string Conformpass = textBoxConformpass.Password;
                if (textBoxPassword.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    textBlockPassword.Focus();
                }
                else if (textBoxConformpass.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    textBlockConformpass.Focus();
                }
                //else if (textBlockPassword.Text != textBlockConformpass.Text)
                //{
                //    errormessage.Text = "Confirm password must be same as password.";
                //    textBlockConformpass.Focus();
                //}
                else
                {
                    errormessage.Text = "";
                    SqlConnection con = new SqlConnection("Data Source=DEEBANPARI\\SQLEXPRESS;Initial Catalog=Assignment;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Deeban_Users (Username,Lastname,Email,Password,Conformpass) values('" + Username +  "','" + Lastname + "','" + Email + "','" + Password + "','" + Conformpass + "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    errormessage.Text = "You have Registered successfully.";
                }
            }
            }

        private void textcomboBoxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textcomboBoxGender.Text = "Select your Gender";
        }


        //SubmitCommand
    }
}