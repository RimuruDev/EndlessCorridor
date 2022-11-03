using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using NTC.Global.Cache;
using UnityEngine.SceneManagement;

namespace RimuruDev
{
    public sealed class SpawnHandler : MonoCache
    {
        [SerializeField] private int spawnCorridorCount = 20;
        [SerializeField] private int spawnObstaclesCount = 8;
        public Action OnSpawnStart;

        private GameDataContainer dataContainer;
        private ObjectPool objectPool;
        private GameObject wallParent;
        private GameObject obstacleParent;
        private float wallLength;
        private readonly float N = 10;

        private void Awake()
        {
            dataContainer = Find<GameDataContainer>();
            objectPool = Find<ObjectPool>();
        }

        private void Start()
        {
            wallParent = new GameObject("=== WallParentContainer ===");
            obstacleParent = new GameObject("=== ObstaclesParentContainer ===");

            InitialSpawnCorridor();
            SpawnPlayer();
        }

        public void StartAllCoroutine()
        {
            StartCoroutine(nameof(CorridorSpawner));
            StartCoroutine(nameof(SpawnerObstacles));
        }

        protected override void OnEnabled() => OnSpawnStart += StartAllCoroutine;

        protected override void OnDisabled() => OnSpawnStart -= StartAllCoroutine;

        private void InitialSpawnCorridor()
        {
            for (int i = 0; i < spawnCorridorCount; i++)
            {
                GameObject child = Instantiate(dataContainer.corridorPrefab, wallParent.transform);

                wallLength = child.transform.GetChild(0).localScale.z;

                child.transform.position = new Vector3(0, 0, wallLength * i);
            }
        }

        public void SpawnPlayer()
        {
            GameObject player = Instantiate(dataContainer.playerPrefab, new Vector3(1.5f, 0, 3), Quaternion.identity);

            dataContainer.playerInstance = player;

            OnSpawnStart?.Invoke();
        }

        private IEnumerator CorridorSpawner()
        {
            while (true)
            {
                float wallEndPos = wallParent.transform.GetChild(0).transform.position.z + wallLength;

                // Temp
                if (dataContainer.playerInstance == null)// && !dataContainer.isFailure)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenuScene");

                    yield break;
                }

                if (dataContainer.playerInstance.transform.position.z >= wallEndPos)
                {
                    Transform child = wallParent.transform.GetChild(0);

                    child.transform.position = new Vector3(0, 0, wallParent.transform.GetChild(wallParent.transform.childCount - 1).transform.position.z + wallLength);
                    child.transform.SetParent(dataContainer.runtimeRoot);
                    child.transform.SetParent(wallParent.transform);
                }
                yield return new WaitForFixedUpdate();
            }
        }

        private IEnumerator SpawnerObstacles()
        {
            for (int i = 1; i < spawnObstaclesCount; i++)
            {
                GameObject obstacleInstance = Instantiate(dataContainer.obstacle, dataContainer.playerInstance.transform.position + new Vector3(0, UnityEngine.Random.Range(-wallLength, wallLength) / 2, N * i), Quaternion.identity);

                obstacleInstance.transform.SetParent(obstacleParent.transform);
            }

            while (true)
            {
                if (dataContainer.playerInstance != null)
                    if (obstacleParent.transform.GetChild(0).transform.position.z + 1 < dataContainer.playerInstance.transform.position.z)
                    {
                        Destroy(obstacleParent.transform.GetChild(0).gameObject);

                        Vector3 childPos = obstacleParent.transform.GetChild(obstacleParent.transform.childCount - 1).transform.position;
                        Vector3 vector3 = new Vector3(childPos.x, UnityEngine.Random.Range(-wallLength, wallLength) / 2, childPos.z + N);

                        Instantiate(dataContainer.obstacle, vector3, Quaternion.identity).transform.SetParent(obstacleParent.transform);
                    }
                    // Temp for tested
                    else if (dataContainer.playerInstance == null && !dataContainer.isFailure)
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenuScene");

                        yield break;
                    }
                yield return new WaitForFixedUpdate();
            }
        }
    }
}