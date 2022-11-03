using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public sealed class PlayerJumpAccelerationController : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer = null;
        [SerializeField] private float cooldownTimeIncreaseSpeed = 15f;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();
        }

        private void Start() => StartCoroutine(nameof(IncreaseSpeed));

        private IEnumerator IncreaseSpeed()
        {
            while (true)
            {
                dataContainer.jumpForce += dataContainer.accelerationMultiplier;

                yield return new WaitForSeconds(cooldownTimeIncreaseSpeed);
            }
        }
    }
}