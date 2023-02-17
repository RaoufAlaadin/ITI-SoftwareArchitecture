namespace D11Tasks
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            /*We change the class we want to run from here. */
            Application.Run(new lec_3_frmRTF());
            Application.Run(new _2_Paint());
            Application.Run(new _3_DragANDdrop());
            Application.Run(new lec_7_frmMickey());
            Application.Run(new _5_MovingBall());


        }
    }
}