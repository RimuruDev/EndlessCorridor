using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTC.Global.Cache;

namespace RimuruDev
{
    public sealed class PlayerJumpAccelerationController : MonoCache
    {
        private GameDataContainer dataContainer = null;
        private float cooldownTimeIncreaseSpeed = 15f;

        private void Awake() => dataContainer = Find<GameDataContainer>();

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