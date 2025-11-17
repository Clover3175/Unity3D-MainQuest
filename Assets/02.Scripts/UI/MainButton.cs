using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.Instance.ClearUiOff();
        SceneManager.LoadScene("MainMenu");
    }
}
