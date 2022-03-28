using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float accelerationTime;
    public static float maxSpeed;
    private Vector2 movement;
    private float timeLeft;

    private float inputX, inputY;
    private float stopX, stopY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,30f);
        maxSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Run();


    }

    void Run()//villager will move ramdomly
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            inputX = Random.Range(-1f, 1f);
            inputY = Random.Range(-1f, 1f);

            movement = new Vector2(inputX, inputY).normalized;
            rb.velocity = movement * maxSpeed;
            timeLeft += accelerationTime;

            if (movement != Vector2.zero)
            {
                stopX = inputX;
                stopY = inputY;
            }
        }
    }

}
