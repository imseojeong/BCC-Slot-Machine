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
    // Animator CherryBombAnimation;
    public Animator CherryBombAnimation;
    public GameObject cherryBomb;

    public void StartButtonClickHandler()
    {
        Debug.Log("Click StartButton");
        cherryBomb.SetActive(true);
        CherryBombAnimation.Play("CherryBombAnimation");
        Invoke("LoadPlayScene", 0.5f);
        // cherryBomb.SetActive(false);
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("Play Scene");
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
        // 투명부분 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }
}
