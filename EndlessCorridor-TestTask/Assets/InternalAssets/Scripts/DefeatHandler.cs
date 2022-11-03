using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RimuruDev
{
    public sealed class DefeatHandler : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;
        [SerializeField] private UIHandler UIHandler;
        public Action OnDeadth;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();

            if (UIHandler == null)
                UIHandler = FindObjectOfType<UIHandler>();
        }

        private void OnEnable()
        {
            OnDeadth += SetDefeatState;
            OnDeadth += StopTime;
            OnDeadth += SavePlayingCount;
            OnDeadth += ShowDefeatScreen;
        }

        private void OnDisable()
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