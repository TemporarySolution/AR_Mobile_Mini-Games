using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallResp : MonoBehaviour
{
    public GameObject Start;
    public GameObject Ball;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBall()
    {
        Ball.transform.position = Start.transform.position;


    }
}
