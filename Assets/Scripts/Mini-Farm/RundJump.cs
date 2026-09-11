using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RundJump : MonoBehaviour
{
    public float jumpForce = 5f; // Adjust to set how high the cows jump
    public float minJumpInterval = 30f; // Minimum interval between jumps (in seconds)
    public float maxJumpInterval = 60f; // Maximum interval between jumps (in seconds)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(JumpRandomly());
    }
    void Update()
    {

    }

    IEnumerator JumpRandomly()
    {
        while (true)
        {
            float nextJumpTime = UnityEngine.Random.Range(minJumpInterval, maxJumpInterval) / 2f; // Average two jumps in 1 minute
            yield return new WaitForSeconds(nextJumpTime);

            Jump();
        }
    }

    void Jump()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

   