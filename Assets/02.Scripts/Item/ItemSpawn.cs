using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawn : MonoBehaviour
{
    [Header("프리팹")]
    public ItemA itemAPrefab;

    [Header("위치 좌표")]
    [SerializeField] Renderer spawnArea;  //겉모습
    [SerializeField] private float randomY = 0.5f;

    public Vector3 randomPos;

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

        //Vector3 spawnCenter = spawnArea.transform.position;
        Bounds spawnSize = spawnArea.bounds; //겉모습에서 나타내는 실제크기를 가져온다(bounds)

        for (int i = 0; i < UIManager.Instance.TargetCount; i++)
        {
            float randomX = Random.Range(spawnSize.min.x, spawnSize.max.x);
            float randomZ = Random.Range(spawnSize.min.z, spawnSize.max.z);

            randomPos = new Vector3(randomX, randomY, randomZ);

            ItemA itemA = PoolManager.Instance.GetFromPool(itemAPrefab);

            if (itemA != null)
            {
                itemA.transform.SetLocalPositionAndRotation(randomPos, Quaternion.identity);
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
