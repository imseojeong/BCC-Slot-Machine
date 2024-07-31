using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Random random = new Random();
    int[] score = { 0, 5, 10, 15, 20 };
    List<int> index_s = new List<int>() { 0, 1, 2, 3, 4 };

    public static List<int> Shuffle(List<int> values)
    {
        System.Random rand = new System.Random();
        var shuffled = values.OrderBy(_ => rand.Next()).ToList();

        return shuffled;
    }

    void Start()
    {
        var index=Shuffle(index_s);
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(index[i]);
        }
    }

    void Update()
    {
        
    }
}
