using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
    public void Start()
    {
        Cursor.visible = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToURL()
    {
        Application.OpenURL("https://goo.gl/forms/lPtEOXfixGQCTS2E2");
    }
}
