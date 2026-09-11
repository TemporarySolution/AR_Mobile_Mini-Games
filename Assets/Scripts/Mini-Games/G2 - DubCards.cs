using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class G2DubCards : MonoBehaviour
{
    public GameObject c1 = null;
    public GameObject c2 = null;
    private GameObject a = null;
    private GameObject b = null;
    public int Score = 0;
    bool working = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((c1 != null) && (c2 != null)) {
            StartCoroutine(Example(c1, c2));
        }
    }
    IEnumerator Example(GameObject c1, GameObject c2)
    {
        gameObject.GetComponent<G2DubCards>().c1 = null;
        gameObject.GetComponent<G2DubCards>().c2 = null;
        //working = true;
        //print(Time.time);
        yield return new WaitForSeconds(1);
        if (c1.GetComponent<CarRotation>().cardFront == c2.GetComponent<CarRotation>().cardFront)
        {
            
            Destroy(c1);
            Destroy(c2);
            Score++;
            //test
        }
        else { 
            c1.GetComponent<CarRotation>().to = c1.GetComponent<CarRotation>().LOOKAT_CAMERA.transform;
            c2.GetComponent<CarRotation>().to = c2.GetComponent<CarRotation>().LOOKAT_CAMERA.transform;
         //working = false;
        }
    }
    void DeleteCards()
    {

    }
}


