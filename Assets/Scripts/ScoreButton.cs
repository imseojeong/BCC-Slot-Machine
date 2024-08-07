using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScoreButton : MonoBehaviour
    
{
    CandleLight candleLight = new CandleLight();

    public GameObject door;
    public GameObject background;
    float doorInvoke = 1.2f;

    public void InvokeScoreButtonClickHandler()
    {
        Debug.Log("Click ScoreButton");
        gameObject.SetActive(false);
        Invoke("DoorInactivate", doorInvoke);
        Invoke("BackgroundInactivate", 0.75f);
        //candleLight.StartCoroutine(CandleLight.CandleLightActivate());
    }
    
    public void DoorInactivate()
    {
        door.SetActive(false);
    }

    public void BackgroundInactivate()
    {
        background.SetActive(false);
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter ScoreButton");
        this.transform.Rotate(0, 0, 2.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit ScoreButton");
        this.transform.Rotate(0, 0, -2.5f);
    }*/

    void Start()
    {
        // ������ ��� ����
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
        background.SetActive(true);
        door.SetActive(true);
        gameObject.SetActive(true);


    }

}
