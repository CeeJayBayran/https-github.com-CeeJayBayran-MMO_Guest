

    using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using ClassLibrary1;
using DataMMO.DataLayer;
namespace MMOGUI
{
    public partial class Form1 : Form
    {// THIS PART WORKS FOR THE CONNECTION OF THIS FORM TO IN DB MILLIONARE ORG //
        private readonly DBMillionaireOrg db = new DBMillionaireOrg();
        private readonly Dictionary<string, string> allowedGuests = new()
        {
            { "Trench Mauser", "CEO, Mauser Global Logistics" },
            { "Galan Galgo", "CEO, Galgo World Mobility" },
            { "Hale Caesar", "CEO, Caesar Mineral Industries" },
            { "Toll Road", "CEO, Roadchain Digital Core" },
            { "Yin Yang", "CEO, Yang Discipline Systems" },
            { "Gunner Jensen", "CEO, Jensen IronWorks" },
            { "Lee Christmas", "CEO, Christmas Global Protection" },
            { "Barney Ross", "Supreme Chairman, Ross Legacy Holdings" },
            { "James Munroe", "CEO, Munroe Risk Authority" },
            { "Jean Vilain", "CEO, Vilain Prestige Holdings" },
            { "Conrad Stonebanks", "CEO, Stonebanks Shadow Trade" },
            { "Dan Paine", "CEO, Paine Property Dominion" },
            { "Billy Timmons", "CEO, Timmons Nexus Systems" },
            { "General Garza", "CEO, Garza Influence Bureau" },
            { "Easy Day", "CEO, DayHaul Global Freight" },
            { "Charisma Carpenter", "CEO, Charisma Echo PR" },
            { "Maggie Chan", "CEO, Chan CyberBlack Division" },
            { "Mr Church", "CEO, Church Phantom Affairs" },
            { "Max Drummer", "CEO, Drummer Aerial Systems Inc" },
            { "Sylvester Stallone", "Honorary Founder, Stallone Legacy Fund" }
        };

        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "MILLIONAIRE MINDS ORGANIZATION";
            label1.Font = new Font("Onyx", 48, FontStyle.Italic);
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.AutoSize = false;
            label1.Width = this.Width;
            label1.Height = 60;
            label1.Location = new Point(0, 10);
            label1.BorderStyle = BorderStyle.None;

            label2.Text = "ENTER NAME :";
            label2.Font = new Font("Bodoni MT", 11, FontStyle.Regular);
            label2.ForeColor = Color.White;
            label2.BackColor = Color.Transparent;
            label2.AutoSize = true;

            textBox1.Font = new Font("Bodoni MT", 10, FontStyle.Regular);
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(140, 130);
            textBox1.Size = new Size(190, 30);
            textBox1.Text = " ";
            textBox1.ReadOnly = false;

            RefreshGuestList();

        }
        private void RefreshGuestList()
        {
            Members.Items.Clear();
            foreach (var g in db.GetAllGuests())
                Members.Items.Add($"{g.Name} - {g.Role}");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (!allowedGuests.ContainsKey(name))
            {
                MessageBox.Show("You are not allowed to enter this organization.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (db.Exists(name))
            {
                MessageBox.Show("You are already registered in the organization.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string role = allowedGuests[name];
            if (db.Register(name, role))
            {
                MessageBox.Show($"Welcome {name}, you have been registered as {role}.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGuestList();
            }
            else
            {
                MessageBox.Show("Failed to register. Please try again.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = " ";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshGuestList();
            int count = Members.Items.Count;
            MessageBox.Show($"Total Guests Present: {count}", "Guest Count", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            var guest = db.SearchGuest(name);
            if (guest != null)
            {
                MessageBox.Show($"{guest.Name}- {guest.Role}\nTimeIn In: {guest.TimeIn}", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Guest not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (db.ExitGuest(name))
            {
                MessageBox.Show($"Goodbye {name}, you have exited the organization.", "Exit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGuestList();
            }
            else
            {
                MessageBox.Show("Failed to exit. Please try again.", "Exit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = " ";
        }

       
    }
}
