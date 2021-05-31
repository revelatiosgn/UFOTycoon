using UnityEngine;
using Zenject;

namespace UFOT.Commands
{
    /// <summary>
    /// Pause/Unpause game
    /// </summary>
    public class PauseCommand : ICommand
    {
        bool isPaused = false;

        public PauseCommand(bool isPaused)
        {
            this.isPaused = isPaused;
        }

        public void Execute()
        {
            Time.timeScale = isPaused ? 0f : 1f;
        }

        public class Factory : PlaceholderFactory<bool, PauseCommand>
        {
        }
    }
}

