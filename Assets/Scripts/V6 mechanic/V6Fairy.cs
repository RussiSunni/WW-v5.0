using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class V6Fairy : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator.SetBool("isJump", false);
        animator.SetBool("isHi", false);
    }

    public void NoAnimation()
    {
        animator.SetBool("isJump", false);
        animator.SetBool("isHi", false);
    }

    // public void WaveAnimation()
    // {
    //     animator.SetBool("isHi", true);
    //     //        print("hi");
    // }

    public void Animation(string word)
    {
        animator.SetBool(word, true);
        //  LetterUI.currentWordFairyAnimations.Clear();
    }

}