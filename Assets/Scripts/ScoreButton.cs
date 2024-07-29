using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreButton : MonoBehaviour
{
    public void ScoreButtonClickHandler()
    {
        SceneManager.LoadScene("Score Scene");
        Debug.Log("Click ScoreButton");
    }

    void Start()
    {
        // 투명한 배경 무시
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }

}
