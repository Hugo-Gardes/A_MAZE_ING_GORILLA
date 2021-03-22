using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_unlocker : MonoBehaviour
{
    public Button[] buttons;
    private int nbr_levels;
    public void level_unlock()
    {
        nbr_levels = PlayerPrefs.GetInt("nbr_levels", 0);
        for (int u = 1; u < buttons.Length; u++) {
            if (u <= nbr_levels) {
                buttons[u].GetComponentInChildren<Text>().text = "Niveau " + u;
            } else {
                buttons[u].GetComponentInChildren<Text>().text = "???";
            }
        }
    }
}
