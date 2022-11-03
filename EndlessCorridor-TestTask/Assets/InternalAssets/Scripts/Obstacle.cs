using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTC.Global.Cache;

namespace RimuruDev
{
    public sealed class Obstacle : MonoCache
    {
        private GameDataContainer dataContainer;
        private DefeatHandler defeat;

        private void Awake()
        {
            dataContainer = Find<GameDataContainer>();
            defeat = Find<DefeatHandler>();
        }
        /*
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Added const
            {
                Destroy(Camera.main.transform.GetComponent<CameraController>()); // Cache
                Destroy(collision.gameObject);

                defeat.OnDeadth?.Invoke();
            }
        }*/

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player")) // Added const
            {
                Destroy(Camera.main.transform.GetComponent<CameraController>()); // Cache
                Destroy(other.gameObject);

                defeat.OnDeadth?.Invoke();
            }
        }
    }
}