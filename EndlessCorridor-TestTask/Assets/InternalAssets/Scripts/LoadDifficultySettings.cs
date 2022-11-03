using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTC.Global.Cache;

namespace RimuruDev
{
    public sealed class LoadDifficultySettings : MonoCache
    {
        private GameDataContainer dataContainer = null;

        private void Awake() => dataContainer = Find<GameDataContainer>();

        private void Start() => dataContainer.currenDiddicultMode = PlayerPrefs.GetInt("DifficultySettings");
    }
}