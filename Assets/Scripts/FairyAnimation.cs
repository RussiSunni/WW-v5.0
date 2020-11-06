using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FairyAnimation : MonoBehaviour
{
    static Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public static void CorrectAnswer()
    {
        animator.SetTrigger("fairyHappy");
    }

    public static void IncorrectAnswer()
    {
        animator.SetTrigger("fairyDisappointed");
    }
}