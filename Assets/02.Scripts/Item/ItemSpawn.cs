using System.Collections;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawn : MonoBehaviour
{
    [Header("ÇÁ¸®ÆÕ")]
    public ItemA itemAPrefab;

    [Header("À§Ä¡ ÁÂÇ¥")]
    [SerializeField] BoxCollider spawnArea;
    [SerializeField] private float randomY = 0.5f;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(InitializePool());
    }
    IEnumerator InitializePool()
    {
        while (UIManager.Instance == null)
        {
            yield return null; 
        }

        if (itemAPrefab != null)
        {
            PoolManager.Instance.CreatPool(itemAPrefab, UIManager.Instance.TargetCount);
        }

        RandomSpawn();
    }

    void Update()
    {

    }
    public void RandomSpawn()
    {
        if (spawnArea == null || itemAPrefab == null) return;  

        Vector3 spawnCenter = spawnArea.transform.position;
        Vector3 spawnSize = spawnArea.size;

        for (int i = 0; i < UIManager.Instance.TargetCount; i++)
        {
            float randomX = Random.Range(-spawnSize.x, spawnSize.x);
            float randomZ = Random.Range(-spawnSize.z, spawnSize.z);

            Vector3 pos = new Vector3(randomX, randomY, randomZ);

            ItemA itemA = PoolManager.Instance.GetFromPool(itemAPrefab);

            if (itemA != null)
            {
                itemA.transform.SetLocalPositionAndRotation(pos, Quaternion.identity);
            }
        }
    }
    public void ResetSpawn()
    {
        var items = FindObjectsOfType<ItemA>();
        foreach (var item in items)
        {
            PoolManager.Instance.ReturnPool(item);
        }
        RandomSpawn();
    }
}
