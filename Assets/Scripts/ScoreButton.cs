using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScoreButton : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public GameObject door;

    public void InvokeScoreButtonClickHandler()
    {
        gameObject.SetActive(false);
        Invoke("ScoreButtonClickHandler", 0.59f);
        Invoke("DoorInactivate", 0.59f);
    }

    public void ScoreButtonClickHandler()
    {
        //SceneManager.LoadScene("Score Scene");
        gameObject.SetActive(false);
        Debug.Log("Click ScoreButton");
    }
    
    public void DoorInactivate()
    {
        door.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter ScoreButton");
        this.transform.Rotate(0, 0, 2.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit ScoreButton");
        this.transform.Rotate(0, 0, -2.5f);
    }

    void Start()
    {
        // 투명한 배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }

}
