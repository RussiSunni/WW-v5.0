using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Rules");
    }

    public void SwipeTest()
    {
        SceneManager.LoadScene("SwipeTest");
    }
}
