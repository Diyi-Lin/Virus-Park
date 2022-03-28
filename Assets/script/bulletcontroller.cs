using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    Rigidbody2D rbody;

    public bool isMask;

    // Start is called before the first frame update
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,1.5f);//the bullet can last for 1.5s
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 moveDirection, float moveForce) // add a speed to the bullet
    {
        rbody.AddForce(moveDirection * moveForce);
    }

    private void OnCollisionEnter2D(Collision2D other)//bullet will be stopped by objects.
    {
        Destroy(this.gameObject);
    }
}
