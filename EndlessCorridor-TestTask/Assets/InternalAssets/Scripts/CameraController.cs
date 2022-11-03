using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;
        [SerializeField] private Vector3 offset;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();
        }

        private void Start()
        {
            if (offset == Vector3.zero)
                offset = transform.position;
        }

        private void LateUpdate() => transform.position = new Vector3(0, 0, dataContainer.playerInstance.transform.position.z) + offset;
    }
}