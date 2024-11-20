using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Ribbon : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public Material mat;
    public GameObject lightEffect;
    public GameObject candleLight;
    public GameObject cakeTopper;
    public GameObject envelopeTopBase;
    public GameObject envelopeBody;
    public GameObject envelopeTop;
    public GameObject letterPaper;
    public TMP_Text scoreText;
    public GameObject[] cakes = new GameObject[4];
    AudioSource envelopeSound;
    AudioSource checkSound;
    RectTransform rectTransform;
    public float ribbonScale = 1.0f;
    public float ribbonAngle = 0;
    public float ribbonVelocity = 0.5f;
    
    public static bool isRibbonClicked;
    public static bool isRibbonHovered;
    public static bool isRibbonStopped;
    public static bool isEnvelopeOpened;
    public static bool isLetterPaperMoved;
    public static bool isScoreDisplayed;

    byte scoreTextColorAlpha = 0;
    public byte scoreTextColorAlphaVelocity = 5;

    public int score2ndMin = 90; // 2등: 95, 90
    public int score3rdMin = 70;  // 3등: 85, 80, 75, 70

    int rank = 0;

    // 마우스오버 시 리본 커지는 이벤트
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter ribbon");
        //rectTransform.localScale = new Vector2(1.0f, 1.0f);
        rectTransform.rotation = Quaternion.Euler(0f, 0f, 0f); 
        isRibbonHovered = true;
        checkSound.Play(0);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit ribbon");
        isRibbonHovered = false;
    }

    public void RibbonClickHandler()
    {
        isRibbonClicked = true;
        Debug.Log("isRibbonClicked: "+isRibbonClicked);
        envelopeTop.GetComponent<Animator>().Play("envelope_top_open");
        envelopeSound.Play(0);

        // 리본 클릭했을 때 촛불, 효과 실행
        StartCoroutine(setTimeOutClickRibbon());

        GetComponent<Image>().enabled = false;
        GetComponent<Button>().enabled = false;
    }

    IEnumerator setTimeOutClickRibbon()
    {
        yield return new WaitForSeconds(0.850f); // 열리기 기다림
        isEnvelopeOpened = true;
        envelopeTopBase.GetComponent<Image>().enabled = true;
        envelopeTop.GetComponent<Image>().enabled = false;

        yield return new WaitForSeconds(0.2f); // 편지지 올라가기 기다렸다가, *잠깐 멈추기(멈추자마자 envelopeBody 눈 끄기)*
        isEnvelopeOpened = false;
        envelopeBody.GetComponent<Image>().enabled = false;


        yield return new WaitForSeconds(0.2f); // 편지지 올라가고 잠깐 멈췄다가, *내려가기*
        isLetterPaperMoved = true;

        yield return new WaitForSeconds(0.2f); // 편지지 내려가기 기다렸다가, *촛불, 불꽃효과 등장* //TODO: 점수 등장
        isLetterPaperMoved = false;
        isScoreDisplayed = true;
        candleLight.GetComponent<Image>().enabled = true;
        lightEffect.GetComponent<Image>().enabled = true;
        foreach(GameObject cake in cakes)  // 케이크 흑백처리
            cake.GetComponent<Image>().material = mat;
        Debug.Log("Play candleLight");
        if (GameManager.score == 100)
        {
            rank = 1;
            candleLight.GetComponent<RectTransform>().anchoredPosition = new Vector2(138f, 131f);
            lightEffect.GetComponent<RectTransform>().anchoredPosition = new Vector2(138f, 103f);
        }
        else if (GameManager.score >= score2ndMin)
        {
            rank = 2;
            candleLight.GetComponent<RectTransform>().anchoredPosition = new Vector2(401.7f, 8.4f);
            lightEffect.GetComponent<RectTransform>().anchoredPosition = new Vector2(401.7f, -19.96f);
        }
        else if (GameManager.score >= score3rdMin)
        {
            rank = 3;
            candleLight.GetComponent<RectTransform>().anchoredPosition = new Vector2(624.3f, -67.8f);
            lightEffect.GetComponent<RectTransform>().anchoredPosition = new Vector2(624.3f, -100f);
        }
        else
        {
            rank = 4;
            candleLight.GetComponent<RectTransform>().anchoredPosition = new Vector2(825.7f, -166f);
            lightEffect.GetComponent<RectTransform>().anchoredPosition = new Vector2(825.7f, -194f);
            cakeTopper.GetComponent<Image>().enabled = true;
        }
        cakes[rank-1].GetComponent<Image>().material= null;
    }

    public void ToggleRibbonStopped() {
        isRibbonStopped = !isRibbonStopped;
    }

    void Start()
    {
        // 투명부분 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
        AudioSource[] aSources = GetComponents<AudioSource>();
        rectTransform= GetComponent<RectTransform>();

        envelopeSound = aSources[0];
        checkSound = aSources[1];

        isRibbonClicked = false;
        isRibbonHovered = false;
        isRibbonStopped = false;
        isEnvelopeOpened = false;
        isScoreDisplayed = false;

        candleLight.GetComponent<Image>().enabled= true;
        cakeTopper.GetComponent<Image>().enabled= false;
        lightEffect.GetComponent<Image>().enabled= true;
        envelopeTopBase.GetComponent<Image>().enabled = false;

        scoreText.faceColor = new Color32(176, 112, 140, 0);

        InvokeRepeating("ToggleRibbonStopped",2,1.2f);
    }

    void FixedUpdate() {
        // 커졌다 작아지는 모션
        /* if(!isRibbonHovered) {
            if(ribbonScale<1.0f||ribbonScale>1.05f){
                ribbonVelocity *= -1;
            }
            //ribbonScale += Time.deltaTime * ribbonVelocity;
            //rectTransform.localScale = new Vector2(ribbonScale, ribbonScale);
        }  */

        // 왔다갔다 회전
        if(!isRibbonStopped) {
            if(!isRibbonHovered) {
                if(ribbonAngle < -5.0f || ribbonAngle > 5.0f){
                    ribbonVelocity *= -1;
                }
                ribbonAngle += Time.deltaTime * ribbonVelocity;
                rectTransform.rotation = Quaternion.Euler(0f, 0f, ribbonAngle);  
            } 
        }

        if(isScoreDisplayed) return; // 편지지 모션 두 번 실행 방지

        Vector3 currentLetterPaperPosition = letterPaper.transform.position;
        Vector3 currentScoreTextPosition = scoreText.transform.position;
        if(isEnvelopeOpened) {
            letterPaper.transform.position = Vector3.MoveTowards(currentLetterPaperPosition, new Vector3(currentLetterPaperPosition.x, currentLetterPaperPosition.y + 0.2f, 0), Time.deltaTime * 10000);
            scoreText.transform.position = Vector3.MoveTowards(currentScoreTextPosition, new Vector3(currentScoreTextPosition.x, currentScoreTextPosition.y + 0.2f, 0), Time.deltaTime * 10000);
        }

        if(!isLetterPaperMoved) return; //편지지 아직 위로 안움직엿으면 리턴
        letterPaper.transform.position = Vector3.MoveTowards(currentLetterPaperPosition, new Vector3(currentLetterPaperPosition.x, currentLetterPaperPosition.y - 0.2f, 0), Time.deltaTime * 10000);
        scoreText.transform.position = Vector3.MoveTowards(currentScoreTextPosition, new Vector3(currentScoreTextPosition.x, currentScoreTextPosition.y - 0.2f, 0), Time.deltaTime * 10000);

        if(!(scoreTextColorAlpha<=255 -scoreTextColorAlphaVelocity)) return;
        scoreTextColorAlpha += scoreTextColorAlphaVelocity;
        scoreText.faceColor = new Color32(176, 112, 140, scoreTextColorAlpha);

    }
}