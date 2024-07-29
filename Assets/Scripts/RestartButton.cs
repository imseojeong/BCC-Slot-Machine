using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartButtonClickHandler()
    {
        SceneManager.LoadScene("Start Scene");
        Debug.Log("Click RestartButton");
    }

    void Start()
    {
        // ������ ��� ����
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }
}
