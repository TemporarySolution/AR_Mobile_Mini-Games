using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int HP = 40;
    public GameObject MeSelf = null;
    public GameObject HPUI = null;
    // Start is called before the first frame update
    void Start()
    {
        MeSelf = gameObject;
        print("HP = " + HP);
    }

    // Update is called once per frame
    void Update()
    {
        if (HPUI != null) { HPUI.GetComponent<UnityEngine.UI.Text>().text = ("" + HP); }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (HP <= 0) { Destroy(MeSelf); } 
        print("HP = " + HP);
    }
}
