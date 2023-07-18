using System.Diagnostics;
using System.Security.AccessControl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using System.EnterpriseServices;
using JetBrains.Annotations;

public class CharacterInteraction : MonoBehaviour
{
    [Header("������� �������� � ��� ������")]
    public Transform MainCharacter;
    public GameObject mainChar;
    public GameObject mainCam;
    public Transform Camera;
    [Header("������")]
    public Transform NPC;
    [Header("�����-�����")]
    public Transform ExitDoor;
    [Header("���� ��� ������� ��. ���������")]
    public Transform mainPC;
    [Header("�������� ����������")]
    public GameObject Point;
    public GameObject Ui;
    public GameObject FirstOpenScreen;
    public TMP_Text taskText1;
    public TMP_Text taskTextOnPC;
    public TMP_Text output;
    public TMP_InputField inputText;
    public TMP_Text currentExpUiTxT;
    public TMP_Text currentTaskUiTxT;
    [Header("������� ��� ����������")]
    public CameraController script1;

    private DataManipulator db;
    private List<string> listPurp;
    private OpenScene sc1 = new OpenScene();   

    bool UiVisible = false;
    int curentUserID = StaticDataHolder._currentId;
    int curentUserExp;
    int iterator = 0;
    private float x, y, z, xRot, yRot, zRot;

    // ���������� ��� ������� �����
    void Start()
    {
        db = new DataManipulator();
        Point.SetActive(UiVisible);
        Ui.SetActive(UiVisible);
        script1.enabled = true;
        inputText.interactable = false;
        currentTaskUiTxT.enabled = false;
        listPurp = new List<string>();
        listPurp = db.ReadStringValuesFromOneTable("Task", "MainPurp");
        Cursor.lockState = CursorLockMode.Locked;
        FirstOpenScreen.SetActive(false);    
    }

    // ���������� ������ ����
    void Update()
    {
        
        db = new DataManipulator();
        
        //���������� �������� ��������� ��. ���������
        x = MainCharacter.transform.position.x;
        y = MainCharacter.transform.position.y;
        z = MainCharacter.transform.position.z;
        xRot = MainCharacter.transform.rotation.x;
        yRot = MainCharacter.transform.rotation.y;
        zRot = MainCharacter.transform.rotation.z;
        
        curentUserExp = db.ReadIntValuesFromOneTable("User", "Exp")[curentUserID-1];            
        currentExpUiTxT.text = "Опыт:"+curentUserExp;

        //Проверка выполненных заданий
        if(curentUserExp == 0)
            iterator = 0;
        else if(curentUserExp > 50 && curentUserExp < 250)
            iterator = 1;
        else if(curentUserExp >= 250)
            iterator = 2;  

        //Проверка на первый запуск
        if(curentUserExp == 0){
            FirstOpenScreen.SetActive(true);
        }            
        else FirstOpenScreen.SetActive(false);

        if (Input.GetKey(KeyCode.Tab))
        {
            currentTaskUiTxT.enabled = true;
        }
        else
        {
            currentTaskUiTxT.enabled = false;
        }

        Interaction();
        TaskCurrentId();
        CloseGame();
        TaskExp();        
    }

    private void Interaction()
    {
        UiVisible = true;

        //�������� ������� � ��������
        if (Vector3.Distance(MainCharacter.transform.position, NPC.transform.position) <= 500)
        {
            if (script1.enabled == false)
                Point.SetActive(false);
            else Point.SetActive(UiVisible);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("�������� ������");

                if(iterator >= 2)
                    taskText1.text = " Задания кончились. Пройдите к выходу.";          
                else taskText1.text = TaskText();

                mainChar.GetComponent<Animator>().enabled = false;
                mainCam.GetComponent<Animator>().enabled = false;
                
                Ui.SetActive(UiVisible);

                //���������� ��������, ����� ����� �� ���������
                foreach (MonoBehaviour mono in this.GetComponents<MonoBehaviour>())
                    mono.enabled = false;
                script1.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                this.enabled = true;
            }             
        }
        //�������� ������ � ��
        else if (Vector3.Distance(MainCharacter.transform.position, mainPC.transform.position) <= 300)
        {          
            Point.SetActive(UiVisible);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("�������� ������ � ��");
                
                mainChar.GetComponent<Animator>().enabled = false;
                mainCam.GetComponent<Animator>().enabled = false;

                //���������� ��������, ����� ����� �� ���������
                foreach (MonoBehaviour mono in this.GetComponents<MonoBehaviour>())
                    mono.enabled = false;
                script1.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                this.enabled = true;
                
                inputText.interactable = true;

                //����������� ������ � �� � ��������� �� ������

                MainCharacter.transform.position = new Vector3(-127, 265, 138);
                MainCharacter.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

                Camera.transform.position = new Vector3(180, 260, 130);
                Camera.transform.rotation = Quaternion.Euler(0f, 90f, 0f);                
            }
        }
        else Point.SetActive(false);
    }

    public void CloseDialog()
    {
        if (UiVisible == true) {

            UiVisible = false;

            Point.SetActive(UiVisible);

            //Debug.Log("�������� ������");
            Ui.SetActive(UiVisible);

            mainChar.GetComponent<Animator>().enabled = true;
            mainCam.GetComponent<Animator>().enabled = true;

            //��������� ��������
            foreach (MonoBehaviour mono in this.GetComponents<MonoBehaviour>())
                mono.enabled = true;
            script1.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            this.enabled = true;
        }
    }

    private void CloseGame()
    {        
        if (Vector3.Distance(MainCharacter.transform.position, ExitDoor.transform.position) <= 200)
        {
            UiVisible = true;

            Point.SetActive(UiVisible);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //�������� ������� ����� �������� ����
                SceneManager.LoadScene(0);
            }
        }
    }

    public void AcceptTask()
    {
        //������� ������� �� ����������

        taskTextOnPC.text = taskText1.text;   
        
        currentTaskUiTxT.text = taskText1.text;

        if( curentUserExp <= 10 && taskText1.text == db.ReadStringValuesFromOneTable("Task", "Description")[0])
            iterator++;
        else if ( curentUserExp == 60 && taskText1.text == db.ReadStringValuesFromOneTable("Task", "Description")[1])
            iterator++;
        else if ( curentUserExp == 260 && taskText1.text == db.ReadStringValuesFromOneTable("Task", "Description")[2])
            iterator++;

        //������� ���� �������
        if (UiVisible == true)
        {
            UiVisible = false;

            Point.SetActive(UiVisible);

            inputText.text = "";
            output.text = " ";

            //Debug.Log("������� ������� � ������");
            Ui.SetActive(UiVisible);

            mainChar.GetComponent<Animator>().enabled = true;
            mainCam.GetComponent<Animator>().enabled = true;

            //��������� ��������
            foreach (MonoBehaviour mono in this.GetComponents<MonoBehaviour>())
                mono.enabled = true;
            script1.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            this.enabled = true;
        }
    }

    private string TaskText()
    {        
        return db.ReadStringValuesFromOneTable("Task", "Description")[TaskCurrentId()];
    }

    public void ClosePc()
    {
        if (UiVisible == true)
        {
            UiVisible = false;

            Point.SetActive(UiVisible);       

            MainCharacter.transform.position = new Vector3(x, y, z);
            MainCharacter.transform.rotation = Quaternion.Euler(xRot, yRot, zRot);

            Camera.transform.position = new Vector3(-130, 460, 200);
            Camera.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

            inputText.interactable = false;

            mainChar.GetComponent<Animator>().enabled = true;
            mainCam.GetComponent<Animator>().enabled = true;

            //��������� ��������
            foreach (MonoBehaviour mono in this.GetComponents<MonoBehaviour>())
                mono.enabled = true;
            script1.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            this.enabled = true;
        }
    }

    public int TaskCurrentId()
    {
        int nextTask = 0;
        string trueAns = " ";
        string taskAns = inputText.text;

        if(taskAns == listPurp[0] && iterator == 1 )
        {   
            trueAns = listPurp[0];            
            taskTextOnPC.text = "Вы ответили верно! Опыт +"+50; 
        }

        if (taskAns == listPurp[1] &&  iterator == 2)
        {
            trueAns = listPurp[1];            
            taskTextOnPC.text = "Вы ответили верно! Опыт +"+200;
        }

        if (taskAns == trueAns)
        {
            output.text = trueAns;               
            currentTaskUiTxT.text = "Вернитесь к тимлиду";
            return nextTask+1;
        }   

        if(iterator == 0 || iterator > 2){
            output.text = " ";               
            currentTaskUiTxT.text = "Возьмите задание у тимлида.";
        }              
        
        return nextTask;
    }

    public void TaskExp()
    {
        string taskAns = inputText.text;
        List<string> listPurp = new List<string>();
        listPurp = db.ReadStringValuesFromOneTable("Task", "MainPurp");            
                
        if(taskAns == listPurp[0] && curentUserExp != 50 && curentUserExp < 50)
        {   
            curentUserExp = curentUserExp + 50;                     
            db.UpdateOneIntValueInOneColByID(curentUserID, curentUserExp, "User", "Exp");
        }

        if (taskAns == listPurp[1] && curentUserExp!= 200 && curentUserExp < 200)
        {
            curentUserExp = curentUserExp + 200;                        
            db.UpdateOneIntValueInOneColByID(curentUserID, curentUserExp, "User", "Exp");
        }
    }
}
