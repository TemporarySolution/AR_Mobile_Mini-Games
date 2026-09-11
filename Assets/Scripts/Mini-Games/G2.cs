using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2 : MonoBehaviour
{
    public GameObject VinCon;
    public GameObject Game2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<G2DubCards>().Score == 4) { Finish(); }

    }
    public void Finish()
    {
        VinCon.GetComponent<VicCon>().WinG2();
        Destroy(Game2);

    }
}
