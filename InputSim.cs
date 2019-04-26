using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Stuff I added
using WindowsInput;
using WindowsInput.Native;
using System.Windows.Forms;
using System.Drawing;

namespace TwitchSongSync
{
    public class InputSim
    {
        private readonly InputSimulator simObject = new InputSimulator();

        public InputSim()
        {
            StoredMousePosition = new Point(0, 0);
        }
        
        public Point StoredMousePosition { get; set; }

        public Point ActualMousePosition
        {
            get { return Cursor.Position; }
            set { Cursor.Position = value; }
        }

        public void Click()
        {
            simObject.Mouse.LeftButtonClick();
        }

        public void TestPosition(Point position = new Point())
        {
            if (position.IsEmpty) { position = StoredMousePosition; }
            ActualMousePosition = position;
            Click();
        }

        public void TypeTextAndSend(string textToEnter)
        {
            //Goto twitch chat box
            ActualMousePosition = StoredMousePosition;
            //Click on it
            simObject.Mouse.LeftButtonClick();
            //CTRL+a
            simObject.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
            //Backspace
            simObject.Keyboard.KeyPress(VirtualKeyCode.BACK);
            //Enter new text
            simObject.Keyboard.TextEntry(textToEnter);
            //Hit enter to send
            simObject.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        
    }
}
