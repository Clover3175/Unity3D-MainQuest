using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveStart : MonoBehaviour
{
    public void OnClick()
    {
        FindObjectOfType<ItemSpawn>().ResetSpawn();
        UIManager.Instance.ClearUiOff();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
