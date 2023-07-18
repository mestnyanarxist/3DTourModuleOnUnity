using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float mouseX;
    private float mouseY;

    [Header("���������������� ����")]
    float sensivityMouse;

    public Transform Player;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        sensivityMouse = GetVar("MouseSens");
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnim();

        mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime ;
        mouseY = Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        Player.Rotate(mouseX * new Vector3(0, 1, 0));

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }

    private void PlayAnim()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponentInParent<Animator>().SetBool("State", false);
            GetComponentInParent<Animator>().SetBool("Go", true);           
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponentInParent<Animator>().SetBool("State", false);
            GetComponentInParent<Animator>().SetBool("Go", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponentInParent<Animator>().SetBool("State", false);
            GetComponentInParent<Animator>().SetBool("Go", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponentInParent<Animator>().SetBool("State", false);
            GetComponentInParent<Animator>().SetBool("Go", true);
        }
        else
        {
            GetComponentInParent<Animator>().SetBool("State", true);
            GetComponentInParent<Animator>().SetBool("Go", false);
        }
    }

    public float GetVar(string Key){
        string key = Key;
        return PlayerPrefs.GetFloat(key);        
    }
}
