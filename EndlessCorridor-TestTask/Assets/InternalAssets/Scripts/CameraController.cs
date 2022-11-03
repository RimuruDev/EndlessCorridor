using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTC.Global.Cache;

namespace RimuruDev
{
    public sealed class CameraController : MonoCache
    {
        [SerializeField] private Vector3 offset;
        private GameDataContainer dataContainer;

        private void Awake() => dataContainer = Find<GameDataContainer>();

        public void Start() { if (offset == Vector3.zero) offset = transform.position; }

        protected override void LateRun() => transform.position = new Vector3(0, 0, dataContainer.playerInstance.transform.position.z) + offset;
    }
}