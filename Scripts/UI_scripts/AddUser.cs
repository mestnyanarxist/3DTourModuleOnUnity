using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddUser : MonoBehaviour
{

    private DataManipulator db;    
    private string value;
    private int id;
    private string name;
    private int post;
    private int exp;
    public GameObject scr1;
    public GameObject scr2;
    public InputField inputTxt;
    public ListView list;

    // Start is called before the first frame update
    void Start()
    {
        db = new DataManipulator();
        list.m_elements[0].onClick.AddListener(delegate {post = 1; AddUsers();
        GoToStartScr();});
        list.m_elements[1].onClick.AddListener(delegate {post = 2; AddUsers();
        GoToStartScr();});
        list.m_elements[2].onClick.AddListener(delegate {post = 3; AddUsers();
        GoToStartScr();});        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParceText()
    {
        name = inputTxt.text;
    }

    public void WhichIDLast(List<string> DbReturn){
        
        if(DbReturn.Count == 0)
            id = 1;
        else {
            id = DbReturn.Count + 1;
            DbReturn.Clear();
        }            
    }

    public void AddUsers(){
        
        name = inputTxt.text;

        WhichIDLast(db.ReadStringValuesFromOneTable("User", "Name"));

        Debug.Log(System.Convert.ToString(id));

        db.WriteUser(id, name, post, 0);

        inputTxt.text = null;
    }

    public void GoToStartScr(){

        scr1.SetActive(false);
        scr2.SetActive(true);
    }

}
