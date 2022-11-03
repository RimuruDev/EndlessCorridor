using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace RimuruDev
{
    public sealed class UIHandler : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;
        [SerializeField] private GameSessionFixationTime gameSessionFixationTime;
        public Action OnUpdateDefeatText;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();

            if (gameSessionFixationTime == null)
                gameSessionFixationTime = FindObjectOfType<GameSessionFixationTime>();
        }

        private void OnEnable()
        {
            OnUpdateDefeatText += UpdateDefeatText;
        }

        private void OnDisable()
        {
            OnUpdateDefeatText -= UpdateDefeatText;
        }

        public void UpdateDefeatText()
        {
            dataContainer.lastTime.text = $"Last time: {Mathf.Floor(gameSessionFixationTime.CurrentTimer)} seconds"; // TODO: Load playerPrefs
            dataContainer.playingCount.text = $"Playing count: {PlayerPrefs.GetInt("PlayingCount")}";
        }
    }
}