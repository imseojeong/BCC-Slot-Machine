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
    bool isPartsMoving = false;
    int currentRoomsScore = 0;
    public static int score = 0;
    int roundCount = 0;
    float partsPositionX = 0;
    float partsPositionY = 4.0f;

    float partsPosYTop = 4.0f;
    float partsPosYMiddle = 1.1f;
    float partsPosYBottom = -1.9f;

    // 점수 리스트 (섞기 전)
    List<int> score_s = new List<int>() { 0, 5, 10, 15, 20 };
    // 모든 라운드(5라운드)의 점수 리스트를 섞은 후 넣어줄 5x5 2차원 배열
    public int[,] score2D = new int[5,5];
    // 섞인 점수에 맞춰서 캐릭터 파츠 넣어줄 5x5 2차원 배열
    public GameObject[,] parts2D = new GameObject[5,5];


    public float machineStoppedDuration = 1.0f;


    void Start()
    {
        currentPositionX = transform.localPosition.x;
        currentPositionY = transform.localPosition.y;

        for(int i=0; i<5; i++) 
        {
            var score = GameManager.Shuffle(score_s);
            for(int j=0; j<5; j++) 
            {
                score2D[i,j] = score[j];
            }
        }
        
        GameManager.ArrangeParts(score2D, parts2D);

        // parts2D배열에 들어있는 순서대로 위치(x) 잡아주는 반복문
        for(int i=0; i<5; i++)
        {
            for(int j=0; j<5; j++) 
            {
                switch (j)
                {
                    case 0: partsPositionX = -5.84f; break;
                    case 1: partsPositionX = -2.99f; break;
                    case 2: partsPositionX = -0.35f; break;
                    case 3: partsPositionX = 2.22f; break;
                    case 4: partsPositionX = 4.82f; break;
                    default: Debug.Log("i가 0~4가 아님"); break;
                }
                if (i==0) {
                    partsPositionY = partsPosYMiddle;
                } 
                parts2D[i,j].transform.position = new Vector3(partsPositionX, partsPositionY, 0);
                partsPositionY = partsPosYTop;
            }
        }
    }

    void Update()
    {
        if(!isMachineStopped) {
            currentPositionX += Time.deltaTime * direction;
        } else if(isPartsMoving) {
            // 레버를 눌러서 바늘이 멈추면 다음 라운드로 넘어가기(라운드 넘어갈 때 파츠 아래로 내려가게 위치 조정)
            for(int i=0; i<5; i++) {
                if(roundCount>=5) {
                    break;
                }
                parts2D[roundCount, i].transform.position = Vector3.MoveTowards(parts2D[roundCount, i].transform.position, new Vector3(parts2D[roundCount, i].transform.position.x, partsPosYMiddle, 0), 10.0f * Time.deltaTime);
                parts2D[roundCount-1, i].transform.position = Vector3.MoveTowards(parts2D[roundCount-1, i].transform.position, new Vector3(parts2D[roundCount, i].transform.position.x, partsPosYBottom, 0), 10.0f * Time.deltaTime);
                // parts2D[roundCount, i].transform.position = new Vector3(parts2D[roundCount, i].transform.position.x, partsPosYMiddle, 0);
                // parts2D[roundCount-1, i].transform.position = new Vector3(parts2D[roundCount-1, i].transform.position.x, partsPosYBottom, 0);

            }
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

    // 레버를 클릭하면 실행되는 메소드
    // 바늘 멈춤
    // 1초동안 멈췄다가 1초 지나면 다시 움직임 (coroutine, IEnumerator)
    // 점수 계산도 함
    // 몇 라운드인지 셈
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
                Debug.Log(i+1 + " 번째 칸에 멈춤");
                currentRoomsScore = score2D[roundCount, i];
                Vector2 clonePosition = new Vector2(0, -3.1f);
                switch (roundCount) {
                    case 0: 
                    case 1: clonePosition = new Vector2(-5.72f, -3.1f); break;
                    case 2: 
                    case 3: clonePosition = new Vector2(-0.43f, -3.1f); break;
                    case 4: clonePosition = new Vector2(4.81f, -3.1f); break;
                }
                // 선택된 파츠 복제해서 아래에 띄우기
                GameObject clone = Instantiate(parts2D[roundCount, i], clonePosition, Quaternion.Euler(0, 0, 0));
                // 'default'레이어 보다 위에 있는 'Layer1'레이어로 옮김
                clone.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Layer1");
                break;
            }
        }
        ScoreHandler(currentRoomsScore);
        roundCount++;
        Debug.Log("Round " + roundCount);
        Debug.Log("_______________");
        StartCoroutine(SetTimeOutMoveOnToNextRound(machineStoppedDuration));
    }

    IEnumerator SetTimeOutMoveOnToNextRound(float sec)
    {
        float waitPartsMovingSec = sec - sec/3;

        // 3분의 1초 기다렸다가 파츠들 아래로 내려가게 하는 코드
        yield return new WaitForSeconds(waitPartsMovingSec);
        isPartsMoving = true;

        //machineStoppedDuration(1초) 기다린 후에 실행되는 코드
        yield return new WaitForSeconds(sec-waitPartsMovingSec);
        isMachineStopped = false;
        isPartsMoving = false;
         if(roundCount==5) {
            SceneManager.LoadScene("Score Scene");
        }
    }

    // 각 라운드별 점수 더해서 총점 계산하는 코드
    void ScoreHandler(int currentRoomsScore)
    {
        score += currentRoomsScore;
        Debug.Log("이번 라운드 점수: " + currentRoomsScore);
        Debug.Log("총점: " + score);
    }
}
