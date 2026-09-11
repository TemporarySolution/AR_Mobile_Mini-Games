using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class IndMaze : MonoBehaviour
{
    public GameObject Reveal1 = null;
    public GameObject Reveal2 = null;
    public GameObject Reveal3 = null;
    public GameObject RevealWall = null;
    public GameObject Hide1 = null;
    public GameObject Hide2 = null;
    public GameObject Hide3 = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCentral(GameObject Central, GameObject Prewious, GameObject Reveal1, GameObject Reveal2,  GameObject RevealWall, GameObject Hide1, GameObject Hide2, GameObject Hide3)
    {
        //Reveal1.SetActive(true); Reveal2.SetActive(true); RevealWall.SetActive(true); Hide1.SetActive(false); Hide2.SetActive(false); Hide3.SetActive(false);
        //Central.SetActive(true); Central.GetComponent<Image>().sprite = Prewious.GetComponent<Image>().sprite;
        //Prewious.SetActive(true); Prewious.GetComponent<Image>().sprite = Reveal1.GetComponent<Image>().sprite;

    }
}
