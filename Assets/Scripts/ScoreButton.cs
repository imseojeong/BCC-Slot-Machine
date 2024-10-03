using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScoreButton : MonoBehaviour
    
{
    public Vector3 targetPosition;

    Animator anim;
    AudioSource keySound;
    AudioSource doorSound;

    public GameObject background;
    public GameObject door;
    public GameObject halfDoor;
    public GameObject candle;
    public GameObject cakeTopper;
    public GameObject lightEffect;
    bool isScoreButtonClicked = false;
    public static bool isLightOn = false;

    int rank = 0;

    // 열쇠 클릭 시 열쇠, 문, 배경 비활성화
    public void ScoreButtonClickHandler()
    {
        isScoreButtonClicked = true;
        keySound.Play(0);
        Debug.Log("Click ScoreButton");
        StartCoroutine(SetTimeOutMoveKey());
    }
    
    IEnumerator SetTimeOutMoveKey()
    {
        // 열쇠 회전
        yield return new WaitForSeconds(1.5f);
        isScoreButtonClicked = false;
        anim.Play("keyRotation");
        Debug.Log("Play keyRotation");

        // 문 열림
        yield return new WaitForSeconds(1.0f);
        transform.position = new Vector3(-1300, 0, 0);
        halfDoor.SetActive(false);
        Door.anim.Play("door_open");
        doorSound.Play(0);
        Debug.Log("Play doorOpen");
        
        // 불 켜짐
        yield return new WaitForSeconds(1.5f);
        isLightOn = true;
        door.SetActive(false);
        background.SetActive(false);
        candle.SetActive(true);
        lightEffect.SetActive(true);
        Debug.Log("Play candleLight");

        // candle.SetActive(true) 기다리기
        yield return new WaitForSeconds(0.00001f);
        GameManager.AddSelectedParts();
        if (GameManager.score == 100) {
            rank = 1;
            CandleLight.rectTransform.anchoredPosition = new Vector2(184f, 111f);
            LightEffect.rectTransform.anchoredPosition = new Vector2(184f, 73f);
        }
        else if(GameManager.score > 85) { // 95, 90
            rank = 2;
            CandleLight.rectTransform.anchoredPosition = new Vector2(447.7f, 15.1f);
            LightEffect.rectTransform.anchoredPosition = new Vector2(447.7f, -22.9f);
        }
        else if(GameManager.score > 75) { // 85, 80, 75
            rank = 3;
            CandleLight.rectTransform.anchoredPosition = new Vector2(675f, -81.6f);
            LightEffect.rectTransform.anchoredPosition = new Vector2(675f, -119.6f);
        } else {                         // 70 ... 0
            rank = 4;
            CandleLight.rectTransform.anchoredPosition = new Vector2(853f, -167f);
            LightEffect.rectTransform.anchoredPosition = new Vector2(853f, -205f);
            cakeTopper.SetActive(true);
        }
        Envelope.anim.Play("Envelope_open");
        // 점수 출력
        Debug.Log("Score: " + GameManager.score + ", Rank: " + rank +"등");

    }

    void Start()
    {
        // 투명배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
        anim = GetComponent<Animator>();
        keySound = GetComponent<AudioSource>();
        doorSound = door.GetComponent<AudioSource>();

        background.SetActive(true);
        door.SetActive(true);
        halfDoor.SetActive(true);
        gameObject.SetActive(true);
        candle.SetActive(false);
        cakeTopper.SetActive(false);
        lightEffect.SetActive(false);

        targetPosition = new Vector3(-1, transform.position.y, 0);
    }

    void Update()
    {
        if (isScoreButtonClicked)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 70.0f * Time.deltaTime);        
    }
}
