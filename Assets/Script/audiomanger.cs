using UnityEngine;

public class audiomanger : MonoBehaviour
{
    public static audiomanger instance;
    private void awake()
    {
        if (!instance) {
            Debug.LogWarning("il y a plus d'une instance save_and_load dans la scene");
            return;
        }
        instance = this;
    }

    public AudioClip[] playlist;
    public AudioSource audioSource;
    public bool is_lunch = false;
    public AudioSource[] audioSource_list;

    void Start()
    {
        if (is_lunch) {
            audioSource.clip = playlist[0];
            audioSource.Play();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            audioSource.clip = playlist[0];
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        }
    }

    public void gorilla_step()
    {
        if (!audioSource_list[0].isPlaying) {
            audioSource_list[0].clip = playlist[0];
            audioSource_list[0].Play();
        }
    }

    public void gorilla_breath()
    {
        if (!audioSource_list[1].isPlaying) {
            audioSource_list[1].clip = playlist[1];
            audioSource_list[1].Play();
        }
    }

    public void portal_start()
    {
        if (!audioSource_list[2].isPlaying) {
            audioSource_list[2].clip = playlist[2];
            audioSource_list[2].Play();
        }
    }

    public void set_time_music(int time)
    {
        switch (time) {
            case 0:
                audioSource.clip = playlist[3];
                audioSource.Play();
                break;
            case 1:
                audioSource.clip = playlist[4];
                audioSource.Play();
                break;
            case 2:
                audioSource.clip = playlist[5];
                audioSource.Play();
                break;
        }
    }
}
