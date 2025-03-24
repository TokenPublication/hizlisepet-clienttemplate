/**
 * TokenDotNet - Point of Sale (POS) Integration Client
 * =================================================================
 * 
 * Language/Platform: C# Windows Forms Application (.NET Framework)
 * 
 * Project Description:
 * This application serves as a client implementation for integrating with POS 
 * (Point of Sale) devices through the "TokenX Connect (Wired)" or "Integration Hub" 
 * service. It establishes communication between merchant systems and payment terminals.
 * 
 * Key Components:
 * - Implements TOKEN FINTECH integration protocols
 * - Uses IntegrationHub library for POS communication
 * - Provides a Windows Forms based user interface (MainForm) for interaction
 * 
 * Integration Details:
 * This client establishes a communication channel with POS devices through the 
 * IntegrationHub.POSCommunication singleton instance. The application identifies
 * itself as "TOKEN FINTECH" to the integration service, which enables proper 
 * routing and protocol handling for payment transactions.
 * 
 * Version Information:
 * Current version: 2.1.0
 * 
 * Usage:
 * This application initializes the Windows Forms environment and launches the main
 * interface (MainForm) which handles user interactions and payment operations.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntegrationHub;

namespace TokenDotNet
{
    /// <summary>
    /// Main program class that initializes the application, establishes POS communication,
    /// and launches the user interface.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        /// <summary>
        /// Current version of the application.
        /// Used for tracking compatibility and feature sets.
        /// </summary>
        public static string version = "Version = 2.1.0";
        
        
        /// <summary>
        /// Singleton instance of the POS communication interface.
        /// Handles all protocol-specific interactions with the payment terminal.
        /// The "TOKEN FINTECH" parameter identifies this client to the integration hub.
        /// </summary>
        public static IntegrationHub.POSCommunication communication = IntegrationHub.POSCommunication.getInstance("TOKEN FINTECH");

        /// <summary>
        /// Application entry point that initializes the Windows Forms environment
        /// and launches the main application interface.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable visual styles for modern Windows UI appearance
            Application.EnableVisualStyles();
            
            // Configure text rendering for compatibility
            Application.SetCompatibleTextRenderingDefault(false);

            // Create and run the main application form
            Application.Run(new MainForm());
        }
    }
}
