using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace RimuruDev
{
    public sealed class SpawnHandler : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;
        [SerializeField] private ObjectPool objectPool;
        [SerializeField] private int spawnCorridorCount = 20;
        [SerializeField] private int spawnObstaclesCount = 8;
        public Action OnSpawnStart;

        private GameObject wallParent;
        private GameObject obstacleParent;
        private float wallLength;
        private readonly float N = 10;

        private void Awake()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();
            if (objectPool == null)
                objectPool = FindObjectOfType<ObjectPool>();
        }

        private void Start()
        {
            wallParent = new GameObject("=== WallParentContainer ===");
            obstacleParent = new GameObject("=== ObstaclesParentContainer ===");

            InitialSpawnCorridor();

            SpawnPlayer();

            //StartCoroutine(nameof(CorridorSpawner));
            //StartCoroutine(nameof(SpawnerObstacles));
        }

        public void StartAllCoroutine()
        {
            StartCoroutine(nameof(CorridorSpawner));
            StartCoroutine(nameof(SpawnerObstacles));
        }

        private void OnEnable()
        {
            OnSpawnStart += StartAllCoroutine;
        }

        private void OnDisable()
        {
            OnSpawnStart -= StartAllCoroutine;
        }

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

            //objectPool?.OnPopulatingObjectPool.Invoke();
            OnSpawnStart?.Invoke();
        }

        private IEnumerator CorridorSpawner()
        {
            if (dataContainer.playerInstance == null)
                yield break;

            while (true)
            {
                float wallEndPos = wallParent.transform.GetChild(0).transform.position.z + wallLength;

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
                if (obstacleParent.transform.GetChild(0).transform.position.z + 1 < dataContainer.playerInstance.transform.position.z)
                {
                    Destroy(obstacleParent.transform.GetChild(0).gameObject);

                    Vector3 childPos = obstacleParent.transform.GetChild(obstacleParent.transform.childCount - 1).transform.position;
                    Vector3 vector3 = new Vector3(childPos.x, UnityEngine.Random.Range(-wallLength, wallLength) / 2, childPos.z + N);

                    Instantiate(dataContainer.obstacle, vector3, Quaternion.identity).transform.SetParent(obstacleParent.transform);
                }
                yield return new WaitForFixedUpdate();
            }
        }
    }
}