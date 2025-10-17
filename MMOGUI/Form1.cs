using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessMMO;             
using ClassLibrary1;     
using CommonMMO;
using DataMMO.DataLayer;         

namespace MMOGUI//
{
    public partial class Form1 : Form
    {
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
        private void label1_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name.", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

      
            textBox1.SelectAll();
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
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name to search.", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var guest = db.SearchGuest(name);
            if (guest != null)
            {
                MessageBox.Show($"{guest.Name} - {guest.Role}\nTime In: {guest.TimeIn}", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Guest not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //This is for not erasing or not be gone the name in the textbox after registering or exit
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name to exit.", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (db.ExitGuest(name))
            {
                MessageBox.Show($"Goodbye {name}, you have exited the organization.", "Exit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGuestList();
            }
            else
            {
                MessageBox.Show("Failed to exit. Please try again.", "Exit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            textBox1.SelectAll();
        }

        // SEND EMAIL this is for the part wherein theuser will click the button to send an email to mailtrap
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name first.", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // I have this unique function wherein only the authorized members of my organization who can only join or eenter and send notif 
            if (!allowedGuests.ContainsKey(name))
            {
                MessageBox.Show(" Only authorized members can send notifications.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // asking email of the recipient or the one who has the mailtrap for sending notification
            string recipient = Microsoft.VisualBasic.Interaction.InputBox("Enter recipient email address:", "Send Email", "test@example.com");
            if (string.IsNullOrWhiteSpace(recipient))
            {
                MessageBox.Show("No recipient entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Notification part in mailtrap if successful
            EmailInfo info = new EmailInfo
            {
                To = recipient,
                Subject = "MMO Organization Notification",
                Body = $"Dear {name},\n\nYour activity has been logged in the MMO system.\n\nRegards,\nMillionaire Minds Organization"
            };

            try
            {
                // This part was use to make a connection with my BLMMO
                EmailService emailService = new EmailService();
                emailService.SendEmail(name,info); 

                MessageBox.Show(" Email successfully sent via Mailtrap!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Clear();
            textBox1.Focus();
        }
    }
}
