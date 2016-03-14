using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

//
// Aplication Name: DrunkPC (My version of Barnacules Nerdgasm's tutorial)
// Description: Application that generates erratic mouse and keyboard movements
// and input and generates system sounds and fake dialog to confuse the user.
//


namespace DrunkPC
{
    class Program
    {
        public static Random _random = new Random();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("DrunkPC prank App.");

            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopUpThread = new Thread(new ThreadStart(DrunkPopUpThread));

            DateTime future = DateTime.Now.AddSeconds(10);
            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPopUpThread.Start();

            future = DateTime.Now.AddSeconds(10);
            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            drunkMouseThread.Abort();
            drunkKeyboardThread.Abort();
            drunkSoundThread.Abort();
            drunkPopUpThread.Abort();
        }
        
        /// <summary>
        /// Moves the mouse around to random new coordinates.
        /// </summary>
        static void DrunkMouseThread() // Complete
        {
            Console.WriteLine("DrunkMouseThread Started");

            int moveX = 0;
            int moveY = 0;

            while (true)
            {
                //Console.WriteLine(Cursor.Position.ToString());

                // Generate random number to move the cursor
                moveX = _random.Next(20) - 10;
                moveY = _random.Next(20) - 10;

                // Change mouse cursor to new random Coordinates
                Cursor.Position = new System.Drawing.Point(
                    Cursor.Position.X + moveX, 
                    Cursor.Position.Y + moveY);

                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// Generates random characters to output from keyboard.
        /// </summary>
        static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");

            char key;

            while (true)
            {
                // Generate random capital letter
                key = (char)(_random.Next(25) + 65);

                // 50/50 make it lowercase
                if (_random.Next(2) == 0)
                    key = Char.ToLower(key);

                SendKeys.SendWait(key.ToString());

                Thread.Sleep(_random.Next(500));
            }
        }

        /// <summary>
        /// This will play random system sounds
        /// </summary>
        static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");

            while (true)
            {
                // Play a sound 20% of the time
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
        }

        /// <summary>
        /// Makes popup windows telling the user about a false warning or error every 10 seconds
        /// </summary>
        static void DrunkPopUpThread()
        {
            Console.WriteLine("DrunkPopUpthread Started");

            while (true)
            {
                if (_random.Next(100) > 90)
                {
                    switch (_random.Next(2))
                    { 
                        case 0:
                            MessageBox.Show("Internet Explorer has stopped working!",
                                "Internet Explorer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show("Your system is running low on resources",
                                "Microsoft Windows",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            break;
                    }
                }
                    Thread.Sleep(10000);
            }
        }
    }
}
