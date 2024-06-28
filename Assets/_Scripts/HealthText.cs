using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{   
    //pixel/sec
    public Vector3 moveSpeed = new Vector3(0,75,0);
    public float timeToFaded = 1f;

    RectTransform textTransform;
    TextMeshProUGUI textMeshPro;

    private Color startColor;
    private float timeElapsed = 0f;

    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        startColor = textMeshPro.color;
    }

    private void Update()
    {
        textTransform.position += moveSpeed * Time.deltaTime;

        timeElapsed += Time.deltaTime;

        if (timeElapsed < timeToFaded)
        {   
            float fadeAlpha = startColor.a * (1 - (timeElapsed / timeToFaded));

            textMeshPro.color = new Color(startColor.r ,startColor.g,startColor.b,fadeAlpha);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
