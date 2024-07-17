using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMove : MonoBehaviour
{
    float rightMax = 4.05f; // 좌로 이동가능한 (x)최대값
    float leftMax = -4.15f; // 우로 이동가능한 (x)최대값
    float currentPositionX; // 현재 위치(x) 저장
    float currentPositionY; // 현재 위치(y) 저장
    float direction = 14.0f; // 이동 속도[숫자]+방향[부호] / 숫자 커질 수록 속도 빨라짐

    // Start is called before the first frame update
    void Start()
    {
        currentPositionX = transform.localPosition.x;
        currentPositionY = transform.localPosition.y;
        Debug.Log(gameObject.transform.parent.gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        currentPositionX += Time.deltaTime * direction;
        if (currentPositionX >= rightMax)
        {
            direction *= -1;
            currentPositionX = rightMax;
        }
        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정
        else if (currentPositionX <= leftMax)
        {
            direction *= -1;
            currentPositionX = leftMax;
        }
        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정
        transform.localPosition = new Vector3(currentPositionX, currentPositionY, 0);
        //Needle의 위치를 계산된 현재위치로 처리
    }
}
