namespace Lord
{

    static class ProgramLogic
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {



            using (Lords game = new Lords())
            {
                game.Run();
            }
        }
    }

}

