using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : MonoBehaviour
{
    public static Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        // ������ ����
        //GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }

    void Update()
    {
        
    }
}
