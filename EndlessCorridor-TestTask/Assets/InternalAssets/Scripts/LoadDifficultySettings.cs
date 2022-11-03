using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public sealed class LoadDifficultySettings : MonoBehaviour
    {
        private GameDataContainer dataContainer = null;

        private void Awake() => dataContainer = FindObjectOfType<GameDataContainer>();

        private void Start() => dataContainer.currenDiddicultMode = PlayerPrefs.GetInt("DifficultySettings");
    }
}