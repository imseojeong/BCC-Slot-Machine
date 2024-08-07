using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lever : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float currentPositionX;
    float currentPositionY;
    float currentPositionZ;

    void Start()
    {
        currentPositionX = transform.localPosition.x;
        currentPositionY = transform.localPosition.y;
        currentPositionZ = transform.localPosition.z;
    }

    void Update()
    {
        // 
    }

    //레버 클릭하면 실행되는 메소드
    public void LeverClickHandler() {
        StartCoroutine(InActiveLeverButton());
    }

    IEnumerator InActiveLeverButton()
    {
        // 레버 버튼 비활성화
        GetComponent<Button>().interactable = false;
        // 1초 기다림
        yield return new WaitForSeconds(1.0f);
        // 레버 버튼 활성화
        GetComponent<Button>().interactable = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
        transform.rotation = Quaternion.Euler(0f, 0, -5f);
        transform.localPosition = new Vector3((currentPositionX + 11f), currentPositionY, currentPositionZ);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localPosition = new Vector3((currentPositionX), currentPositionY, currentPositionZ);
    }
}
