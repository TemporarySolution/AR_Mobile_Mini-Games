using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class VicCon : MonoBehaviour
{
    public GameObject UITEXT;
    public int County = 0;
    public bool G1 = false;
    public bool G2 = false;
    public bool G3 = false;
    public bool G4 = false;
    public bool G5 = false;
    public GameObject Prise1 = null;
    public GameObject Prise2 = null;
    public GameObject Prise3 = null;
    public GameObject Prise4 = null;
    public GameObject Prise5 = null;
    public GameObject VicScr = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WinG1() { G1 = true; County++; Upd(); Prise1.SetActive(true); }
    public void WinG2() { G2 = true; County++; Upd(); Prise2.SetActive(true); }
    public void WinG3() { G3 = true; County++; Upd(); Prise3.SetActive(true); }
    public void WinG4() { G4 = true; County++; Upd(); Prise4.SetActive(true); }
    public void WinG5() { G5 = true; County++; Upd(); Prise5.SetActive(true); }
    public void Upd() { UITEXT.GetComponent<UnityEngine.UI.Text>().text = ("Выполнено: " + County + "/5"); if (County == 5) { VicScr.SetActive(true); }  }
}
