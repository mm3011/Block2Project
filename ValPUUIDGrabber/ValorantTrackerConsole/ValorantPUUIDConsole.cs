// <copyright file="ValorantPUUIDConsole.cs" company="MillerMatt">
// Copyright (c) MillerMatt. All rights reserved.
// </copyright>

namespace ValorantTrackerConsole
{
    using ValorantPUUIDGrabber;

    /// <summary>
    /// Console display class for ValorantPUUIDGrabber Application.
    /// </summary>
    public class ValorantPUUIDConsole()
    {
        /// <summary>
        /// Tracker object initialization.
        /// </summary>
        private static ValorantPUUIDGrabber grabber = new ValorantPUUIDGrabber();

        private static string? gameName;

        private static string? tagLine;

        /// <summary>
        /// Main running method for the console application.
        /// </summary>
        /// <param name="args">running arguments.</param>
        public static void Main(string[] args)
        {
            grabber.InitializeAPIStrings();

            Console.WriteLine($"Please enter riotid gamename:");
            gameName = Console.ReadLine();

            Console.WriteLine($"Please enter riotid tagLine:");
            tagLine = Console.ReadLine();

            if (!string.IsNullOrEmpty(tagLine) && !string.IsNullOrEmpty(gameName))
            {
                grabber.InitializeAPIConnection(gameName, tagLine);
            }
        }
    }
}
