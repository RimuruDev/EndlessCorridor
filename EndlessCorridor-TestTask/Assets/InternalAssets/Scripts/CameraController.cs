using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTC.Global.Cache;

namespace RimuruDev
{
    public sealed class CameraController : MonoCache
    {
        [SerializeField] private GameDataContainer dataContainer;
        [SerializeField] private Vector3 offset;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();
        }

        public void Start()
        {
            if (offset == Vector3.zero)
                offset = transform.position;
        }

        protected override void LateRun() => transform.position = new Vector3(0, 0, dataContainer.playerInstance.transform.position.z) + offset;
    }
}