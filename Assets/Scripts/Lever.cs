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

    public void LeverClickHandler() {
        StartCoroutine(Example2());
    }
    IEnumerator Example2()
    {
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(1.0f);
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
