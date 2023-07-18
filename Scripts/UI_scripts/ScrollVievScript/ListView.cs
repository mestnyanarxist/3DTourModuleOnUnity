//Необходитымые библиотки для функционирования всех ключевых слов
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ListView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform m_ContentTransform;
    [SerializeField] private RectTransform m_ContentRectTransform;
    

    [Header("Settings")]
    [SerializeField] public List<Button> m_elements;
    [SerializeField] private float m_ofset;

    private int Count = 0; 

    //Ф-ия добавления элемента заготовки в лист(контент)
    public Button Add (Button element)
    {
        //Создание элемента
        Button createdElement = Instantiate(element, this.m_ContentTransform);
        
        //Увеличение переменной кол-ва элементов
        Count = Count + 1;

        //Получение ссылки на лист, который создаем в данный момент 
        RectTransform m_transform = createdElement.GetComponent<RectTransform>();

        //Увеличение контента для реализации прокрутки
        float contentHeight = m_ContentRectTransform.rect.height;
        contentHeight = contentHeight + this.m_ofset+m_transform.rect.height;
        this.m_ContentRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, contentHeight);

        //Добавление созданного элемента в лист
        this.m_elements.Add(createdElement);

        //Получение ссылки на поледний элемент
        Button lastElement = this.m_elements.Last();

        //Получение позиции последнего элемента
        if( Count != 1 )
        {       
            Vector3 lastElementPosition = lastElement.transform.localPosition;

            //Назначение расчитанной позиции новому элементу
            createdElement.transform.localPosition = new Vector3(lastElementPosition.x, lastElementPosition.y - m_transform.rect.height - this.m_ofset, lastElementPosition.z);      
                                    
        }
    
        return createdElement;
    }

    public void Remove(){

        m_elements.Clear();
        
        foreach (Transform item in m_ContentTransform)
        {
            
            Destroy(item.gameObject);
        }

        //Уменьшение контента для реализации прокрутки
        float contentHeight = m_ContentRectTransform.rect.height;
        contentHeight = 60;
        this.m_ContentRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, contentHeight);

    }
}
