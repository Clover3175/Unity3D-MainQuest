using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [Header("savepoint setting")]
    [SerializeField] private string checkPointId = "CP_Player"; //세이브 포인트의 ID
    [SerializeField] private Transform spawnPoint; //플레이어가 리스폰 할 위치

    public string CheckPointId
    { 
        get { return checkPointId; }
    }
    public Transform SpawnPoint
    {
        get { return spawnPoint; }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
