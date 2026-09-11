using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public float SPEED = 0.5f;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target) { GoTo(Target); }
        else if (gameObject.name != "Missle") { Destroy(gameObject); }
        
    }
    void GoTo(GameObject point)
    {
        var step = SPEED * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, point.transform.position, step);
    }

}
