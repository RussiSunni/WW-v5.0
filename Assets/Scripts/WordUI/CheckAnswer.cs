using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    public Transform A, B, C, D, E;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
    }

    public void Go()
    {       
        // Fairy
        //    if (CharacterController.gridSquare == new Vector2(3, 1) && CharacterController.playerDirectionInt == 0)
        //    {
        //        if (A.transform.GetChild(0).gameObject.name == "Hello(Clone)")
        //        {
        //            var fairyScript = GameObject.Find("Fairy").GetComponent<Fairy>();
        //            fairyScript.Exercise01();
        //        }
        //    }      

        if (Academy.cameraPos.z == -5.4f)
        {
            Debug.Log("2");
            SoundManager.playSound(SoundManager.correctSound);

            var wordUIScript = GameObject.Find("WordPanel").GetComponent<WordUI>();
            wordUIScript.ClearBlocks();

            var fairyScript = GameObject.Find("Fairy").GetComponent<Fairy>();
            fairyScript.SayOpenTheDoor();
        }


    }
}