using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPostFromBD : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ListView m_ListView;
    [SerializeField] private GameObject m_Prefab;

    private string m_Title;    
    private int m_Count;
    private DataManipulator m_Db;
    private List<string> db_Out;

    //Функция изменения текста у элементов типа "m_title"
    public void SetTitle(string title, Button btn) => btn.GetComponentInChildren<Text>().text = title;

    private void Start() {

        //Создание экземпляра класса DataManipulator БД SQLite
        m_Db = new DataManipulator();

        //Получение из БД списка имен юзеров
        db_Out = m_Db.ReadStringValuesFromOneTable("Posts", "Name");

        //ПОлучение кол-ва имен
        m_Count = db_Out.Count;

        //Создание кнопок с именами пользователей
        for(int i = 0; i < this.m_Count; i++) 
        {
            Button element = this.m_ListView.Add(this.m_Prefab.GetComponent<Button>());
            
            m_Title = db_Out[i];

            SetTitle(this.m_Title, element);
        }
    }  
}
