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
        [HideInInspector] public List<GameObject> pooledObjects = null;
        [HideInInspector] public int maxAmountPerPool = 8;
        [HideInInspector] public float maxMotionDistance = 100;
        [HideInInspector] public float spawnCooldown = 0.3f;
        [HideInInspector] public Transform poopParent;

        private void Start()
        {
            isFailure = false;

            if (currenDiddicultMode == 0)
                currenDiddicultMode = 2;
        }

#if !UNITY_EDITOR
        private void OnValidate()
        {
            if (currenDiddicultMode == 0)
                currenDiddicultMode = 2;
        }
#endif
    }
}