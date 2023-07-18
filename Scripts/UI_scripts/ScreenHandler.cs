using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenHandler : MonoBehaviour
{
    public GameObject Scr1;
    public GameObject Scr2;
    public GameObject Scr3;

    public ListView list;
    public Text btn;

    // Метод, запускаемый при старте сцены.
    void Start()
    {        
       Scr2.SetActive(false);
       Scr3.SetActive(false);
    }     

    // Метод, запускаемый при каждом новом кадре.
    void Update()
    {
        if(list.m_elements.Count != 0)
        {
            if (list.m_elements.Count == 5)
                btn.text = "MAX";
            else btn.text = "Добавить";
        }
        else btn.text = "Добавить";
    }
    //Метод перехода к экрану 3
    public void OpenScr3(){

        Scr1.SetActive(false);
        Scr3.SetActive(true);
    }

    //Метод перехода к экрану 2
    public void OpenScr2(){

        Scr1.SetActive(false);
        Scr2.SetActive(true);
    }

    //Метод перехода к экрану 1
    public void OpenScr1(){

        Scr1.SetActive(true);
        Scr2.SetActive(false);
    }

    //Метод перехода к добавлению новых юзеров
    public void NewUserScr()
    {
        if (list.m_elements.Count != 5) 
        { 
            Scr1.SetActive(false);
            Scr3.SetActive(true);
        }
    }

    //Метод открытия ссылки на сайт организации
    public void OpenURL(){
        Application.OpenURL("https://tksu.ru/");
    }

    //Метод выхода из приложения
    public void ExitApp(){

        Debug.Log("ExitApp");
        Application.Quit();

    }    
}
