using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartButtonClickHandler()
    {
        SceneManager.LoadScene("Play Scene");
        Debug.Log("click StartButton");
    }

    private void OnMouseOver()
    {
        Debug.Log("over StartButton");
        this.transform.Rotate(0, 0, 30);
        this.transform.Rotate(0, 0, -30);
    }
}
