using UnityEngine;

namespace main
{
    public class MainManager : Singleton<MainManager>
    {
        public void DoSomething()
        {
            Debug.Log("Doing something...");
        }
    }
}