using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rules : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(FairyHello());
    }

    IEnumerator FairyHello()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWordSound(SoundManager.fairyHello);
    }


    public void NextScene()
    {
        SceneManager.LoadScene("Academy");
    }
}