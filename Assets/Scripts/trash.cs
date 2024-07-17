using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class trash : MonoBehaviour
{
    public void SceneButtonClickHandler()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log(clickObject.name+" click");
        switch (clickObject.name){
            case "StartButton":
                SceneManager.LoadScene("Play Scene");
                break;
            case "ScoreButton":
                SceneManager.LoadScene("Score Scene");
                break;
            case "RestartButton":
                SceneManager.LoadScene("Start Scene");
                break;
        }
    }

    void Start()
    {
        //투명한 배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }

}
