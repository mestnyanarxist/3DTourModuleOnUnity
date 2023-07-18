using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Создаем экземпляр класса DataManipulator
        DataManipulator DB = new DataManipulator();
        
        DB.DeleteAllInTable("Player");
        Debug.Log(DB.ReadStringValuesFromOneTable("Player","nickname")[0]);
        //DB.WriteOneValueInOneCol(1, "John","Player");
        Debug.Log(DB.ReadStringValuesFromOneTable("Player","nickname")[0]);
        /*
        Debug.Log(DB.ReadValuesFromOneTable("Player","nickname")[0]);
        Debug.Log(DB.ReadValuesFromOneTable("Player","nickname")[1]);
        Debug.Log(DB.ReadValuesFromOneTable("Player","nickname")[2]);
        DB.UpdateOneValueInOneColByID(2, "Artur", "Player","nickname");
        DB.UpdateOneValueInOneColByID(3, "Lion", "Player","nickname");
        Debug.Log(DB.ReadValuesFromOneTable("Player","nickname")[0]);
        Debug.Log(DB.ReadValuesFromOneTable("Player","nickname")[1]);
        Debug.Log(DB.ReadValuesFromOneTable("Player","nickname")[2]);
        */
        //Вывод из листа через поиск методом IndexOf("наименование переменной")
        //Debug.Log(DB.ReturnFromSearch("Nick","Player","nickname"));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
