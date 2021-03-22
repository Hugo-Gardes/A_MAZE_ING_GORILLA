using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class button : MonoBehaviour
{
    public Button[] button_selector;
    public GameObject settings;
    public GameObject help_settings;
    public GameObject levels;
    public GameObject warning;
    public GameObject[] easteregg;
    public Sprite if_trigger;
    public Dropdown dropdown;
    public string[] Level_selector;
    public Toggle fullscreen;
    Resolution[] resolution;
    private int nbr_levels;
    private bool is_help = false;
    private bool esateregg_is_on = false;

    public void button_select_level(int level_index)
    {
        if (level_index > PlayerPrefs.GetInt("nbr_levels", 0)) {
            return;
        }
        SceneManager.LoadScene(Level_selector[level_index]);
    }

    public void button_show_selector()
    {
        levels.SetActive(true);
    }

    public void button_quit()
    {
        Application.Quit(0);
    }

    public void button_settings()
    {
        settings.SetActive(true);
    }

    public void help()
    {
        if (is_help) {
            set_off_help();
        } else {
            set_active_help();
        }
    }

    public void set_active_help()
    {
        help_settings.SetActive(true);
        is_help = true;
    }
    public void set_off_help()
    {
        is_help = false;
        help_settings.SetActive(false);
    }

    public void checkfulscreen(bool state)
    {
        Screen.fullScreen = state;
    }

    public void triger_button(int button_)
    {
        button_selector[button_].GetComponent<Image>().sprite = if_trigger;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void Back()
    {
        settings.SetActive(false);
        levels.SetActive(false);
    }

    public void easter_egg()
    {
        if (!esateregg_is_on) {
            easteregg[1].SetActive(true);
            easteregg[0].SetActive(true);
            esateregg_is_on = true;
        } else {
            easteregg[1].SetActive(false);
            easteregg[0].SetActive(false);
            esateregg_is_on = false;
        }
    }

    public void Start()
    {
        nbr_levels = PlayerPrefs.GetInt("nbr_levels", 0);
        if (!Screen.fullScreen)
            fullscreen.isOn = false;
        resolution = Screen.resolutions.Select(resolution => new Resolution {width = resolution.width, height = resolution.height}).Distinct().ToArray();
        dropdown.ClearOptions();
        List<string> list = new List<string>();
        int current_resolution_index = 0;
        for (int u = 0; u < resolution.Length; u++) {
            string option = resolution[u].width + " x " + resolution[u].height;
            list.Add(option);
            if (resolution[u].width == Screen.width && resolution[u].height == Screen.height) {

                current_resolution_index = u;
            }
        }
        dropdown.AddOptions(list);
        dropdown.value = current_resolution_index;
        dropdown.RefreshShownValue();
    }

    public void show_warning(bool u)
    {
        if (u) {
            warning.SetActive(true);
        } else {
            warning.SetActive(false);
        }
    }

    public void set_resolution(int resolution_index)
    {
        Resolution resolution_ = resolution[resolution_index];
        Screen.SetResolution(resolution_.width, resolution_.height, Screen.fullScreen);
    }

}
