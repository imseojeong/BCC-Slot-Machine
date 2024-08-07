using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedleMove : MonoBehaviour
{
    float rightMax = 6.68f;
    float leftMax = -7.68f;
    float currentPositionX;
    float currentPositionY;
    [SerializeField]
    float direction; // 이동 속도[숫자]+방향[+-부호] / 숫자 커질 수록 속도 빨라짐

    bool isMachineStopped = false;
    int currentRoomsScore = 0;
    int score = 0;
    int roundCount = 0;
    float partsPositionX = 0;


    List<int> score_s = new List<int>() { 0, 5, 10, 15, 20 };
    public int[,] score2D = new int[5,5];
    public GameObject[,] parts2D = new GameObject[5,5];

    void Start()
    {
        currentPositionX = transform.localPosition.x;
        currentPositionY = transform.localPosition.y;
        Debug.Log(gameObject.transform.parent.gameObject.transform.position);

        for(int i=0; i<5; i++) 
        {
            var score = GameManager.Shuffle(score_s);
            for(int j=0; j<5; j++) 
            {
                score2D[i,j] = score[j];
            }
        }
        GameManager.ArrangeParts(score2D, parts2D);
        for(int i=0; i<5; i++)
        {
            for(int j=0; j<5; j++) 
            {
                Debug.Log("score"+(i+1)+"-"+(j+1)+": " + score2D[i,j]);
                Debug.Log("parts"+(i+1)+"-"+(j+1)+": " + parts2D[i,j].transform.position.x);
                switch (j)
                {
                    case 0: partsPositionX = -5.84f; break;
                    case 1: partsPositionX = -2.99f; break;
                    case 2: partsPositionX = -0.35f; break;
                    case 3: partsPositionX = 2.22f; break;
                    case 4: partsPositionX = 4.82f; break;
                    default: Debug.Log("i가 0~4가 아님"); break;
                }
                parts2D[i,j].transform.position = new Vector3(partsPositionX, 0, 0);
                
            }
        }
    }

    void Update()
    {
        if(!isMachineStopped) {
            currentPositionX += Time.deltaTime * direction;
        }
        if (currentPositionX >= rightMax)
        {
            //currentPositionX가 rightMax보다 크거나 같다면
            //이동 속도+방향에 -1을 곱해 이동 방향을 바꿔주고 현재위치를 rightMax으로 설정
            direction *= -1;
            currentPositionX = rightMax;
        }
        else if (currentPositionX <= leftMax)
        {
            //currentPositionX가 leftMax보다 크거나 같다면
            //이동 속도+방향에 -1을 곱해 이동 방향을 바꿔주고 현재위치를 leftMax으로 설정
            direction *= -1;
            currentPositionX = leftMax;
        }
        //Needle의 위치를 계산된 현재위치로 처리
        transform.localPosition = new Vector3(currentPositionX, currentPositionY, 0);
    }

    public void NeedleStopHandler()
    {
        isMachineStopped = true;

        // 몇 번째 칸에 멈췄는지 판별하고 점수 매기기
        float entireRoom = rightMax - leftMax;
        float[] rooms = new float[5];
        for(int i=0; i<rooms.Length; i++) {
            rooms[i] = leftMax + (i+1) * (entireRoom/rooms.Length);
            if (currentPositionX < rooms[i])
            {
                Debug.Log(i+1 + " 번째 칸");
                currentRoomsScore = score2D[roundCount, i];
                break;
            }
        }
        /*if(currentPositionX < rooms[0]) {
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
        }*/
        ScoreHandler(currentRoomsScore);
        roundCount++;
        Debug.Log("Round " + roundCount);
        StartCoroutine(SetTimeOutMoveOnToNextRound(1.5f));
    }
    IEnumerator SetTimeOutMoveOnToNextRound(float sec)
    {
        yield return new WaitForSeconds(sec);
        isMachineStopped = false;
         if(roundCount==5) {
            SceneManager.LoadScene("Score Scene");
        }
    }
    void ScoreHandler(int currentRoomsScore)
    {
        score += currentRoomsScore;
        Debug.Log("score: " + score);
    }
}
