using UnityEngine;

public class save_and_load : MonoBehaviour
{
    public static save_and_load instance;
    private void awake()
    {
        if (!instance) {
            Debug.LogWarning("il y a plus d'une instance save_and_load dans la scene");
            return;
        }
        instance = this;
    }

    void Start()
    {
        save_data(0);
    }

    public void save_data(int value)
    {
        if (value >= PlayerPrefs.GetInt("nbr_levels", 0)) {
            PlayerPrefs.SetInt("nbr_levels", value);
        }
    }

    public void reset_data()
    {
        PlayerPrefs.SetInt("nbr_levels", 0);
    }
}
