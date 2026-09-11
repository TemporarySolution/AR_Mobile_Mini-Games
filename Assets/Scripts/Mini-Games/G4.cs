using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G4 : MonoBehaviour
{
    public GameObject VinCon;
    public GameObject Game4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Коллизия");
        if (collision.gameObject.name == "Sphere")
        {
            VinCon.GetComponent<VicCon>().WinG4();
            Destroy(Game4);
        }
    }
}
