using System.Collections.Generic;
namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Name;
        private List<MenuItem> m_NextLevel;
        private MenuItem m_PrevLevel;
        private string m_FunctionToActivate;
        private bool m_Clickable;

        public MenuItem(string i_Name)
        {
            m_Name = i_Name;
            m_Clickable = true;
            m_NextLevel = new List<MenuItem>();
        }

        public MenuItem(string i_Name, string i_FunctionToActivate)
        {
            m_Name = i_Name;
            m_FunctionToActivate = i_FunctionToActivate;
        }

        public bool Clickable
        {
            get { return m_Clickable; }
        }

        public void addItem(MenuItem item)
        {
            m_NextLevel.Add(item);
        }

        public MenuItem PrevLevel
        {
            set { m_PrevLevel = value; }
            get { return m_PrevLevel; }
        }

        public List<MenuItem> NextLevel
        {
            get { return m_NextLevel; }
        }

        public string FunctionToActivate
        {
            get { return m_FunctionToActivate; }
        }

        public override string ToString()
        {
            return m_Name;
        }

    }
}