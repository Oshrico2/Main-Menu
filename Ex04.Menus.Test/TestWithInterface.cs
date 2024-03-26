using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
public class TestWithInterface : IConsoleMenuListener
{
    private MainMenu m_MainMenu;

    void IConsoleMenuListener.InitializeMenu()
    {
        List<MenuItem> menuItems = new List<MenuItem>() { new MenuItem("Show Date/Time"), new MenuItem("Version and Capital") };
        List<MenuItem> subMenuItems1 = new List<MenuItem>() { new MenuItem("Show Time", "showTime"), new MenuItem("Show Date", "showDate") };
        List<MenuItem> subMenuItems2 = new List<MenuItem>() { new MenuItem("Count Capitals", "countCapitals"), new MenuItem("Show Version", "showVersion") };

        m_MainMenu = new MainMenu(this);
        m_MainMenu.SetFirstLevelItems(menuItems);
        m_MainMenu.SetSubItems(subMenuItems1, menuItems[0]);
        m_MainMenu.SetSubItems(subMenuItems2, menuItems[1]);
    }

    public void ShowMainMenu()
    {
        this.m_MainMenu.Show();
    }

    void IConsoleMenuListener.ActivateFunction(string i_FunctionToActivate)
    {
        switch (i_FunctionToActivate)
        {
            case "showTime":
                showTime();
                break;
            case "showDate":
                showDate();
                break;
            case "countCapitals":
                countCapitals();
                break;
            case "showVersion":
                showVersion();
                break;
            default:
                throw new NotImplementedException("There is no function to activate with this name");
        }
    }

    private static void showTime()
    {
        DateTime currentTime = DateTime.Now;

        Console.WriteLine("The hour is : " + currentTime.ToString("HH:mm:ss"));
    }

    private static void showDate()
    {
        DateTime currentTime = DateTime.Now;

        Console.WriteLine("The date is : " + currentTime.ToString("yyyy-MM-dd"));
    }

    private static void countCapitals()
    {
        string str;
        int numOfCapitalLetters;

        Console.WriteLine("Enter a sentence please");
        str = Console.ReadLine();
        numOfCapitalLetters = str.Count(char.IsUpper);
        Console.WriteLine(string.Format("{0} Capital letters in your sentence", numOfCapitalLetters));
    }

    private static void showVersion()
    {
        Console.WriteLine("Version: 24.1.4.9633");
    }

}