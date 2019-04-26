using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Stuff I imported
using System.Net;
using System.IO;
using CsvHelper;

namespace TwitchSongSync
{
    public partial class FormMain : Form
    {
        private Queue<string> formActionsSend = new Queue<string>();
        public string GetFormAction() { return formActionsSend.Dequeue(); }
        public bool FormActionIsEmpty
        {
            get
            {
                if (formActionsSend.Count == 0) { return true; }
                else { return false; }
            }
        }

        //Allows other threads to change form
        private Tuple<string, bool> showError = null;
        private string[] updateUsersListbox = null;
        private string[] updateScriptTable = null;
        private Tuple<bool, bool> changeRunning = null;
        private Tuple<string, string> updateSettings = null;
        public void dgShowError(string message, bool closeApplication) { showError = new Tuple<string, bool>(message, closeApplication); }
        public void dgUpdateUsersListbox(string[] names) { updateUsersListbox = names; }
        public void dgUpdateScriptTable(string[] names) { updateScriptTable = names; }
        public void dgChangeRunning(bool isRunning, bool isHost) { changeRunning = new Tuple<bool, bool>(isRunning, isHost); }
        public void dgUpdateSettings(string prefix, string suffix) { updateSettings = new Tuple<string, string>(prefix, suffix); }

        public List<ScriptEntry> ScriptEntries = new List<ScriptEntry>();

        public InputSim InputSim = new InputSim();

        public string Prefix = "";
        public string Suffix = "";

        private bool ScriptIsRunning = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Set default import csv path
            openFileDialogCSV.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        //Helpers

        private void ReallocateScript(int lengthOfPeople)
        {
            for (int i = 0; i < ScriptEntries.Count; i++)
            {
                ScriptEntry row = ScriptEntries[i];
                ScriptEntries[i].User = i % lengthOfPeople;
            }
        }

        //Delegate functions

        private void ShowError(string message, bool closeApplication)
        {
            timerForm.Enabled = false;
            if (closeApplication)
            {
                MessageBox.Show("Error:\n" + message + "\n\nThe program will now close", "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Error: \n" + message, "Error", MessageBoxButtons.OK);
            }
            timerForm.Enabled = true;
        }

        private void UpdateUsersListbox(string[] names)
        {
            listBoxUsers.Items.Clear();

            foreach (string name in names)
            {
                listBoxUsers.Items.Add(name);
            }
        }

        private void UpdateScriptTable(string[] names)
        {
            //Clear all rows
            dataGridViewScript.Rows.Clear();

            //Iterate through list of entries, adding them to the table
            for(int i=0; i<ScriptEntries.Count;i++)
            {
                ScriptEntry row = ScriptEntries[i];
                string user = names[i % names.Length].ToString();
                dataGridViewScript.Rows.Add(new string[] { row.Time.ToString(), user, row.Content });
            }
            ReallocateScript(names.Length);
        }

        private void ChangeRunning(bool isPreparing, bool isHost)
        {
            if (isPreparing)
            {
                textBoxNickname.Text = "";
                textBoxNickname.Enabled = false;
                buttonMouseWizard.Enabled = false;
                buttonMouseTest.Enabled = false;
                buttonRun.Text = "Stop";
                ScriptIsRunning = true;
                this.TopMost = true;
                if (isHost)
                {
                    textBoxPrefix.Enabled = false;
                    textBoxSuffix.Enabled = false;
                    buttonImportCSV.Enabled = false;
                }
            }
            else if (!isPreparing)
            {
                textBoxNickname.Enabled = true;
                buttonMouseWizard.Enabled = true;
                buttonMouseTest.Enabled = true;
                buttonRun.Text = "Start";
                ScriptIsRunning = false;
                this.TopMost = false;
                if (isHost)
                {
                    textBoxPrefix.Enabled = true;
                    textBoxSuffix.Enabled = true;
                    buttonImportCSV.Enabled = true;
                }
            }
        }

        private void UpdateSettings(string thisPrefix, string thisSuffix)
        {
            Prefix = thisPrefix;
            Suffix = thisSuffix;

            UpdateSettingsPreview();
        }

        //Timer
        
        private void timerForm_Tick(object sender, EventArgs e)
        {
            //Show error
            if (showError != null)
            {
                Tuple<string, bool> toPass = showError;
                ShowError(toPass.Item1, toPass.Item2);
                showError = null;
            }

            //Update users listbox
            if (updateUsersListbox != null)
            {
                UpdateUsersListbox(updateUsersListbox);
                updateUsersListbox = null;
            }

            //Update script table
            if (updateScriptTable != null)
            {
                UpdateScriptTable(updateScriptTable);
                updateScriptTable = null;
            }

            //Change running state for control enabled
            if (changeRunning != null)
            {
                Tuple<bool, bool> toPass = changeRunning;
                ChangeRunning(toPass.Item1, toPass.Item2);
                changeRunning = null;
            }

            //Update settings
            if (updateSettings != null)
            {
                Tuple<string, string> toPass = updateSettings;
                UpdateSettings(toPass.Item1, toPass.Item2);
                updateSettings = null;
            }
        }

        //Connection groupBox

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (radioButtonHost.Checked)
            {
                //Host

                //Try to make IP Address
                IPAddress ipAddr;
                ushort port;
                try { ipAddr = IPAddress.Parse(textBoxIp.Text); }
                catch (FormatException) { ShowError("Invalid IP address", false); return; }
                try { port = Convert.ToUInt16(numericUpDownPort.Value); }
                catch (FormatException) { ShowError("Invalid port", false); return; }

                //Set enabled for elements
                buttonUserUp.Enabled = true;
                buttonUserDown.Enabled = true;
                buttonImportCSV.Enabled = true;
                buttonRun.Enabled = true;
                textBoxPrefix.Enabled = true;
                textBoxSuffix.Enabled = true;

                //Ok, now make the object and begin
                NetHost netHost = new NetHost(this, ipAddr, port);
                netHost.StartListening();
            }
            else
            {
                //Guest

                //Try to make IP Address
                IPAddress ipAddr;
                ushort port;
                try { ipAddr = IPAddress.Parse(textBoxIp.Text); }
                catch (FormatException) { ShowError("Invalid IP address", false); return; }
                try { port = Convert.ToUInt16(numericUpDownPort.Value); }
                catch (FormatException) { ShowError("Invalid port", false); return; }

                //Set enabled for elements
                buttonUserUp.Enabled = false;
                buttonUserDown.Enabled = false;
                buttonImportCSV.Enabled = false;
                buttonRun.Enabled = false;
                textBoxPrefix.Enabled = false;
                textBoxSuffix.Enabled = false;

                //Ok, now make the object and begin
                NetGuest netGuest = new NetGuest(this);
                netGuest.ConnectAndGo(ipAddr, port);
            }

            //Set enabled for elements
            groupBoxConnect.Enabled = false;
            groupBoxUsers.Enabled = true;
            groupBoxScript.Enabled = true;
            groupBoxMouseSetup.Enabled = true;
            groupBoxRun.Enabled = true;
            groupBoxSettings.Enabled = true;

            //Start timer
            timerForm.Enabled = true;
        }

        private void textBoxIp_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIp.Text == "") { buttonConnect.Enabled = false; }
            else { buttonConnect.Enabled = true; }
        }
        
        private void radioButtonHost_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHost.Checked) { buttonConnect.Text = "Listen"; }
            else { buttonConnect.Text = "Connect"; }
        }

        //Connected Users groupBox

        private void buttonUserUp_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedIndex >= 0)
            {
                formActionsSend.Enqueue("moveUser¶0¶" + listBoxUsers.SelectedIndex);
            }
        }

        private void buttonUserDown_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedIndex >= 0)
            {
                formActionsSend.Enqueue("moveUser¶1¶" + listBoxUsers.SelectedIndex);
            }
        }

        private void buttonChangeName_Click(object sender, EventArgs e)
        {
            formActionsSend.Enqueue("changeName¶" + textBoxNickname.Text);
        }

        private void textBoxNickname_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNickname.Text == "") { buttonChangeName.Enabled = false; }
            else { buttonChangeName.Enabled = true; }
        }

        //Script groupBox

        private void OrderScriptEntries()
        {
            ScriptEntries = ScriptEntries.OrderByDescending(e => e.Time).ToList();
            ScriptEntries.Reverse();
        }

        private void buttonImportCSV_Click(object sender, EventArgs e)
        {
            //Abort if the user doesn't choose a file
            if (openFileDialogCSV.ShowDialog() != DialogResult.OK) { return; }

            //Otherwise, continue

            //Open the CSV file and handle the millions of exceptions associated with trying to do this
            StreamReader reader;
            try { reader = new StreamReader(openFileDialogCSV.FileName); }
            catch (ArgumentException) { ShowError("Something went wrong while opening the CSV file", false); return; }
            catch (FileNotFoundException) { ShowError("The specified file could not be found", false); return; }
            catch (DirectoryNotFoundException) { ShowError( "The specified path is invalid", false); return; }
            catch (IOException) { ShowError("The CSV is being used by another process", false); return; }

            using (CsvReader csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.RegisterClassMap<ScriptEntryMap>();

                IEnumerable<ScriptEntry> thisEntry = csv.GetRecords<ScriptEntry>();

                //Check that the format is correct
                ScriptEntry[] thisEntryArr;
                try { thisEntryArr = thisEntry.ToArray(); }
                catch (CsvHelper.TypeConversion.TypeConverterException) { ShowError("The CSV is not formatted correctly", false); return; }

                //CSV is good to go. Load it into the list of script entries
                ScriptEntries.Clear();
                ScriptEntries.AddRange(thisEntryArr);
            }

            reader.Close();

            //Ok, now reorder it, send it off to everyone, and update it myself
            OrderScriptEntries();
            formActionsSend.Enqueue("updateScript¶");
        }

        //Keyboard Setup groupBox

        private void buttonMouseTest_Click(object sender, EventArgs e)
        {
            InputSim.TestPosition();
        }

        private void buttonKeyboardWizard_Click(object sender, EventArgs e)
        {
            InputSetupWizard wizardForm = new InputSetupWizard(InputSim);
            wizardForm.ShowDialog();
            labelMouseTest.Text = "Mouse will go to\n(" + InputSim.StoredMousePosition.X.ToString() + " ," + InputSim.StoredMousePosition.Y.ToString() + ")";
        }

        //Run groupBox

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (!ScriptIsRunning)
            {
                ScriptIsRunning = true;
                formActionsSend.Enqueue("run¶true");
            }
            else if (ScriptIsRunning)
            {
                ScriptIsRunning = false;
                formActionsSend.Enqueue("run¶false");
            }
        }


        //Settings groupBox
        
        private void UpdateSettingsPreview()
        {
            labelTextPreview.Text = "Preview: " + Prefix + "%LINE%" + Suffix;
        }

        private void textBoxPrefix_Enter(object sender, EventArgs e)
        {
            if (Prefix == "")
            {
                textBoxPrefix.ForeColor = SystemColors.WindowText;
                textBoxPrefix.Text = "";
            }
        }

        private void textBoxSuffix_Enter(object sender, EventArgs e)
        {
            if (Suffix == "")
            {
                textBoxSuffix.ForeColor = SystemColors.WindowText;
                textBoxSuffix.Text = "";
            }
        }

        private void textBoxPrefix_Leave(object sender, EventArgs e)
        {
            Prefix = textBoxPrefix.Text;

            UpdateSettingsPreview();
            formActionsSend.Enqueue("updateSettings¶");

            if (Prefix == "")
            {
                textBoxPrefix.ForeColor = SystemColors.GrayText;
                textBoxPrefix.Text = "Prefix";
            }
        }

        private void textBoxSuffix_Leave(object sender, EventArgs e)
        {
            Suffix = textBoxSuffix.Text;

            UpdateSettingsPreview();
            formActionsSend.Enqueue("updateSettings¶");

            if (Suffix == "")
            {
                textBoxSuffix.ForeColor = SystemColors.GrayText;
                textBoxSuffix.Text = "Suffix";
            }
        }
    }
}
