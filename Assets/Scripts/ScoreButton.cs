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

    public void InvokeScoreButtonClickHandler()
    {
        Invoke("ScoreButtonClickHandler", 0.59f);
        gameObject.SetActive(false);
    }

    void ScoreButtonClickHandler()
    {
        SceneManager.LoadScene("Score Scene");
        Debug.Log("Click ScoreButton");
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
