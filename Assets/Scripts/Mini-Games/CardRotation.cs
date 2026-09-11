using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
public class CarRotation : MonoBehaviour
{
    private GameObject a;
    private GameObject b;
    public GameObject GameScript;
    public Sprite cardBack;
    public Sprite cardFront;
    public GameObject LOOKAT_CAMERA;
    public GameObject LOOKAT_CUBE;
    float smooth = 5.0f;
    float ROTATED = 0.0f;
    public Transform to;
    //Quaternion target;
    float timeCount;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //Quaternion target = Quaternion.Euler(Quest.transform.rotation[0], Quest.transform.rotation[1]+ ROTATED, Quest.transform.rotation[2]);
        timeCount = 0.0f;
        to = LOOKAT_CAMERA.transform;

        a = GameScript.GetComponent<G2DubCards>().c1;
        b = GameScript.GetComponent<G2DubCards>().c2;

    }

    // Update is called once per frame
    void Update()
    {
        /*transform.Rotate(Vector3.up, 0.1f);

        //if (transform.rotation[1] <= 0)
        {
           gameObject.GetComponent<Image>().sprite = cardFront;
        }
        //if (transform.rotation[1] > 0)
        {
            gameObject.GetComponent<Image>().sprite = cardBack;
        }
        print(transform.rotation);
        */
        //Quaternion target = Quaternion.Euler(Quest.transform.rotation[0] * DIEDIEDIEDIEDIEDIE , Quest.transform.rotation[1] * DIEDIEDIEDIEDIEDIE + ROTATED, Quest.transform.rotation[2] * DIEDIEDIEDIEDIEDIE);
        //Quaternion target = Quaternion.Euler(0, ROTATED, 0);
        //print((transform.LookAt(MainCamera.transform)));

        //print(transform.rotation);

        //transform.LookAt(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, to.rotation, Time.deltaTime*smooth);

        


    }

    public void LookAt()
    {
        to = LOOKAT_CUBE.transform;
        if (ROTATED == 0)
        {
            ROTATED = 180.0f;
        }
        else { ROTATED = 0.0f; }
        timeCount = 0.0f;

        if (GameScript.GetComponent<G2DubCards>().c1 == null) {
            GameScript.GetComponent<G2DubCards>().c1 = gameObject;
        } else if (GameScript.GetComponent<G2DubCards>().c2 == null) {
            GameScript.GetComponent<G2DubCards>().c2 = gameObject;
        }
        //transform.Rotate(Vector3.up, 180);

    }
}
