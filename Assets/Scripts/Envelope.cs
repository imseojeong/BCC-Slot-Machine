using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : MonoBehaviour
{
    public static Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        // 투명배경 무시
        //GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }

    void Update()
    {
        
    }
}
