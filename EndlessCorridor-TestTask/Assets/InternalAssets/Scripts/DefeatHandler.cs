using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NTC.Global.Cache;

namespace RimuruDev
{
    public sealed class DefeatHandler : MonoCache
    {
        public Action OnDeadth;
        private GameDataContainer dataContainer;
        private UIHandler UIHandler;

        private void Awake()
        {
            dataContainer = Find<GameDataContainer>();
            UIHandler = Find<UIHandler>();
        }

        protected override void OnEnabled()
        {
            OnDeadth += SetDefeatState;
            OnDeadth += StopTime;
            OnDeadth += SavePlayingCount;
            OnDeadth += ShowDefeatScreen;
        }

        protected override void OnDisabled()
        {
            OnDeadth -= SetDefeatState;
            OnDeadth -= StopTime;
            OnDeadth -= SavePlayingCount;
            OnDeadth -= ShowDefeatScreen;
        }

        private void ShowDefeatScreen()
        {
            dataContainer.deathScreen.SetActive(true);

            UIHandler.OnUpdateDefeatText?.Invoke();
        }

        private void SetDefeatState() => dataContainer.isFailure = true;

        private void StopTime() => Time.timeScale = 0;

        private void SavePlayingCount()
        {
            if (PlayerPrefs.GetInt("PlayingCount") == 0)
                PlayerPrefs.SetInt("PlayingCount", 1);
            else
            {
                int playingCount = PlayerPrefs.GetInt("PlayingCount");
                playingCount++;

                PlayerPrefs.SetInt("PlayingCount", playingCount);
            }
        }
    }
}