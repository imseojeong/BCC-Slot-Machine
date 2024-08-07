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
    // 문 열리는 애니메이션 지속시간
    float doorAnimationDuration = 1.2f;

    // 열쇠 클릭 시 열쇠, 문, 배경 비활성화
    public void InvokeScoreButtonClickHandler()
    {
        Debug.Log("Click ScoreButton");
        gameObject.SetActive(false);
        Invoke("InActiveDoor", doorAnimationDuration);
        Invoke("InActiveScoreBackground", 0.75f);
        // TODO: V수정필요V
        //candleLight.StartCoroutine(CandleLight.CandleLightActivate());
    }
    
    public void InActiveDoor()
    {
        door.SetActive(false);
    }

    public void InActiveScoreBackground()
    {
        background.SetActive(false);
    }

    void Start()
    {
        // 투명배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
        background.SetActive(true);
        door.SetActive(true);
        gameObject.SetActive(true);
    }

}
