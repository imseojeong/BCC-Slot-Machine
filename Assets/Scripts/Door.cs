using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

void Update()
    {
        if (Input.GetButton("Submit"))
            anim.Play("door_open");

    }
}
