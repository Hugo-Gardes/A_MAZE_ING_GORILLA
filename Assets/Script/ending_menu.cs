using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending_menu : MonoBehaviour
{
    public GameObject menu;
    public int level_to_save = 0;
    public string next_level;
    public void retry()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void next()
    {
        SceneManager.LoadScene(next_level);
    }
    public void load_menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void show_menu()
    {
        menu.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "goal") {
            save_and_load save = new save_and_load();
            show_menu();
            save.save_data(level_to_save);
        }
    }
}
