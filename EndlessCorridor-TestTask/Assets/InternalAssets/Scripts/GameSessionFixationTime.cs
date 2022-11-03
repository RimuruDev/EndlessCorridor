using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using NTC.Global.Cache;

namespace RimuruDev
{
    public sealed class GameSessionFixationTime : MonoCache
    {
        private GameDataContainer dataContainer;
        private bool isSave;
        private float timer = 0;
        public float CurrentTimer => timer;

        private void Awake() => dataContainer = Find<GameDataContainer>();

        private void Start() => StartCoroutine(nameof(Timer));

        protected override void Run()
        {
            if (dataContainer.isFailure && !isSave) // TODO: Added Action<>
            {
                PlayerPrefs.SetFloat("LastTime", timer);
                isSave = true;
            }
        }

        private IEnumerator Timer()
        {
            while (!dataContainer.isFailure)
            {
                timer++;

                yield return new WaitForSeconds(1);
            }
        }
    }
}