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
using WindowsInput;
using System.Threading;

namespace TwitchSongSync
{
    public partial class InputSetupWizard : Form
    {
        private int step = 0;
        private Point mousePos;
        private InputSim simObject;

        public InputSetupWizard(InputSim thisInputSim)
        {
            InitializeComponent();
            simObject = thisInputSim;
            mousePos = simObject.StoredMousePosition;
        }

        private void InputSetupWizard_Load(object sender, EventArgs e)
        {
            UpdateStep();
        }

        //Next/Previous buttons

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (step == 3)
            {
                simObject.StoredMousePosition = mousePos;
                this.Close();
            }
            else
            {
                step += 1;
                UpdateStep();
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            step -= 1;
            UpdateStep();
        }

        private void ControlsStandard()
        {
            buttonNext.Text = "Next";
            buttonPrevious.Text = "Previous";
            buttonNext.Enabled = true;
            buttonPrevious.Enabled = true;

            labelInstructions.Text = "";
            labelInstructions.Visible = true;

            pictureBoxMain.BackgroundImage = null;
            pictureBoxMain.Visible = true;

            buttonSetPos.Visible = false;
            buttonTestPos.Visible = false;
        }

        private void UpdateStep()
        {
            ControlsStandard();
            switch (step)
            {
                case 0:
                    labelInstructions.Text = "Move the Twitch chat into a place where you can always see it. You can't move it after setting this, so make sure it's in a good place. It might be a good idea to put it into popout mode.";
                    pictureBoxMain.BackgroundImage = Properties.Resources.Instructions1;
                    buttonPrevious.Enabled = false;
                    break;

                case 1:
                    labelInstructions.Text = "Click the \"Set Mouse Position\" button, and move your mouse over the Twitch Chat message box. Wait 4 seconds.";
                    pictureBoxMain.BackgroundImage = Properties.Resources.Instructions2;
                    buttonSetPos.Visible = true;
                    break;

                case 2:
                    labelInstructions.Text = "Now test that the position is correct. It should click on the Twitch chat message box. If it doesn't do this, go back and try again.";
                    pictureBoxMain.Visible = false;
                    buttonTestPos.Visible = true;
                    break;

                case 3:
                    labelInstructions.Text = "Now DO NOT move the Twitch chat window. Make sure the Twitch Chat is visible at all times. Click Finish to exit.";
                    pictureBoxMain.BackgroundImage = Properties.Resources.Instructions3;
                    buttonNext.Text = "Finish";
                    break;
            }
        }

        //Special buttons

        private void buttonSetPos_Click(object sender, EventArgs e)
        {
            for (int i = 40; i > 0; i--)
            {
                buttonSetPos.Text = "Wait " + ((float)i/10.0f).ToString() + " seconds...";
                this.Refresh();
                Thread.Sleep(100);
            }
            mousePos = simObject.ActualMousePosition;
            buttonSetPos.Text = "Set Mouse Position";
        }

        private void buttonTestPos_Click(object sender, EventArgs e)
        {
            simObject.TestPosition(mousePos);
        }
    }
}
