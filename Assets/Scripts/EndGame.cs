using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Start() is run at the beginnning of the scene
     * 
     * Unlocks the cursor from the centre of the screen to be limited by the confines of the window and also makes the cursor visable
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void MainMenu() 
     * 
     * When the button is clicked returns the player to the MainMenu scene
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
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
