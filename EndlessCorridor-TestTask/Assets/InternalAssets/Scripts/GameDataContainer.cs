using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev
{
    public sealed class GameDataContainer : MonoBehaviour
    {
        [Header("Header prefabs")]
        public GameObject playerPrefab;
        /*  [HideInInspector] */
        public GameObject playerInstance;
        public GameObject corridorPrefab;
        public GameObject obstacle;
        [Space]
        [HideInInspector] public bool isFailure;
        [Space]
        [Header("Player Settings")] //TODO: Added strucs
        public float playerSpeed = 2f;
        public float jumpForce = 100f;
        public float accelerationMultiplier = 0.5f;
        [Space]
        [Header("Difficult")]
        public float currenDiddicultMode;
        [Space]
        [Header("UI")]
        public GameObject deathScreen;
        public Text lastTime;
        public Text playingCount;
        [Space]
        [Header("Runtime")]
        public Transform runtimeRoot;
        [Space]

        // --> Tested
        [Header("Object Pooling Settings")]
        public List<GameObject> pooledObjects = null;
        public int maxAmountPerPool = 8;
        public float maxMotionDistance = 100;
        public float spawnCooldown = 0.3f;
        public Transform poopParent;
        // <--

        private void Start()
        {
            isFailure = false;
        }
    }
}