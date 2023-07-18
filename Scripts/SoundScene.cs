using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScene : MonoBehaviour
{
    public AudioSource audio1;

    public AudioSource audio2;

    // Start is called before the first frame update
    void Start()
    {        
        audio1.volume = GetVar("SoundVol");
        audio2.volume = GetVar("SoundVol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetVar(string Key){
        string key = Key;
        return PlayerPrefs.GetFloat(key);        
    }
}
