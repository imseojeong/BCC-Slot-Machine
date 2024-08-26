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
    AudioSource clickSoundBig;
    public static GameObject[] partTrans = new GameObject[5];

    public void RestartButtonClickHandler()
    {
        clickSoundBig.Play(0);
        Debug.Log("Click RestartButton");
        StartCoroutine(SetTimeOutClickSoundBig());
    }

    IEnumerator SetTimeOutClickSoundBig()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Start Scene");
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
        clickSoundBig = GetComponent<AudioSource>();
        // 투명배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }
}
