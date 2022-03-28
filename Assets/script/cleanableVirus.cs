using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clean virus to score
//if infected others will disscore

public class cleanableVirus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playercontroller pc = other.GetComponent<playercontroller>();
        if (pc != null)// the virus killed by the player
        {
            pc.ChangeScore(1);
            Destroy(this.gameObject);
        }
        NpcState mpc = other.GetComponent<NpcState>();
        if(mpc != null)
        {
            if (!mpc.Vaccinated && !mpc.Masked && !mpc.Infected)//a villager without mask and vaccination is infected 
            {
                mpc.Infect();
                Destroy(this.gameObject);
            }

        }
    }
}
