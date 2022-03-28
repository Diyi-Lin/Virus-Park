using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState: MonoBehaviour
{
    public Rigidbody2D rbody;
    public bool Vaccinated;
    public bool Masked;
    public bool Infected;
    public GameObject player;
    public GameObject vac;
    public GameObject vir;
    public GameObject mask;
    public GameObject virusPrefab;

    private float timer = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (Infected)//infected villagers can spread virus every 6s
            {
                Instantiate(virusPrefab, rbody.position + new Vector2(0, -1.5f), Quaternion.identity);
            }
            timer = 6f;
        }
    }

    // Vacinated
    private void OnTriggerEnter2D(Collider2D other)
    {
        bulletcontroller bc = other.GetComponent<bulletcontroller>();
        if(bc != null)
        {
            if (bc.isMask && Masked == false)//put a mask on an unmasked villager
            {
                Mask();
                Destroy(other.gameObject);
            }
            if ( !bc.isMask && Vaccinated == false)// vaccine a unvaccinated villager
            {
                Vaccination();
                Destroy(other.gameObject);
            }
        }
    }

    public void Vaccination()
    {
        Vaccinated = true;
        Infected = false;
        vac.SetActive(true);
        vir.SetActive(false);
        Debug.Log("A villager takes vaccine.");
        playercontroller pc = player.GetComponent<playercontroller>();
        pc.ChangeScore(2);
    }

    public void Infect()
    {
        Infected = true;
        vir.SetActive(true);
        Debug.Log("A player is infected" + Infected);
        playercontroller pc = player.GetComponent<playercontroller>();
        pc.ChangeScore(-1);
    }

    public void Mask()
    {
        Masked = true;
        mask.SetActive(true);
        Debug.Log("A villager puts on a maask.");
        playercontroller pc = player.GetComponent<playercontroller>();
        pc.ChangeScore(2);
    }
}
