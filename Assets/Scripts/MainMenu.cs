using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void PlayGame() 
     * 
     * When the button is clicked starts the 'Main' Game. Not the tutorial level
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void QuitGame() 
     * 
     * When the button is clicked quits the game.
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    public void QuitGame()
    {
        Application.Quit();
    }
}
