using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public GameObject GUN = null;
    public GameObject lastTargetedObject = null;
    public GameObject lasthitObject = null;
    public GameObject hitObject = null;
    //public LayerMask layerMask = LayerMask.GetMask("Enemy");
    // Start is called before the first frame update
    void Start()
    {



    }
    
    // Update is called once per frame
    void Update()
    {
    RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, LayerMask.GetMask("Enemy")))
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hitObject != lasthitObject)
            {
                if (lasthitObject != null)
                {
                    if (lasthitObject.GetComponent<Enemy>().TARGETED == false) { lasthitObject.GetComponent<Outline>().OutlineColor = Color.clear; }
                    else { lasthitObject.GetComponent<Outline>().OutlineColor = Color.red; }
                }
                lasthitObject = hitObject;
                if (lasthitObject.GetComponent<Enemy>().TARGETED == false){ hitObject.GetComponent<Outline>().OutlineColor = Color.yellow; }
                else { lasthitObject.GetComponent<Outline>().OutlineColor = Color.red; }
            }
        }
        else
        {
            if (lasthitObject != null)
            {
                if (lasthitObject.GetComponent<Enemy>().TARGETED == false) { lasthitObject.GetComponent<Outline>().OutlineColor = Color.clear; }
            }
            hitObject = null;
            lasthitObject = null;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
        if (lastTargetedObject == null)
        {
            GUN.GetComponent<SpawnObj>().TARGET = null;
        }
    }
    public void SetAttackTarget()
    {
        Debug.Log("Атакуем!");
        if (lastTargetedObject)
        {
            lastTargetedObject.GetComponent<Enemy>().TARGETED = false;
            lasthitObject.GetComponent<Outline>().OutlineColor = Color.clear;
        }
        lastTargetedObject = lasthitObject;
        lasthitObject.GetComponent<Outline>().OutlineColor = Color.red;
        lastTargetedObject.GetComponent<Enemy>().TARGETED = true;
        GUN.GetComponent<SpawnObj>().TARGET = lastTargetedObject;
        GUN.GetComponent<LookatTarget>().Target = lastTargetedObject;



    }
}
