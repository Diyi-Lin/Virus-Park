using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//movement, animation

public class playercontroller : MonoBehaviour
{
    public static float speed;//default speed of player

    private static int score;

    Rigidbody2D rbody;

    public GameObject bulletMaskPrefab;

    public GameObject bulletVacPrefab;
    public Text scoree; 
    private bool bulletType;

    private Vector2 lookDirection = new Vector2(1, 0);//default shooting direction


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        score = 0;
        bulletType = true;
        speed = 8;

    }

    // Update is called once per frame
    void Update()
    {
        //-----print score on screen
        printScore();

        //-----wasd to control the player
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x != 0 || moveVector.y != 0)
        {
            lookDirection = moveVector;
        }


        Vector2 position = rbody.position;
        position += moveVector * speed * Time.fixedDeltaTime;
        rbody.MovePosition(position);

        //---switch bullet type(vaccine or mask)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletType = !bulletType;
        }

        //---shoot  the bullet
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (bulletType)
            {
                GameObject bullet = Instantiate(bulletMaskPrefab, rbody.position, Quaternion.identity);
                bulletcontroller bc = bullet.GetComponent<bulletcontroller>();
                if (bc != null)
                {
                    bc.Move(lookDirection, 800);
                }
            }
            else
            {
                GameObject bullet = Instantiate(bulletVacPrefab, rbody.position, Quaternion.identity);
                bulletcontroller bc = bullet.GetComponent<bulletcontroller>();
                if (bc != null)
                {
                    bc.Move(lookDirection, 800);
                }
            }
        }
    }

    public int CurrentScore { get{ return score; } } //return the current score of the player

    public void printScore()
    {
        scoree.text = score.ToString();
    }

    public void ChangeScore(int amount)// change the score of the player
    {
        score += amount;
        Debug.Log("score: " + score);
    }
}
