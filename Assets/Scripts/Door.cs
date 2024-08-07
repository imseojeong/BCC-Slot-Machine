using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;

    // 문열리는 애니메이션 실행 메소드
    public void ScoreButtonClickHandler()
    {
        anim.Play("door_open");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

}
