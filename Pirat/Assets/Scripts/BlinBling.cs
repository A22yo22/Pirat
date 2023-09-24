using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlinBling : MonoBehaviour
{
    Image background;

    public Color color1;
    public Color color2;
    public Color color3;

    public void Start()
    {
        background = GetComponent<Image>();

        StartCoroutine(Change_Color());
    }

    IEnumerator Change_Color()
    {
        yield return new WaitForSeconds(1);
        background.color = color1;

        yield return new WaitForSeconds(1);
        background.color = color2;

        yield return new WaitForSeconds(1);
        background.color = color3;

        StartCoroutine(Change_Color());
    }
}
