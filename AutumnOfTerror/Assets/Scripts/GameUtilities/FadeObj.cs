using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeObj : MonoBehaviour
{
    private Image thisImg;

    public void Start()
    {
        thisImg = this.GetComponent<Image>();
    }

    public IEnumerator Fade(bool fadeOut)
    {
        Debug.Log("Calling fade");

        float currTime = 0f;
        float time = 2.5f;

        Color spriteColour = thisImg.color;

        do
        {
            //fading from 0 opacity to full
            if (fadeOut)
            {
                spriteColour.a = (currTime / time);
            }

            //fading from full opacity to 0
            else
            {
                spriteColour.a = 1 - (currTime / time);
            }

            thisImg.color = spriteColour;

            yield return null;

            currTime += Time.deltaTime;
        } while (currTime <= time);
    }
}
