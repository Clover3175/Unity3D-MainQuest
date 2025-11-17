using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("player")]
    [SerializeField] private Transform player;

    [Header("checkPoint")]
    [SerializeField] private SavePoint[] checkPoint;

    [Header("Player Info")]
    [SerializeField] private string defualtPlayerName = "Kim";

    //public int Score { get; private set; }
    public string LastCheckPointId { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (SaveSystem.TryLoad(out var loaded))
        {
            UIManager.Instance.TargetCount = loaded.score;
            LastCheckPointId = loaded.lastCheckPointId;

            UIManager.Instance.CountUI();
            TelePortCheckPoint();
        }
        else 
        {
            UIManager.Instance.TargetCount = UIManager.Instance.TargetCount;
            LastCheckPointId = null;
            UIManager.Instance.CountUI();
        }
    }
    //세이브 포인트에 도착했을때 호줄되는 메서드 -> 현재 플레이어의 정보
    public void SaveCheckPoint(string checkPointId)
    {
        LastCheckPointId = checkPointId;

        var data = new GameData
        {
            playerName = defualtPlayerName,
            score = UIManager.Instance.TargetCount,
            lastCheckPointId = LastCheckPointId,
        };
        SaveSystem.Save(data);
    }
    //체크포인트 ID에 해당하는 지점을 찾아서 플레이어를 이동
    private void TelePortCheckPoint()
    {
        if (string.IsNullOrEmpty(LastCheckPointId)) return;
        if (checkPoint == null || checkPoint.Length == 0) return;

        for (int i = 0; i < checkPoint.Length; i++)
        {
            var cp = checkPoint[i];
            if (cp == null) continue;
            if (cp.CheckPointId !=  LastCheckPointId) continue;

            if (cp.CheckPointId != null)
            {
                player.position = cp.SpawnPoint.position;
            }
            else
            {
                player.position = cp.transform.position;
            }
        }
    }
}
