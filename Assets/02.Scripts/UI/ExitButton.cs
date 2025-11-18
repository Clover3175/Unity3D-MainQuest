using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnClick()
    {
        Application.Quit();
    }
}
