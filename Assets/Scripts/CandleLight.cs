using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    GameObject candle;

    // public IEnumerator CandleLightActivate()
    // {
    //     yield return new WaitForSeconds(0);
    //     CandleLight.candle.SetActive(true);
    // }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
