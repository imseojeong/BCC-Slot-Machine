using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lever : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float currentPositionX; //현재 위치(x) 저장
    float currentPositionY; //현재 위치(y) 저장
    float currentPositionZ; //현재 위치(z) 저장

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        currentPositionX = transform.localPosition.x;
        currentPositionY = transform.localPosition.y;
        currentPositionZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeverClickHandler() {
        Debug.Log("On Click");
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
