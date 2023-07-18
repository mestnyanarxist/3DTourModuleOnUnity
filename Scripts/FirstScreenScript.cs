using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.EnterpriseServices;
using JetBrains.Annotations;

public class FirstScreenScript : MonoBehaviour
{
    [Header ("Элементы интерфейса")]
    public GameObject FirstScr;
    public GameObject guideImg;
    public GameObject orgDescript;
    public GameObject mainChar;
    public GameObject mainCam;
    public TMP_Text orgDescriptTxt;
    
    public CameraController script1;

    private DataManipulator db;

    // Start is called before the first frame update
    void Start()
    {
        db = new DataManipulator();
        orgDescript.SetActive(false);           
        Cursor.lockState = CursorLockMode.Confined;

        script1.enabled = false;

        mainChar.GetComponent<Animator>().enabled = false;
        mainCam.GetComponent<Animator>().enabled = false;
        
        string orgName = db.ReadStringValuesFromOneTable("Organization", "Name")[0];
        string Address = db.ReadStringValuesFromOneTable("Organization", "Address")[1];
        string Activity = db.ReadStringValuesFromOneTable("Organization", "Activity")[2];
        string year = Convert.ToString(db.ReadIntValuesFromOneTable("Organization", "YearOfCreation")[0]);
        string phone = Convert.ToString(db.ReadIntValuesFromOneTable("Organization", "Phone")[1]);

        orgDescriptTxt.text = "Название организации: " +orgName+ "\n" + "Адрес: " +Address+ "\n" + "Деятельность: " +Activity+ "\n" + "Год основания: " +year+ "\n" + "Телефон отдела кадров: " +phone+ "\n";                                                
    }

    public void NextScreen(){
        guideImg.SetActive(false);
        orgDescript.SetActive(true);
    }

    public void CloseFirstOpenScr(){
        Cursor.lockState = CursorLockMode.Locked;

        script1.enabled = true;

        mainChar.GetComponent<Animator>().enabled = true;
        mainCam.GetComponent<Animator>().enabled = true;

        db.UpdateOneIntValueInOneColByID(StaticDataHolder._currentId, 10, "User", "Exp");

        FirstScr.SetActive(false);
    }
}
