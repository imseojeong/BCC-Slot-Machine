using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    //ScoreButton ScoreButton;
    public static Animator anim;

     /*public IEnumerator CandleLightActivate(GameObject candle, float doorAnimationDuration)
     {
         yield return new WaitForSeconds(doorAnimationDuration);
         candle.SetActive(true);
         anim.Play("CandleLight");
     }*/

    void Start()
    {
        gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
