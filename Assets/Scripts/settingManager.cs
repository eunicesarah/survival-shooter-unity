using UnityEngine;

namespace Nightmare {
    public class settingManager : MonoBehaviour {
        public void setName(string newText) { 
            MainManager.Instance.playerName = newText;
        }
        public void setDifficulty(int newDifficulty) {
            // if (newDifficulty < 1) {
            //     newDifficulty = 1;
            // } else {
            //     newDifficulty = newDifficulty * 2;
            // }
            Debug.Log("Difficulty set to: " + newDifficulty);
            MainManager.Instance.difficulty = newDifficulty;
        }
    }
}