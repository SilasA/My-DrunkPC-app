using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Media;


// Aplication Name: DrunkPC 
// (My version of Barnacules Nerdgasm's tutorial: 
// https://www.youtube.com/watch?v=48k9eyVsC-M&index=4&list=PLEbaEyM-xt9mVQEAXGlRRmbO2Qp_oqF-n)
// Description: Application that generates erratic mouse and keyboard inputs
// and generates system sounds and fake dialog to confuse the user.
//
// Runs at the default or the given times and will terminate when the time is up.
// It has the potential to run infinitely though...
//


namespace DrunkPC
{
    class Program
    {
        public static Random _random = new Random();

        public static int _startupDelaySeconds = _random.Next(90);
        public static int _totalDurationSeconds = _random.Next(10, 20);

        /// <summary>
        /// Main entry point for the program
        /// </summary>
        /// <param name="args">
        /// Array of arguements currently:
        /// 0: Startup delay for the program
        /// 1: Running time for the program
        /// </param>
        static void Main(string[] args)
        {
            Console.WriteLine("DrunkPC prank App.");

            // Check for arguements on custom timings.
            if (args.Length >= 2)
            {
                _startupDelaySeconds = Convert.ToInt32(args[0]);
                _totalDurationSeconds = Convert.ToInt32(args[1]);
            }

            #region Threads
            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopUpThread = new Thread(new ThreadStart(DrunkPopUpThread));
            #endregion

            // The loop is for future development and is pointless at this time
            while (true)
            {
                // Wait to start irritation
                DateTime future = DateTime.Now.AddSeconds(_startupDelaySeconds);
                while (future > DateTime.Now)
                {
                    Thread.Sleep(1000);
                }

                drunkMouseThread.Start();
                drunkKeyboardThread.Start();
                drunkSoundThread.Start();
                drunkPopUpThread.Start();

                // Keep irritation going for a random amount of time
                future = DateTime.Now.AddSeconds(_totalDurationSeconds);
                while (future > DateTime.Now)
                {
                    Thread.Sleep(1000);
                }

                drunkMouseThread.Abort();
                drunkKeyboardThread.Abort();
                drunkSoundThread.Abort();
                drunkPopUpThread.Abort();

                break;
            }
        }
        
        /// <summary>
        /// Moves the mouse around to random new coordinates.
        /// </summary>
        static void DrunkMouseThread() // Complete
        {
            Console.WriteLine("DrunkMouseThread Started");

            int moveX = 0;
            int moveY = 0;

            #region Loop
            while (true)
            {
                // Move the mouse cursor to a random coordinate 25% of the time
                if (_random.Next(100) > 75)
                {
                    // Generate random number to move the cursor
                    moveX = _random.Next(20) - 10;
                    moveY = _random.Next(20) - 10;

                    // Change mouse cursor to new random Coordinates
                    Cursor.Position = new System.Drawing.Point(
                        Cursor.Position.X + moveX,
                        Cursor.Position.Y + moveY);
                }
                Thread.Sleep(50);
            }
            #endregion
        }

        /// <summary>
        /// Generates random characters to output from keyboard.
        /// </summary>
        static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");

            char key;

            #region Loop
            while (true)
            {
                // Type random key 25% of the time
                if (_random.Next(100) > 75)
                {
                    // Generate random capital letter
                    key = (char)(_random.Next(25) + 65);

                    // 50/50 make it lowercase
                    if (_random.Next(2) == 0)
                        key = Char.ToLower(key);

                    SendKeys.SendWait(key.ToString());
                }
                Thread.Sleep(_random.Next(5) * 100);
            }
            #endregion
        }

        /// <summary>
        /// This will play random system sounds
        /// </summary>
        static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");

            #region Loop
            while (true)
            {
                // Play a sound 20% of the time every 1 second
                if (_random.Next(100) > 80)
                {
                    // Select from 5 different system sounds to play
                    switch (_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                }
                Thread.Sleep(1000);
            }
            #endregion
        }

        /// <summary>
        /// Makes popup windows telling the user about a false warning or error every 10 seconds
        /// </summary>
        static void DrunkPopUpThread()
        {
            Console.WriteLine("DrunkPopUpthread Started");

            #region Loop
            while (true)
            {
                // Show a popup warning/error 10% of the time every 10 seconds
                if (_random.Next(100) > 90)
                {
                    // 50% chance between the two messages
                    switch (_random.Next(2))
                    { 
                        case 0:
                            MessageBox.Show(
                                "Internet Explorer has stopped working!",
                                "Internet Explorer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show(
                                "Your system is running low on resources",
                                "Microsoft Windows",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            break;
                    }
                }
                    Thread.Sleep(10000);
            }
            #endregion
        }
    }
}
