using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void SwipeTest()
    {
        SceneManager.LoadScene("SwipeTest");
    }

    public void RandomLevelTest()
    {
        SceneManager.LoadScene("RandomLevelTest");
    }

    public void SpellRules()
    {
        SceneManager.LoadScene("SpellRules");
    }

    public void Test3D()
    {
        SceneManager.LoadScene("3DTest");
    }
}
