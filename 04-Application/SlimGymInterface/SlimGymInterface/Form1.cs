using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SlimGymInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'slimGymDataSet.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.slimGymDataSet.Member);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-6RP57LTV;Initial Catalog=SlimGym;Integrated Security=True")) //connection String
            {
                conn.Open();

                int memberID = int.Parse(textBox1.Text);
                String fName = textBox2.Text;
                String lName = textBox3.Text;
                String email = textBox4.Text;
                String PhoneNumber = textBox5.Text;
                string nationality = string.IsNullOrWhiteSpace(textBox6.Text) ? "Jordanian" : textBox6.Text;
                string msType = comboBox1.Text.ToLower(); // in case entered with capital M or Y
                decimal weight = decimal.Parse(textBox7.Text);
                int height = int.Parse(textBox8.Text);
                string BOD = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                if (msType != "monthly" && msType != "yearly")
                {
                    MessageBox.Show("Invalid membership type. enter 'monthly' or 'yearly'");
                    return;
                }

                if (string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
                {
                    MessageBox.Show("Please enter both first name and last name.");
                    return;
                }

                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    MessageBox.Show("Please enter a phone number.");
                    return;
                }

                if (weight <= 30 || weight >= 250)
                {
                    MessageBox.Show("Please enter a weight greater than 30 and less than 250.");
                    return;
                }

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string memberQuery = "INSERT INTO Member (memberID, fName, lName, email, nationality, msType, weight, height, BOD) " +
                            "VALUES (@memberID, @fName, @lName, @email, @nationality, @msType, @weight, @height, @BOD)";

                        SqlCommand memberinfo = new SqlCommand(memberQuery, conn, transaction);
                        memberinfo.Parameters.AddWithValue("@memberID", memberID);
                        memberinfo.Parameters.AddWithValue("@fName", fName);
                        memberinfo.Parameters.AddWithValue("@lName", lName);
                        memberinfo.Parameters.AddWithValue("@email", email);
                        memberinfo.Parameters.AddWithValue("@nationality", nationality);
                        memberinfo.Parameters.AddWithValue("@msType", msType);
                        memberinfo.Parameters.AddWithValue("@weight", weight);
                        memberinfo.Parameters.AddWithValue("@height", height);
                        memberinfo.Parameters.AddWithValue("@BOD", BOD);

                        memberinfo.ExecuteNonQuery();

                        string phoneNumberQuery = "INSERT INTO MemberPhoneNumber (mID, PhoneNumber) VALUES (@memberID, @PhoneNumber)"; // adding phone number to diffrent table

                        SqlCommand phoneNumberinfo = new SqlCommand(phoneNumberQuery, conn, transaction);
                        phoneNumberinfo.Parameters.AddWithValue("@memberID", memberID);
                        phoneNumberinfo.Parameters.AddWithValue("@phoneNumber", PhoneNumber);

                        phoneNumberinfo.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("member info entered in order:\n"+"ID: "+memberID + "\nFirst name: " + fName + "\nLast Name: " + lName + "\nemail: " + email +
                            "\nPhone number: " + PhoneNumber + "\nnationality: " + nationality + "\nmstype: " + msType + "\nweight: " + weight + "\theight: " + height + "\nBOD: " + BOD);
                        MessageBox.Show("Information insertion completed.");
                       
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("information insertion failed: " + ex.Message);
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                }
                conn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-6RP57LTV;Initial Catalog=SlimGym;Integrated Security=True")) //connection String
            {
                conn.Open();

                int memberID = int.Parse(textBox1.Text);
                String fName = textBox2.Text;
                String lName = textBox3.Text;
                String email = textBox4.Text;
                String PhoneNumber = textBox5.Text;
                string nationality = string.IsNullOrWhiteSpace(textBox6.Text) ? "Jordanian" : textBox6.Text;
                string msType = comboBox1.Text.ToLower(); // in case entered with capital M or Y
                decimal weight = decimal.Parse(textBox7.Text);
                int height = int.Parse(textBox8.Text);
                string BOD = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                if (msType != "monthly" && msType != "yearly")
                {
                    MessageBox.Show("Invalid membership type. Enter 'monthly' or 'yearly'.");
                    return;
                }

                if (string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
                {
                    MessageBox.Show("Please enter both first name and last name.");
                    return;
                }

                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    MessageBox.Show("Please enter a phone number.");
                    return;
                }

                if (weight <= 30 || weight >= 250)
                {
                    MessageBox.Show("Please enter a weight greater than 30 and less than 250.");
                    return;
                }

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string memberQuery = "UPDATE Member SET fName=@fName, lName=@lName, email=@email, " +
                            "nationality=@nationality, msType=@msType, weight=@weight, height=@height, BOD=@BOD WHERE memberID=@memberID";

                        SqlCommand memberinfo = new SqlCommand(memberQuery, conn, transaction);
                        memberinfo.Parameters.AddWithValue("@memberID", memberID);
                        memberinfo.Parameters.AddWithValue("@fName", fName);
                        memberinfo.Parameters.AddWithValue("@lName", lName);
                        memberinfo.Parameters.AddWithValue("@email", email);
                        memberinfo.Parameters.AddWithValue("@nationality", nationality);
                        memberinfo.Parameters.AddWithValue("@msType", msType);
                        memberinfo.Parameters.AddWithValue("@weight", weight);
                        memberinfo.Parameters.AddWithValue("@height", height);
                        memberinfo.Parameters.AddWithValue("@BOD", BOD);

                        memberinfo.ExecuteNonQuery();

                        int mID = int.Parse(textBox1.Text); // I need this variable , so i don't get error when updating to diffrent table

                        string phoneNumberQuery = "UPDATE memberPhoneNumber SET PhoneNumber=@phoneNumber WHERE mID=@mID"; // adding phone number to different table

                        SqlCommand phoneNumberinfo = new SqlCommand(phoneNumberQuery, conn, transaction);
                        phoneNumberinfo.Parameters.AddWithValue("@mID", mID);
                        phoneNumberinfo.Parameters.AddWithValue("@phoneNumber", PhoneNumber);

                        phoneNumberinfo.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Member information updated:\n" + "ID: " + mID + "\nFirst name: " + fName + "\nLast Name: " + lName + "\nEmail: " + email +
                            "\nPhone number: " + PhoneNumber + "\nNationality: " + nationality + "\nMembership type: " + msType + "\nWeight: " + weight + "\nHeight: " + height + "\nBOD: " + BOD);
                        MessageBox.Show("Information has been updated.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Information update failed: " + ex.Message);
                    }

                    finally
                    {
                        conn.Close(); // Closing the connection
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-6RP57LTV;Initial Catalog=SlimGym;Integrated Security=True")) //connection String
            {
                conn.Open();

                int memberID = int.Parse(textBox1.Text);

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string memberQuery = "DELETE from Member WHERE memberID=@memberID";

                        SqlCommand memberinfo = new SqlCommand(memberQuery, conn, transaction);
                        memberinfo.Parameters.AddWithValue("@memberID", memberID); 

                        memberinfo.ExecuteNonQuery();

                        int mID = int.Parse(textBox1.Text); // I need this variable , so i don't get error when deleteing from a diffrent table

                        string phoneNumberQuery = "DELETE from memberPhoneNumber WHERE mID=@mID"; // deleting phone number from a different table

                        SqlCommand phoneNumberinfo = new SqlCommand(phoneNumberQuery, conn, transaction);
                        phoneNumberinfo.Parameters.AddWithValue("@mID", mID);

                        phoneNumberinfo.ExecuteNonQuery();

                        transaction.Commit();
                        
                        MessageBox.Show("Information has been deleted.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Information deletion failed: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close(); // Closing the connection
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                }
            }
        }
    }
}
