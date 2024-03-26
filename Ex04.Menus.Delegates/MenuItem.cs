using System;
using System.Collections.Generic;
namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private string m_Name;
        private List<MenuItem> m_NextLevel;
        private MenuItem m_PrevLevel;
        private bool m_IsActivateFunction;
        public event Action m_FunctionToActivateDelegates;

        //V1
        public MenuItem(string i_Name, bool i_IsActivateFunction)
        {
            m_Name = i_Name;
            m_IsActivateFunction = i_IsActivateFunction;
            m_NextLevel = new List<MenuItem>();
        }

        //V2

        //public MenuItem(string i_Name)
        //{
        //    m_Name = i_Name;
        //    m_NextLevel = new List<MenuItem>();
        //}
        //public MenuItem(string i_Name, Action I_FunctionToActivate)
        //{
        //    m_Name = i_Name;
        //    m_IsActivateFunction = true;
        //    m_FunctionToActivateDelegates += I_FunctionToActivate;
        //}
        public void NotifyObservers()
        {
            OnFunctionActivated();
        }

        protected virtual void OnFunctionActivated()
        {
            if (m_FunctionToActivateDelegates != null)
            {
                m_FunctionToActivateDelegates.Invoke();
            }
        }

        public bool IsActivateFunction
        {
            get { return m_IsActivateFunction; }
        }


        public void AddNextLevel(MenuItem item)
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

        public override string ToString()
        {
            return m_Name;
        }

    }
}