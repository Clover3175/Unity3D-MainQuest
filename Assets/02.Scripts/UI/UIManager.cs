using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private int targetCount;     //목표 개수
    [SerializeField] private int currentlyCount;  //남은 목표 개수
    [SerializeField] private TextMeshProUGUI targetCountText;  //목표 개수 텍스트
    [SerializeField] private GameObject howUI;        //플레이 방법 UI
    [SerializeField] private GameObject GameClearUI;  //게임 클리어 UI

    public int TargetCount
    {
        get { return targetCount; }
        set { targetCount = value; }
    }

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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject countObj = GameObject.Find("CountText");

        if (targetCountText == null && countObj != null)
        {
            targetCountText = GameObject.Find("CountText").GetComponent<TextMeshProUGUI>();
        }

        CountUI();

        if (GameClearUI == null)
        {
            GameClearUI = GameObject.Find("GameClearUI");

            if (GameClearUI != null)
            {

                GameClearUI.SetActive(false);
            }
        }
    }
    private void Update()
    {
        ClearUiOn();
    }
    public void TakeCount()
    {
        if (currentlyCount > 0)
        {
            currentlyCount -= 1;
        }
        else
        {
            currentlyCount = 0;
        }

        CountUI();
    }

    public void CountUI()
    {
        if (targetCountText == null) return;
       
        targetCountText.text = $"남은 개수 : {currentlyCount}";

    }
    public void HowUI()
    {
        if (howUI.activeSelf == true)
        {
            howUI.SetActive(false);
        }
        else
        {
            howUI.SetActive(true);
        }

    }
    public void ClearUiOn()
    {
        if (GameClearUI == null) return;

        if (currentlyCount <= 0)
        {
            GameClearUI.SetActive(true);
            currentlyCount = targetCount;
        }
    }
    public void ClearUiOff()
    { 
        if (GameClearUI == null) return;

        GameClearUI.SetActive(false);
    }
}
