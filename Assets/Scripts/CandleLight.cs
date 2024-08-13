using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    public static Animator anim;
    public static RectTransform rectTransform;

    void Start()
    {
        gameObject.SetActive(false);
        anim = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        
    }
}
