using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static String[] resultArr = new string[5];

    // 리스트 내부 요소의 순서를 섞는 메소드
    public static List<int> Shuffle(List<int> values)
    {
        System.Random rand = new System.Random();
        var shuffled = values.OrderBy(_ => rand.Next()).ToList();

        return shuffled;
    }

    // 셔플로 섞인 점수배열의 순서에 맞춰 파츠를 정렬하는 메소드
    public static void ArrangeParts(int[,] score2D, GameObject[,] parts2D)
    {
        GameObject parts = new GameObject();

        for(int i=0; i<5; i++) 
        {
            for(int j=0; j<5; j++) 
            {
                parts2D[i,j] = GameObject.Find(i.ToString()).transform.Find(i.ToString()+"-"+score2D[i,j].ToString()).gameObject;
            }
        }
    }

    public static void ScoreHandler(int currentRoomsScore)
    {
        score += currentRoomsScore;
        Debug.Log("이번 라운드 점수: " + currentRoomsScore);
        Debug.Log("총점: " + score);
    }

    public static IEnumerator SetTimeOutMoveOnToNextRound(float sec)
    {
        float waitPartsMovingSec = sec - sec/3;

        // 3분의 1초 기다렸다가 파츠들 아래로 내려가게 하는 코드
        yield return new WaitForSeconds(waitPartsMovingSec);
        NeedleMove.isPartsMoving = true;

        //machineStoppedDuration(1초) 기다린 후에 실행되는 코드
        yield return new WaitForSeconds(sec-waitPartsMovingSec);
        NeedleMove.isMachineStopped = false;
        NeedleMove.isPartsMoving = false;
         if(NeedleMove.roundCount==5) {
            SceneManager.LoadScene("Score Scene");
        }
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
