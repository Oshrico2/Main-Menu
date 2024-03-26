using System.Collections.Generic;
using System.Linq;
using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class TestWithDelegates
    {
        private MainMenu m_MainMenu;

        public void InitializeMenu()
        {
            //V1
            List<MenuItem> menuItems = new List<MenuItem>() { new MenuItem("Show Date/Time", false), new MenuItem("Version and Capital", false) };
            List<MenuItem> subMenuItems1 = new List<MenuItem>() { new MenuItem("Show Time", true), new MenuItem("Show Date", true) };
            List<MenuItem> subMenuItems2 = new List<MenuItem>() { new MenuItem("Count Capitals", true), new MenuItem("Show Version", true) };

            subMenuItems1[0].m_FunctionToActivateDelegates += this.menuItem_ShowTime;
            subMenuItems1[1].m_FunctionToActivateDelegates += this.menuItem_ShowDate;
            subMenuItems2[0].m_FunctionToActivateDelegates += this.menuItem_CountCapitals;
            subMenuItems2[1].m_FunctionToActivateDelegates += this.menuItem_ShowVersion;

            //V2

            //List<MenuItem> menuItems = new List<MenuItem>() { new MenuItem("Show Date/Time"), new MenuItem("Version and Capital") };
            //List<MenuItem> subMenuItems1 = new List<MenuItem>() { new MenuItem("Show Time", this.showTime), new MenuItem("Show Date", this.showDate) };
            //List<MenuItem> subMenuItems2 = new List<MenuItem>() { new MenuItem("Count Capitals", this.countCapitals), new MenuItem("Show Version", this.showVersion) };

            m_MainMenu = new MainMenu();
            m_MainMenu.SetFirstLevelItems(menuItems);
            m_MainMenu.SetSubItems(subMenuItems1, menuItems[0]);
            m_MainMenu.SetSubItems(subMenuItems2, menuItems[1]);
        }

        

        public void ShowMainMenu()
        {
            this.m_MainMenu.Show();
        }

        private void menuItem_ShowTime()
        {
            DateTime currentTime = DateTime.Now;

            Console.WriteLine("The hour is : " + currentTime.ToString("HH:mm:ss"));
        }

        private void menuItem_ShowDate()
        {
            DateTime currentTime = DateTime.Now;

            Console.WriteLine("The date is : " + currentTime.ToString("yyyy-MM-dd"));
        }

        private void menuItem_CountCapitals()
        {
            string str;
            int numOfCapitalLetters;

            Console.WriteLine("Enter a sentence please");
            str = Console.ReadLine();
            numOfCapitalLetters = str.Count(char.IsUpper);
            Console.WriteLine(string.Format("{0} Capital letters in your sentence", numOfCapitalLetters));
        }

        private void menuItem_ShowVersion()
        {
            Console.WriteLine("Version: 24.1.4.9633");
        }
    }
}
