using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadLabel : MonoBehaviour
{
    bool b_OnClicked;
    bool b_OnClicked2;
    Text compoText;
    Image StoryImg;
    Image HidePanel;
    string strText;
    int alphaColor;
    private void Start()
    {
        b_OnClicked = false;
       for (int i =0; i < gameObject.transform.childCount; i++)
        {
            string componame = gameObject.transform.GetChild(i).name;

            switch(componame)
            {
                case "StoryText":
                    compoText = gameObject.transform.GetChild(i).GetComponent<Text>();
                    break;
                case "StoryImg":
                    StoryImg = gameObject.transform.GetChild(i).GetComponent<Image>();
                    break;
                case "HidePanel":
                    HidePanel = gameObject.transform.GetChild(i).GetComponent<Image>();
                    break;
            }
        }

        Initalize();
    }
    private void Initalize()
    {
        //HidePanel.color = new Color(255, 255, 255, 255);

        StoryImg.color = new Color(0, 0, 0, 0);

        strText = compoText.text;

        compoText.text = "";
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && b_OnClicked == false)
        {
            StartCoroutine(SmoothLabel(strText));
            b_OnClicked = true;
        }


        else if (Input.GetMouseButtonDown(0) && b_OnClicked == true && b_OnClicked2 == false)
        {
            print("?");
         
            StartCoroutine(SmoothShowImg(StoryImg));  
            b_OnClicked2 = true;
        }
    }


    public IEnumerator SmoothLabel(string str)
    {
        char[] chrstr = new char[str.Length];
        chrstr = str.ToCharArray();
        int cnt = 0;
        while(cnt < chrstr.Length)
        {

            //print("chrstr[cnt] = " + cnt + "chrstr.L = " + chrstr.Length);
            compoText.text += chrstr[cnt];
            cnt++;

          yield return new WaitForSeconds(0.01f);

        }

       
    }

    public IEnumerator SmoothShowImg(Image img)
    {
        float alphaColor = 0;

        while(alphaColor < 255)
        {
            alphaColor += Time.deltaTime;
            img.color += new Color(alphaColor, alphaColor, alphaColor, alphaColor);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        print("EXIT");
    }

    public IEnumerator SmoothShowImg(Image img,int num)
    {
        int alphaColor = 255;

        while (alphaColor > 0)
        {
            alphaColor--;
            img.color = new Color(255, 255, 255, alphaColor);

            yield return new WaitForSeconds(1);
        }

        print("EXIT");
    }
}
