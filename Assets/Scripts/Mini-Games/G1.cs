using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1 : MonoBehaviour
{
    public GameObject VinCon;
    public GameObject Game1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<LotsClickG1>().COMPLETE) { Finish(); }

    }
    public void Finish()
    {
        VinCon.GetComponent<VicCon>().WinG1();
        Destroy(Game1);

    }
}
