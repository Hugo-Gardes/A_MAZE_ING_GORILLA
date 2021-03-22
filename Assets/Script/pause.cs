using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pause_menu;
    private bool is_open_menu = false;
    public void back_to_the_menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void restart_level()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!is_open_menu) {
                pause_menu.SetActive(true);
                is_open_menu = true;
            } else {
                pause_menu.SetActive(false);
                is_open_menu = false;
            }
        }
    }
}
