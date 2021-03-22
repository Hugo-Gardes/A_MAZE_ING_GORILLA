using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    public Slider slide;
    public AudioMixer audioMixer;
    public void setvolume(float volume) {
        if (volume == -40)
            volume = -80;
        audioMixer.SetFloat("master", volume);
    }

    public float get_volume()
    {
        float initi = 0.0F;
        audioMixer.GetFloat("master", out initi);
        return (initi);
    }

    void Start()
    {
        slide.value = get_volume();
    }
}
