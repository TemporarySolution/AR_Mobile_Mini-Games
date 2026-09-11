using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TimerFill : MonoBehaviour
{
    public float Max = 1;
    public float CurTime = 1;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        CurTime -= Time.deltaTime;
        gameObject.transform.Find("Canvas(Timer)/Timer/Fill").GetComponent<UnityEngine.UI.Image>().fillAmount = CurTime / Max;
        if (CurTime < 0) CurTime = 0;
    }
    public void RestartTimer(float time , float max)
    {
        CurTime = time;
        Max = max;
    }
}
