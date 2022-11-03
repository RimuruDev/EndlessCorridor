using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public sealed class LoadDifficultySettings : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();
        }

        private void Start() => dataContainer.currenDiddicultMode = PlayerPrefs.GetInt("DifficultySettings");
    }
}