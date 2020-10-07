using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelController : MonoBehaviour
{
    public void RestartScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu ()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
