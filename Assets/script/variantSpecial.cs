using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variantSpecial : MonoBehaviour
{
    public float timer;
    public float toggleDuration;
    public float variantDuration;

    public GameObject player;

    public GameObject ghost;

    private bool canToggle;
    private bool toggle;
    // Start is called before the first frame update
    void Start()
    {
        timer = 20;
        toggleDuration = 10;
        variantDuration = 20;
        canToggle = false;
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canToggle && !toggle) //timer counting down
        { 
            timer -= Time.deltaTime; 
        }
        if (timer <= 0) //can be toggle when timer count down to zero
        {
            ghost.SetActive(true);
            canToggle = true;
            timer = 20;
        }
        if (canToggle && !toggle)// toggle duration counting down 
        {
            toggleDuration -= Time.deltaTime;
        }
        if (toggleDuration <= 0)//can on longer be toggled if toggle duration count down to zero
        {
            canToggle = false;
            playercontroller pc = player.GetComponent<playercontroller>();
            pc.ChangeScore(-2);
            toggleDuration = 10;//reset timer
            ghost.SetActive(false);
        }
        if (canToggle && Input.GetKeyDown(KeyCode.I))//press I to toggle in toggle duration
        {
            playercontroller pc = player.GetComponent<playercontroller>();
            pc.ChangeScore(1);
            toggle = true;
            canToggle = false;
            toggleDuration = 10;//stop and reset timer
        }
        if(toggle)
        {
            npcMovement.maxSpeed = 6f;
            playercontroller.speed = 20f;

            variantDuration -= Time.deltaTime;
        }
        if (variantDuration <= 0)
        {
            toggle = false;
            ghost.SetActive(false);
            npcMovement.maxSpeed = 2f;
            playercontroller.speed = 8f;
            variantDuration = 20;
        }
    }
}
