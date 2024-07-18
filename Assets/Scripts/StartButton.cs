using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public void StartButtonClickHandler()
    {
        SceneManager.LoadScene("Play Scene");
        Debug.Log("Click StartButton");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter StartButton");
        this.transform.Rotate(0, 0, 3);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit StartButton");
        this.transform.Rotate(0, 0, -3);
    }

    void Start()
    {
        // 투명한 배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }
}
