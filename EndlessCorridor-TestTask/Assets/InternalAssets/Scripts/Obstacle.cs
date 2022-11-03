using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public sealed class Obstacle : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;
        [SerializeField] private DefeatHandler defeat;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();

            if (defeat == null)
                defeat = FindObjectOfType<DefeatHandler>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Added const
            {
                Destroy(Camera.main.transform.GetComponent<CameraController>()); // Cache
                Destroy(collision.gameObject);

                defeat.OnDeadth?.Invoke();
            }
        }
    }
}