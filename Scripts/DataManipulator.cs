using System.Data.Common;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// Подключаем необходимые пространства имен
using System.Data;
using Mono.Data.Sqlite;

//Класс манипулирования базой данных
public class DataManipulator
{
 
    // Путь к базе данных
    private string connectionString = "URI=file:" + Application.dataPath + "/StreamingAssets/DataBaseOfModule";

    //Лист для внесени в него всех значений из БД
    List <string> RValue = new List<string>();
    List <int> IntValue = new List<int>();

    //ЧТЕНИЕ ИЗ БАЗЫ ДАННЫХ

    // Чтение Базы данных. Возвращает лист элементов из заданного столбца
    public List<string> ReadStringValuesFromOneTable(string NameTable, string NameCol)
    {
        //Соединение с БД
        using (var dbcon = new SqliteConnection(connectionString))
            {
                dbcon.Open();
                using(var dbcmd = dbcon.CreateCommand())
                {
                    //Создание команды для отправки в БД
                    dbcmd.CommandText = "SELECT "+NameCol+" FROM "+NameTable;

                    // Выполняем запрос на чтение
                    IDataReader reader = dbcmd.ExecuteReader();

                        // Читаем и выводим результат в лист
                        while (reader.Read())
                            {   
                                if(reader.GetString(0) != null)
                                    RValue.Add(reader.GetString(0));                              
                            }
                }

                // Закрываем соединение
                dbcon.Close();        
            }

        return RValue;
    }

    public List<int> ReadIntValuesFromOneTable(string NameTable, string NameCol)
    {
        //Соединение с БД
        using (var dbcon = new SqliteConnection(connectionString))
        {
            dbcon.Open();
            using (var dbcmd = dbcon.CreateCommand())
            {
                //Создание команды для отправки в БД
                dbcmd.CommandText = "SELECT " + NameCol + " FROM " + NameTable;

                // Выполняем запрос на чтение
                IDataReader reader = dbcmd.ExecuteReader();

                // Читаем и выводим результат в лист
                while (reader.Read())
                {
                    IntValue.Add(reader.GetInt32(0));
                }
            }

            // Закрываем соединение
            dbcon.Close();
        }

        return IntValue;
    }

    //Вывод значения через поиск($!Возможно будет не нужен!$)
    public string ReturnFromSearch(string Value, string NameTable, string NameCol)
    {
        //Вывод из листа через поиск методом IndexOf("наименование переменной")
        string RValue =
        ReadStringValuesFromOneTable(NameTable, NameCol)[ReadStringValuesFromOneTable(NameTable, NameCol).
        IndexOf(Value)];

        return RValue;
    }

    //ЗАПИСЬ В БАЗУ ДАННЫХ

    //Запись нового значения
    public void WriteUser(int id, string name, int post, int exp)
    {

       using (var dbcon = new SqliteConnection(connectionString))
            {
                //Очистка начального значения списка
                //RValue.Clear();

                dbcon.Open();
                using(var dbcmd = dbcon.CreateCommand())
                {
                    //Создание команды для отправки в БД
                    dbcmd.CommandText = "INSERT INTO User VALUES ('"+id+"','"+name+"','"+post+"','"+exp+"')";

                    //Исполнение команды
                    dbcmd.ExecuteNonQuery();

                }
                
                // Закрываем соединение
                dbcon.Close();        
            }
    }

    //Редактирование существующего значения
    public void UpdateOneValueInOneColByID(int ID, string Value, string NameTable, string NameCol)
    {

       using (var dbcon = new SqliteConnection(connectionString))
            {
                dbcon.Open();
                using(var dbcmd = dbcon.CreateCommand())
                {
                    //Создание команды для отправки в БД
                    dbcmd.CommandText = "UPDATE "+NameTable+" SET "+NameCol+" = '"+Value+"' WHERE ID ="+ID;

                    //Исполнение команды
                    dbcmd.ExecuteNonQuery();
                }
                
                // Закрываем соединение
                dbcon.Close();        
            }
    }

    public void UpdateOneIntValueInOneColByID(int ID, int Value, string NameTable, string NameCol)
    {

        using (var dbcon = new SqliteConnection(connectionString))
        {
            dbcon.Open();
            using (var dbcmd = dbcon.CreateCommand())
            {
                //Создание команды для отправки в БД
                dbcmd.CommandText = "UPDATE " + NameTable + " SET " + NameCol + " = " + Value + " WHERE ID =" + ID;

                //Исполнение команды
                dbcmd.ExecuteNonQuery();
            }
            // Закрываем соединение
            dbcon.Close();
        }
    }

    //ОЧИСТКА ТАБЛИЦ

    public void DeleteAllInTable(string NameTable)
    {

       using (var dbcon = new SqliteConnection(connectionString))
            {
                dbcon.Open();
                using(var dbcmd = dbcon.CreateCommand())
                {
                    //Создание команды для отправки в БД
                    dbcmd.CommandText = "DELETE FROM "+NameTable;

                    //Исполнение команды
                    dbcmd.ExecuteNonQuery();
                } 
                
                // Закрываем соединение
                dbcon.Close();       
            }


        //Начальное значение для вывода в лист
        RValue.Add("Nothing");
    }
    
}

