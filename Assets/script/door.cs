using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject VacinatedNpcPrefab;
    public GameObject MaskedNpcPrefab;
    public GameObject UnmaskedNpcPrefab;
    public GameObject EndangerNpcPrefab;
    public GameObject InfectedNpcPrefab;

    public float MobTimer;// Mob will come more than twice per level

    public float LevelUp;// Next level will come with faster villagers spwaning rate

    private float timeToSpwan;// Spwan a ramdon type of villager when it counts down to zero

    private float rate;// increase with Level

    private bool specialMode; 

    void Start()
    {
        MobTimer = Random.Range(40,50);
        LevelUp = 110;
        timeToSpwan = Random.Range(5,20);
        rate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MobTimer -= Time.deltaTime;
        LevelUp -= Time.deltaTime;
        timeToSpwan -= rate*Time.deltaTime;

        //spwan a villager
        if(timeToSpwan <= 0)
        {
            Spwan(1);
            timeToSpwan = Random.Range(24, 27);//reset spwan timer
        }

        //mob comes
        if(MobTimer <= 0)
        {
            Spwan(10);
            MobTimer = Random.Range(40, 50);//reset mob timer
        }

        //level up
        if(LevelUp <= 0)
        {
            MobTimer = MobTimer = Random.Range(40, 50);//reset mob timer
            LevelUp = 110;// reset level up timer
            rate += 0.3f;// increase spwaning ratre
        }
    }
    private void Spwan(int times)//spwan ramdon type of villager 
    {
        for (int i = 0; i < times; i++)
        {
            int typeOfVillager = Random.Range(1, 6);
            switch (typeOfVillager)
            {
                case 1:
                    Instantiate(VacinatedNpcPrefab, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(MaskedNpcPrefab, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(UnmaskedNpcPrefab, transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(EndangerNpcPrefab, transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(InfectedNpcPrefab, transform.position, Quaternion.identity);
                    break;
            }
        }
            
    }
}
