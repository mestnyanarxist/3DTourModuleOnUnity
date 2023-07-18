using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetingsScript : MonoBehaviour
{
    [Header ("Элементы интерфейса")]
    public Slider sliderMouse;
    public Slider sliderSound;

    float mouseSens = 200;
    float soundVol = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        if(GetVar("MouseSens") != 0)
            sliderMouse.value = GetVar("MouseSens");
        else {
            SaveVar(mouseSens, "MouseSens");
            sliderMouse.value = GetVar("MouseSens");
        }

        if(GetVar("SoundVol") != 0)
            sliderSound.value = GetVar("SoundVol");
        else {
            SaveVar(soundVol, "SoundVol");
            sliderSound.value = GetVar("SoundVol");
        }
    }

    // Update is called once per frame
    void Update()
    {
        SaveVar(sliderMouse.value, "MouseSens");
        SaveVar(sliderSound.value, "SoundVol");
    }

    public void SaveVar( float Var, string Key){
        string key = Key;
        PlayerPrefs.SetFloat(key, Var);
        PlayerPrefs.Save();
    }

    public float GetVar(string Key){
        string key = Key;
        return PlayerPrefs.GetFloat(key);        
    }
}
