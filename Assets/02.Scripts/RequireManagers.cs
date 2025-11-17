using UnityEngine;
using UnityEngine.SceneManagement;

public class RequireManagers : MonoBehaviour
{
    private void Awake()
    {
        if (UIManager.Instance == null || PoolManager.Instance == null || GameManager.Instance == null)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
