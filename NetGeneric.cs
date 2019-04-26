using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TwitchSongSync
{
    abstract class NetGeneric
    {
        protected readonly FormMain theForm;

        protected readonly Stopwatch stopwatch = new Stopwatch();

        protected bool _preparingToRun = false;
        protected bool PreparingToRun
        {
            get { return _preparingToRun; }
            set
            {
                _preparingToRun = value;

                //Update the form controls
                if (GetType() == typeof(NetHost)) { theForm.dgChangeRunning(_preparingToRun, true); }
                else if (GetType() == typeof(NetGuest)) { theForm.dgChangeRunning(_preparingToRun, false); }

                if (IsRunning == true && _preparingToRun == false)
                {
                    IsRunning = false;
                }
            }
        }
        protected bool _isRunning = false;
        protected bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                //Start/stop stopwatch based on value
                if (value && !_isRunning) { stopwatch.Restart(); }
                else if (!value && _isRunning)  { stopwatch.Stop(); }

                _isRunning = value;

                if (PreparingToRun == false && _isRunning == true)
                {
                    PreparingToRun = true;
                }
            }
        }

        private InputSim simObj;

        protected int myIndex;
        protected int nextScript;

        public NetGeneric(FormMain thisForm)
        {
            theForm = thisForm;
            simObj = theForm.InputSim;
        }

        private void ProcessScriptEntry(string content)
        {
            theForm.InputSim.TypeTextAndSend(content);
        }

        protected void CheckForScript()
        {
            if (IsRunning)
            {
                if (nextScript < theForm.ScriptEntries.Count)
                {
                    if (stopwatch.Elapsed.TotalSeconds >= theForm.ScriptEntries[nextScript].Time)
                    {
                        //Ok, the time has come to process this one
                        if (theForm.ScriptEntries[nextScript].User == myIndex)
                        {
                            string content = theForm.Prefix + theForm.ScriptEntries[nextScript].Content + theForm.Suffix;
                            Console.WriteLine("Sending " + content + " which should be at " + theForm.ScriptEntries[nextScript].Time.ToString() + ", at " + stopwatch.Elapsed.TotalSeconds.ToString());
                            ProcessScriptEntry(content);
                        }

                        //Move the nextScript up one
                        nextScript += 1;
                    }
                }
                else
                {
                    //We've reached the end!
                    PreparingToRun = false;
                }
            }
        }

        protected Tuple<string, string> FormatResponse(string response)
        {
            int splitPlace = response.IndexOf('¶');

            string opcode = response.Substring(0, splitPlace);
            string operand = response.Substring(splitPlace + 1);

            return new Tuple<string, string>(opcode, operand);
        }

        protected string[] FormatOperand(string operand)
        {
            return operand.Split('¶');
        }
    }
}
