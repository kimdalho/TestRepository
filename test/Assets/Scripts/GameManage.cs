using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chepter
{
 }

public class GameManage : MonoBehaviour
{
    // Start is called before the first frame update


    public List<GameObject> chepterList = new List<GameObject>();
    

    void Start()
    {
        GameObject obj = GameObject.Find("Chepters");
        for (int  i = 0; i< obj.transform.childCount;i++)
        {
           
           chepterList.Add(obj.transform.GetChild(i).gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
