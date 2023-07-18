using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    private DataManipulator db;
    public ListView list;
    int countUser;

    void Start()
    {
        db = new DataManipulator();
        countUser = db.ReadStringValuesFromOneTable("User", "Name").Count;
    }

    // Update is called once per frame
    void Update()
    {
        countUser = db.ReadStringValuesFromOneTable("User", "Name").Count;

        //�������� ����� �� ������� �� ��� ������������
        if (list.m_elements.Count != 0)
        {
            if (list.m_elements.Count == 1)
                list.m_elements[0].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 1;});
            if (list.m_elements.Count == 2)
            {
                list.m_elements[0].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 1;});
                list.m_elements[1].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 2;});
            }                
            if (list.m_elements.Count == 3)
            {
                list.m_elements[0].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 1;});
                list.m_elements[1].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 2;});
                list.m_elements[2].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 3;});
            }
                
            if (list.m_elements.Count == 4)
            {
                list.m_elements[0].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 1;});
                list.m_elements[1].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 2;});
                list.m_elements[2].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 3;});
                list.m_elements[3].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 4;});
            }
               
            if (list.m_elements.Count == 5)
            {
                list.m_elements[0].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 1;});
                list.m_elements[1].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 2;});
                list.m_elements[2].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 3;});
                list.m_elements[3].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 4;});
                list.m_elements[4].onClick.AddListener(delegate { SceneLoad();  StaticDataHolder._currentId = 5;});
            }                
        }  
    }

    //����� �������� ������� �����
    public void SceneLoad()
    {
        SceneManager.LoadScene(1);
    }   
}
