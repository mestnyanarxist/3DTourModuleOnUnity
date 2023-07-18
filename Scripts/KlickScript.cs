using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KlickScript : MonoBehaviour
{

    public AudioClip impact;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio.Stop();
        audio.volume = GetVar("SoundVol");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            audio.PlayOneShot(impact, 0.7F);

        audio.volume = GetVar("SoundVol");
    }

    public float GetVar(string Key){
        string key = Key;
        return PlayerPrefs.GetFloat(key);        
    }
}
