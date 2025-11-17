using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnClick()
    {
        #if UNITY_EDITOR
           EditorApplication.ExitPlaymode();
        #else
           Application.Quit();
        #endif
    }
}
