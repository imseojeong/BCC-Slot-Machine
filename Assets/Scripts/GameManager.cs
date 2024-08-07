using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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


        


    void Start()
    {

    }

    void Update()
    {

    }
}
