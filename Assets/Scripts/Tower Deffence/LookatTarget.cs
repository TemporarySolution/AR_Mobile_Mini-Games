using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatTarget : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Transform cameraTransform = Camera.main.transform;

        // Make the object face the camera
        if (Target) { transform.LookAt(Target.transform); }
        

        // Optional: Adjust rotation to prevent objects from flipping (e.g., for UI)
        // transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
