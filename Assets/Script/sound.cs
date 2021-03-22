using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class sound : MonoBehaviour
{
    public slider slide;
    public Button button;

    public Sprite[] new_sprite;

    public float value_; 

    private bool is_mute = false;
    public Slider slider;

    public void mute()
    {
        
        if (is_mute)
        {
            slider.value = value_;
            is_mute = false;
        } else {
            is_mute = true;
            slider.value = -80;
        }
    }
    public void sound_manager(float value)
    {
        if (is_mute != true)
            value_ = value;
        if (value == -40)
        {
            button.GetComponent<Image>().sprite = new_sprite[0];
        }
        if (value <= -30 && value > -40)
        {
            button.GetComponent<Image>().sprite = new_sprite[1];
        }
        if (value <= -15 && value > -30)
        {
            button.GetComponent<Image>().sprite = new_sprite[2];
        }
        if (value > -15)
        {
            button.GetComponent<Image>().sprite = new_sprite[3];
        }
    }

    void Start()
    {
        sound_manager(slide.get_volume());
    }
}
