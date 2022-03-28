using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour
{
    public float timeStart;//lefted time to the next level
    public Text textBox;//bar to show the lefted time

    // Start is called before the first frame update
    void Start()
    {
        timeStart = 110f;//110s per level
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {  
        run();
    }

    void run() 
    {
        if (timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            textBox.text = Mathf.Round(timeStart).ToString();
        }
        else 
        {
            timeStart = 110f;
        }
    }
}
