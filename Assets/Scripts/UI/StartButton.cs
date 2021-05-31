using UnityEngine;
using UnityEngine.SceneManagement;

namespace UFOT.UI
{
    /// <summary>
    /// Main menu UI element stars game
    /// </summary>
    public class StartButton : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}

