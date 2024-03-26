using Ex04.Menus.Interfaces;
using System.Collections.Generic;


namespace Ex04.Menus.Test
{

    public class Program
    {

        public static void Main(string[] args)
        {
            startProgram();

        }

        private static void startProgram()
        {
            IConsoleMenuListener test1 = new TestWithInterface();
            test1.InitializeMenu();
            (test1 as TestWithInterface).ShowMainMenu();

            TestWithDelegates test2 = new TestWithDelegates();
            test2.InitializeMenu();
            test2.ShowMainMenu();
        }
    }

    
}