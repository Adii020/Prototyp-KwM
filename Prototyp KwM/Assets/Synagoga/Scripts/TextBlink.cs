using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    [SerializeField]
    private Color colorBefore;
    [SerializeField]
    private Color colorAfter;
    [SerializeField]
    private float blinkingSpeed;
    private Image image;

    bool changeToColorBefore = false;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        Blink(); 
    }

    void Blink()
    {
        if (image.color == colorBefore)
        {
            changeToColorBefore = false;
        }
        else if (image.color == colorAfter)
        {
            changeToColorBefore = true;
        }
        
        if (changeToColorBefore)
        {
            image.color = Color.Lerp(image.color, colorBefore, Time.deltaTime * blinkingSpeed);
        }
        else
        {
            image.color = Color.Lerp(image.color, colorAfter, Time.deltaTime * blinkingSpeed);
        }
    }
}