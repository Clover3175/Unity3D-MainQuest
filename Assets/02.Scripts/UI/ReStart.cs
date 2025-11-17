using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public void OnClick()
    {
        FindObjectOfType<ItemSpawn>().ResetSpawn();
        UIManager.Instance.ClearUiOff();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

