using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LotsClickG1 : MonoBehaviour
{
    public GameObject button;
    public GameObject text;
    public float VIC_SCORE = 255;
    public float CUR_SCORE = 0;
    public float FADE_SPEED = 0.1F;
    public int TAP_SCORE = 35;
    public bool COMPLETE = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Decrease score to fade speed
        if ((CUR_SCORE < VIC_SCORE) && (CUR_SCORE > 0))  { CUR_SCORE = CUR_SCORE - FADE_SPEED; }
        else if  (CUR_SCORE >= VIC_SCORE) { CUR_SCORE = VIC_SCORE; FADE_SPEED = 0; TAP_SCORE = 0; COMPLETE = true; }

        // Change button colour from red to grean.
        button.GetComponent<Image>().color = new Color(255 - CUR_SCORE , CUR_SCORE , 0);
        button.transform.localScale = new Vector3((0.1f + ((CUR_SCORE / VIC_SCORE) / 10)), (0.1f + ((CUR_SCORE / VIC_SCORE) / 10)), (0.1f + ((CUR_SCORE / VIC_SCORE) / 10)));
        text.GetComponent<Text>().text = ((CUR_SCORE/VIC_SCORE)*100).ToString("F") + "%";


    }
    public void TestCom()
    {
        CUR_SCORE = CUR_SCORE + TAP_SCORE;
        // Change button colour from red to grean.
    }
}
