using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class InputHandler : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;
        private Rigidbody playerRigidbody;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();
        }

        private void Start() => playerRigidbody = GetComponent<Rigidbody>();

        private void Update() => transform.Translate(0, 0, dataContainer.playerSpeed * dataContainer.currenDiddicultMode * Time.deltaTime);

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                playerRigidbody.AddForce(Vector3.up * dataContainer.jumpForce);// TODO: Added Action
            }
        }
    }
}