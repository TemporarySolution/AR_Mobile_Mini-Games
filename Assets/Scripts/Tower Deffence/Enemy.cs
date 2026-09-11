using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Target = null;
    public GameObject SCOPE = null;
    public GameObject GUN = null;
    public float HP = 2;
    public float SPEED;
    public float MONEY = 2;
    public int DAMAGE;
    public bool TARGETED = false;
    public GameObject MeSelf = null;
    // Start is called before the first frame update
    void Start()
    {
        MeSelf = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target) { GoTo(Target); }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Missle(Clone)")
        {
            HP = HP - GUN.GetComponent<SpawnObj>().DAMAGE;
            Destroy(collision.gameObject);
            if (HP <= 0) 
            {
                GUN.GetComponent<SpawnObj>().MONEY += MONEY;
                SCOPE.GetComponent<Scope>().lastTargetedObject = null;
                Destroy(MeSelf); 
            } 
        }
        if (collision.gameObject.name == "Tower")
        {
            collision.gameObject.GetComponent<Base>().HP -= DAMAGE;
            //Destroy(collision.gameObject);
            if (TARGETED)
            {
                SCOPE.GetComponent<Scope>().lastTargetedObject = null;
            }
            Destroy(MeSelf);
        }
        print("Collision detected");
    }
    void GoTo(GameObject point)
    {
        var step = SPEED * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, point.transform.position, step);
    }

}
