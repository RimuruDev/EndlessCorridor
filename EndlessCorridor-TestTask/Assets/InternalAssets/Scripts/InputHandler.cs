using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NTC.Global.Cache;

namespace RimuruDev
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class InputHandler : MonoCache
    {
        private GameDataContainer dataContainer = null;
        private Rigidbody playerRigidbody;

        private void Awake() => dataContainer = FindObjectOfType<GameDataContainer>();

        private void Start() => playerRigidbody = GetComponent<Rigidbody>();

        protected override void Run() => transform.Translate(0, 0, dataContainer.playerSpeed * dataContainer.currenDiddicultMode * Time.deltaTime);

        protected override void FixedRun()
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                playerRigidbody.AddForce(Vector3.up * dataContainer.jumpForce);// TODO: Added Action
            }
        }
    }
}