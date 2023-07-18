using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

//Скрипт, реализующий управление главным персонажем

public class PlayerControl : MonoBehaviour
{
    [Header("Скорость персонажа")] 
    public float movementSpeed = 1;
    [Header("Персонаж для управления")]
    Rigidbody rb;

    public AudioSource audio;
    public AudioClip impact;

    int k;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio.Stop();
        audio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnim();
        GetInput();        
    }

    private void GetInput(){  
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * movementSpeed * Time.deltaTime;
        }
    }

    private void PlayAnim()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponentInParent<Animator>().SetBool("Stand", false);
            GetComponentInParent<Animator>().SetBool("Go", true);           
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponentInParent<Animator>().SetBool("Stand", false);
            GetComponentInParent<Animator>().SetBool("Go", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponentInParent<Animator>().SetBool("Stand", false);
            GetComponentInParent<Animator>().SetBool("Go", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponentInParent<Animator>().SetBool("Stand", false);
            GetComponentInParent<Animator>().SetBool("Go", true);
        }
        else
        {
            GetComponentInParent<Animator>().SetBool("Stand", true);
            GetComponentInParent<Animator>().SetBool("Go", false);
        }
    }
}
