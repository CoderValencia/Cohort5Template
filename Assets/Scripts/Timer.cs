using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float currentTime;
    public TextMeshProUGUI currentTimeText;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
    

        currentTime = currentTime + Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);

        currentTimeText.text = timeSpan.ToString(@"mm\:ss");

    }
}
