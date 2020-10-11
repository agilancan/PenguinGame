using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FramerateCounter : MonoBehaviour
{
    private int frameCounter = 0;
    private float timeCounter = 0.0f;
    private float refreshTime = 0.1f;

    private float maxframerate = 0f;
    private float minframerate = 1000f;

    [SerializeField]
    private Text FPSCounterHeader;
    [SerializeField]
    private Text MinFPSCounterHeader;
    [SerializeField]
    private Text MaxFPSCounterHeader;

    private void Start()
    {
        StartCoroutine(ResetMinFramerate());
    }

    private IEnumerator ResetMinFramerate()
    {
        yield return new WaitForSeconds(1f);
        minframerate = 1000f;
    }

    void Update()
    {
        if (timeCounter < refreshTime)
        {
            timeCounter += Time.deltaTime;
            frameCounter++;
        } 
        else 
        {
            float lastFramerate = frameCounter / timeCounter;
            if (minframerate > lastFramerate) minframerate = lastFramerate;
            if (maxframerate < lastFramerate) maxframerate = lastFramerate;
            frameCounter = 0;
            timeCounter = 0.0f;
            FPSCounterHeader.text = lastFramerate.ToString("n2");
            MinFPSCounterHeader.text = minframerate.ToString("n2");
            MaxFPSCounterHeader.text = maxframerate.ToString("n2");
        }
    }
}
