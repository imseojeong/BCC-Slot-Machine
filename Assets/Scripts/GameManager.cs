using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<int> Shuffle(List<int> values)
    {
        System.Random rand = new System.Random();
        var shuffled = values.OrderBy(_ => rand.Next()).ToList();

        return shuffled;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
