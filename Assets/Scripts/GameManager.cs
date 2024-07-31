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

    public static String ArrangeParts(int round) 
    {
        GameObject parts = new GameObject();
        //GameObject parts = GameObject.FindWithTag("Round" + round);
        if (round%2==0)
            parts = GameObject.Find("Round" + round).transform.Find("A-transparent").gameObject;
        else
            parts = GameObject.Find("Round" + round).transform.Find("A-color").gameObject;
        //parts = parts.Find("A-color");

        return parts.name;
    }


        


    void Start()
    {

    }

    void Update()
    {

    }
}
