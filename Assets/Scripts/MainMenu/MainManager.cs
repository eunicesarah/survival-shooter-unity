using UnityEngine;

namespace mainmain
{
    public class MainManager : Singleton<MainManager>
    {
        public void DoSomething()
        {
            Debug.Log("Doing something...");
        }
    }
}