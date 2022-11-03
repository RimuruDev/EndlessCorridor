using UnityEngine;

namespace RimuruDev
{
    public sealed class DifficultySettings : MonoBehaviour
    {
        [SerializeField] private int[] difficult = { 2, 3, 4 };
        [HideInInspector] public bool isSelectionDifficultySettings = false;

        public void SelectingDifficultyMode(string mode)
        {
            switch (mode)
            {   // TODO: Added const
                case "Easy": PlayerPrefs.SetInt("DifficultySettings", difficult[(int)DifficultyMode.Easy]); break;
                case "Normal": PlayerPrefs.SetInt("DifficultySettings", difficult[(int)DifficultyMode.Normal]); break;
                case "Hard": PlayerPrefs.SetInt("DifficultySettings", difficult[(int)DifficultyMode.Hard]); break;
                default:
                    PlayerPrefs.SetInt("DifficultySettings", difficult[(int)DifficultyMode.Easy]);
                    break;
            }

            isSelectionDifficultySettings = true;
        }

#if !UNITY_EDITOR
        private void OnValidate()
        {
            if (difficult == null)
                difficult = new int[3] { 2, 3, 4 };
        }
#endif
    }
}