using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RimuruDev
{
    public sealed class GameSessionFixationTime : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;
        [SerializeField] private bool isDebug;
        private bool isSave;
        private float timer;
        public float CurrentTimer => timer;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();

            timer = 0;
        }

        private void Start()
        {
            StartCoroutine(nameof(Timer));
        }

        private void Update()
        {
            if (dataContainer.isFailure && isSave == false) // TODO: Added Action<>
            {
                PlayerPrefs.SetFloat("LastTime", timer);
                isSave = true;

                if (isDebug == false) return;
                Debug.Log($"Time session: [{timer}].");
                Debug.Log($"Load Last Time Session: [{PlayerPrefs.GetFloat("LastTime")}].");
            }
        }

        private IEnumerator Timer()
        {
            while (dataContainer.isFailure == false)
            {
                timer++;

                yield return new WaitForSeconds(1);
            }
        }
    }
}