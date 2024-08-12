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
    public GameObject door;
    public GameObject background;
    public GameObject candle;
    public GameObject HalfDoor;
    // 문 열리는 애니메이션 지속시간
    float doorAnimationDuration = 1.2f;
    float keyAnimationDuration = 0.4f;
    bool isScoreButtonClicked = false;

    // 열쇠 클릭 시 열쇠, 문, 배경 비활성화
    public void InvokeScoreButtonClickHandler()
    {
        isScoreButtonClicked = true;
        Debug.Log("Click ScoreButton");
        StartCoroutine(SetTimeOutMoveKey());
    }
    
    IEnumerator SetTimeOutMoveKey()
    {
        // 열쇠 회전
        yield return new WaitForSeconds(0.7f);
        isScoreButtonClicked = false;
        anim.Play("keyRotation");
        Debug.Log("Play keyRotation");

        // 문 열림
        yield return new WaitForSeconds(1.0f);
        transform.position = new Vector3(-1300, 0, 0);
        HalfDoor.SetActive(false);
        Door.anim.Play("door_open");
        Debug.Log("Play doorOpen");
        
        // 불 켜짐
        yield return new WaitForSeconds(1.2f);
        door.SetActive(false);
        background.SetActive(false);
        candle.SetActive(true);
        CandleLight.anim.Play("CandleLight2");
        Debug.Log("Play CandleLight2");
    }

    void Start()
    {
        // 투명배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
        anim = GetComponent<Animator>();

        background.SetActive(true);
        door.SetActive(true);
        gameObject.SetActive(true);

        targetPosition = new Vector3(-80, transform.position.y, 0);
    }

    void Update()
    {
        if (isScoreButtonClicked)
        {
            Debug.Log("이동중..");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 100.0f * Time.deltaTime);        }
    }
}
