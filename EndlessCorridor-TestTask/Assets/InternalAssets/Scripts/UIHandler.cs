using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using NTC.Global.Cache;

namespace RimuruDev
{
    public sealed class UIHandler : MonoCache
    {
        public Action OnUpdateDefeatText;
        private GameDataContainer dataContainer;
        private GameSessionFixationTime gameSessionFixationTime;

        private void Awake()
        {
            dataContainer = Find<GameDataContainer>();
            gameSessionFixationTime = Find<GameSessionFixationTime>();
        }

        protected override void OnEnabled() => OnUpdateDefeatText += UpdateDefeatText;

        protected override void OnDisabled() => OnUpdateDefeatText -= UpdateDefeatText;

        public void UpdateDefeatText()
        {
            dataContainer.lastTime.text = $"Last time: {Mathf.Floor(gameSessionFixationTime.CurrentTimer)} seconds"; // TODO: Load playerPrefs
            dataContainer.playingCount.text = $"Playing count: {PlayerPrefs.GetInt("PlayingCount")}";
        }
    }
}