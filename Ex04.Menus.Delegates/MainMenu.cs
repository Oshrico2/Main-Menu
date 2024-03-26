using System;
using System.Collections.Generic;
using System.Reflection;
namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private List<MenuItem> m_MenuItems;
        private List<MenuItem> m_CurrItems;
        public MainMenu()
        {
            m_MenuItems = new List<MenuItem>();
            m_CurrItems = m_MenuItems;
        }

        public void SetFirstLevelItems(List<MenuItem> i_Items)
        {
            foreach (MenuItem item in i_Items)
            {
                m_MenuItems.Add(item);
            }
        }

        public void SetSubItems(List<MenuItem> i_Items, MenuItem i_BaseItem)
        {
            if (i_BaseItem.IsActivateFunction)
            {
                throw new Exception("ActivateFunction item can't have sub items.");
            }
            else
            {
                foreach (MenuItem item in i_Items)
                {
                    i_BaseItem.AddNextLevel(item);
                    item.PrevLevel = i_BaseItem;
                }
            }

        }

        public void Show(MenuItem i_BaseItem = null)
        {
            while (true)
            {
                showLevel();
                try
                {
                    if (chooseInput())
                    {
                        break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message + "\nPress any key to continue.");
                    Console.ReadLine();
                }
            }
        }

        private void showLevel()
        {
            int counter = 1;

            Console.Clear();
            if (m_CurrItems == m_MenuItems)
            {
                Console.WriteLine("Delegates Main Menu\n");
                Console.WriteLine("0 - Exit");
            }
            else
            {
                Console.WriteLine(m_CurrItems[0].PrevLevel.ToString() + "\n");
                Console.WriteLine("0 - Back");
            }

            foreach (MenuItem item in m_CurrItems)
            {
                Console.WriteLine(counter.ToString() + " - " + item.ToString());
                counter++;

            }
        }

        private bool chooseInput()
        {
            string input = Console.ReadLine();
            bool isQuit = false;
            int.TryParse(input, out int inputNumber);


            if(inputNumber == 0 && input == "0")
            {
               isQuit = goPrevLevel();
            }
            else if (inputNumber >= 1 && inputNumber < m_CurrItems.Count + 1)
            {
                if (!m_CurrItems[inputNumber - 1].IsActivateFunction)
                {
                    m_CurrItems = m_CurrItems[inputNumber - 1].NextLevel;
                }
                else
                {
                    handleActivateFunction(m_CurrItems[inputNumber - 1]);
                }
            }
            else
            {
                throw new Exception($"min number - 0 , max number {m_CurrItems.Count}");
            }

            return isQuit;
        }

        private bool goPrevLevel()
        {
            bool isQuit = false;

            if (m_CurrItems[0].PrevLevel == null)
            {
                Console.WriteLine("Bye bye");
                isQuit = true;
            }
            else if(m_CurrItems[0].PrevLevel.PrevLevel == null)
            {
                m_CurrItems = m_MenuItems;
            }
            else{
                m_CurrItems = m_CurrItems[0].PrevLevel.PrevLevel.NextLevel;
            }

            return isQuit;
        }

        private void handleActivateFunction(MenuItem i_Item)
        {
            i_Item.NotifyObservers();
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}





