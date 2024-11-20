using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class ScoreButton : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler

{
    public Vector3 targetPosition;

    AudioSource keySound;
    AudioSource doorSound;
    AudioSource lightSwitchSound;
    AudioSource shalalaSound;

    public GameObject background;
    public GameObject door;
    public GameObject halfDoor;
     public TMP_Text scoreText;

    bool isScoreButtonClicked = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isScoreButtonClicked){
            Debug.Log("Enter scoreButton");
            GetComponent<RectTransform>().localScale = new Vector2(0.42f, 0.42f);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(!isScoreButtonClicked){
            Debug.Log("Exit scoreButton");
            GetComponent<RectTransform>().localScale = new Vector2(0.40908f, 0.40908f);
           
        }
    }

    // 열쇠 클릭 시 열쇠, 문, 배경 비활성화
    public void ScoreButtonClickHandler()
    {
        isScoreButtonClicked = true;
        GetComponent<Button>().enabled= false;
        keySound.Play(0);
        Debug.Log("Click ScoreButton");
        GameManager.ScoreHandler();
        scoreText.text = GameManager.score.ToString(); //TODO: 위치 조정
        StartCoroutine(SetTimeOutMoveKey());
        GetComponent<Button>().enabled = false;
    }
    
    IEnumerator SetTimeOutMoveKey()
    {
        // 열쇠 회전
        yield return new WaitForSeconds(1.5f);
        isScoreButtonClicked = false;
        GetComponent<Animator>().Play("keyRotation");
        Debug.Log("Play keyRotation");

        // 문 열림
        yield return new WaitForSeconds(1.0f);
        gameObject.GetComponent<Image>().enabled = false;
        halfDoor.GetComponent<Image>().enabled = false;
        door.GetComponent<Animator>().Play("door_open");
        doorSound.Play(0);
        Debug.Log("Play doorOpen");
        
        // 불 켜짐, 캐릭터 표시
        yield return new WaitForSeconds(1.5f);
        lightSwitchSound.Play(0);
        shalalaSound.Play(0);
        door.GetComponent<Image>().enabled = false;
        background.GetComponent<Image>().enabled = false;
        GameManager.AddSelectedParts();
    }

    void Start()
    {
        // 투명배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;

        // var audioSources = GetComponent<AudioSource>();
        AudioSource[] aSources = GetComponents<AudioSource>();
        keySound = aSources[0];
        lightSwitchSound = aSources[1];
        shalalaSound = aSources[2];
        doorSound = door.GetComponent<AudioSource>();

        background.GetComponent<Image>().enabled = true;
        door.GetComponent<Image>().enabled = true;
        halfDoor.GetComponent<Image>().enabled = true;
        gameObject.GetComponent<Image>().enabled = true;

        targetPosition = new Vector3(-1, transform.position.y, 0);
    }

    void Update()
    {
        if (isScoreButtonClicked)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 70.0f * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("스페이스 키 누름");
            SceneManager.LoadScene("Start Scene");
        }       
    }
}
