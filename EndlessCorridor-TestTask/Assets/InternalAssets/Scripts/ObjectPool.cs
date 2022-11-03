using UnityEngine;
using System;

namespace RimuruDev
{
    public sealed class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameDataContainer dataContainer;
        // public Action OnPopulatingObjectPool;

        private void Awake() => InitRef();

        //private void Start() => PopulatingObjectPool();

        private void OnValidate() => InitRef();

        private void OnEnable()
        {
            //OnPopulatingObjectPool += PopulatingObjectPool;
        }

        private void OnDisable()
        {
            //OnPopulatingObjectPool -= PopulatingObjectPool;
        }

        public GameObject GetPoolingObjects()
        {
            for (int i = 0; i < dataContainer.pooledObjects.Count; i++)
            {
                if (!dataContainer.pooledObjects[i].activeInHierarchy)
                {
                    return dataContainer.pooledObjects[i];
                }
            }

            return default;
        }

        private void PopulatingObjectPool()
        {
            for (int i = 0; i < dataContainer.maxAmountPerPool; i++)
            {
                // var cube = Instantiate(dataContainer.cubePrefab, dataContainer.spawnPoint);
                // cube.transform.SetParent(dataContainer.objectContainerParent);
                //  cube.SetActive(false);

                // var obstacleInstance = Instantiate(dataContainer.obstacle, dataContainer.playerInstance.transform.position + new Vector3(0, UnityEngine.Random.Range(-3, 3) / 2, 10 * i), Quaternion.identity);
                // obstacleInstance.transform.SetParent(dataContainer.poopParent);
            }
        }

        private void InitRef()
        {
            if (dataContainer == null)
                dataContainer = FindObjectOfType<GameDataContainer>();
        }
    }
}