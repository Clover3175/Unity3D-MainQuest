using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [Header("savepoint setting")]
    [SerializeField] private string checkPointId = "CP_Player"; //세이브 포인트의 ID
    [SerializeField] private Transform spawnPoint; //플레이어가 리스폰 할 위치

    public string LastCheckPointId { get; private set; }

    public string CheckPointId
    {
        get { return checkPointId; }
        set { checkPointId = value; }
    }
    public Transform SpawnPoint
    {
        get { return spawnPoint; }
    }
    //플레이어가 세이브 포인트에 도달했을 때
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SaveCheckPoint(CheckPointId);

            }
        }
    }
}
