using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
            Thread drunkPopUpthread = new Thread(new ThreadStart(DrunkPopUpthread));

            Console.Read();

            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPopUpthread.Start();
        }

        static void DrunkMouseThread()
        {
            Console.WriteLine("DrunkMouseThread Started");

            while (true)
            {
                Thread.Sleep(500);
            }
        }

        static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");

            while (true)
            {
                Thread.Sleep(500);
            }
        }

        static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");

            while (true)
            {
                Thread.Sleep(500);
            }
        }

        static void DrunkPopUpthread()
        {
            Console.WriteLine("DrunkPopUpthread Started");

            while (true)
            {
                Thread.Sleep(500);
            }
        }
    }
}
