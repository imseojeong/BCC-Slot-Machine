using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class RestartButton : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public void RestartButtonClickHandler()
    {
        SceneManager.LoadScene("Start Scene");
        Debug.Log("Click RestartButton");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter RestartButton");
        this.transform.Rotate(0, 0, -3);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit RestartButton");
        this.transform.Rotate(0, 0, 3);
    }

    void Start()
    {
        // 투명배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }
}
