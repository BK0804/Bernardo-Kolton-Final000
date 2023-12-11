using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaScript : MonoBehaviour
{
    public GameObject ObjectMenu;
    public bool Pause = false;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (Pause == false)
            {
                ObjectMenu.SetActive(true);
                Pause = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Pause == true)
            {
                Resume();

            }
    }
    public void Resume()
    {
        ObjectMenu.SetActive(false);
        Pause = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }
    public void GoToMenu(string Menu)
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(Menu);
    }
}
