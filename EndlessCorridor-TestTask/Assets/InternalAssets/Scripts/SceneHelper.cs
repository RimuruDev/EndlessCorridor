using UnityEngine;
using UnityEngine.SceneManagement;

namespace RimuruDev
{
    public sealed class SceneHelper : MonoBehaviour
    {
        public void LoadScene(string name) => SceneManager.LoadScene(name);

        public void PlayGameScene(string name)
        {
            var difficulty = FindObjectOfType<DifficultySettings>();
            if (difficulty.isSelectionDifficultySettings == false)
                difficulty.SelectingDifficultyMode("Easy");

            LoadScene(name);
        }
    }
}