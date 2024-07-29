using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedleMove : MonoBehaviour
{
    float rightMax = 6.68f; // 우로 이동가능한 (x)최대값
    float leftMax = -7.68f; // 좌로 이동가능한 (x)최대값
    float currentPositionX; // 현재 위치(x) 저장
    float currentPositionY; // 현재 위치(y) 저장
    float direction = 40.0f; // 이동 속도[숫자]+방향[부호] / 숫자 커질 수록 속도 빨라짐

    bool isMachineStopped = false;
    int currentRoomsScore = 0;
    int score = 0;
    int roundCount = 0;

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
        if(!isMachineStopped) {
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

    public void NeedleStopHandler()
    {
        // 몇 번째 칸에 멈춰있는지 판별
        float entireRoom = rightMax - leftMax;
        float[] rooms = new float[5];
        for(int i=0; i<rooms.Length; i++) {
            rooms[i] = leftMax + (i+1) * (entireRoom/5);
        }
        isMachineStopped = true;
        // isMachineStopped = !isMachineStopped;
        Debug.Log(currentPositionX);
        if(currentPositionX < rooms[0]) {
            Debug.Log("첫 번째 칸");
            currentRoomsScore = 0;
        } else if(currentPositionX < rooms[1]) {
            Debug.Log("두 번째 칸");
            currentRoomsScore = 5;
        } else if(currentPositionX < rooms[2]) {
            Debug.Log("세 번째 칸");
            currentRoomsScore = 10;
        } else if(currentPositionX < rooms[3]) {
            Debug.Log("네 번째 칸");
            currentRoomsScore = 15;
        } else if(currentPositionX < rooms[4]) {
            Debug.Log("다섯 번째 칸");
            currentRoomsScore = 20;
        }
        ScoreHandler(currentRoomsScore);
        roundCount++;
        Debug.Log("Round "+roundCount);
        StartCoroutine(SetTimeOutMoveOnToNextRound(1.5f));
    }
    IEnumerator SetTimeOutMoveOnToNextRound(float sec)
    {
        yield return new WaitForSeconds(sec);
        isMachineStopped = false;
         if(roundCount==5) {
            SceneManager.LoadScene("Click Scene");
        }
    }
    public void ScoreHandler(int currentRoomsScore)
    {
        score += currentRoomsScore;
        Debug.Log("score: " + score);
    }
}
