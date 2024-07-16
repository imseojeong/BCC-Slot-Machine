using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    StartButton Button;

    public void OnClickExit()
    {
        SceneManager.LoadScene("Play Scene");
        Debug.Log("버튼 누름");
    }
}
