using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G3 : MonoBehaviour
{
    public GameObject VinCon;
    public GameObject Game3;
    public int ScoreWin = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreWin <= gameObject.GetComponent<Game>().count) { Finish(); }

    }
    public void Finish()
    {
        gameObject.GetComponent<Game>().StartEnder();
        VinCon.GetComponent<VicCon>().WinG3();
        Destroy(Game3);

    }
}
