using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static Draggable d;
    List<Draggable> cardsOnTabletop = new List<Draggable>();
    List<string> cardsOnTabletopNames = new List<string>();

    bool haveDoorCard = false;
    bool haveEvaCard = false;
    bool haveMeetCard = false;
    bool haveCloseCard = false;
    bool haveTheCard = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        // Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        // if (d != null)
        // {
        //     d.placeholderParent = this.transform;
        // }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        // if (d != null && d.placeholderParent == this.transform)
        // {
        //     d.placeholderParent = d.parentToReturnTo;
        // }
    }

    public void OnDrop(PointerEventData eventData)
    {
        d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }

        //  if (name == "SpeechTabletop")
        //   {
        // cardsOnTabletopNames.Add(d.name);
        //      cardsOnTabletop.Add(d);

        //  print(cardsOnTabletop.Count);
        //   for (int i = 0; i < cardsOnTabletopNames.Count; i++)
        // print(i + " ==== " + cardsOnTabletopNames[i]);
        //   }
        //     else if (name == "SpeechHand")
        //  {
        //  cardsOnTabletopNames.Remove(d.name);
        //    cardsOnTabletop.Remove(d);

        //print(cardsOnTabletop.Count);
        //   for (int i = 0; i < cardsOnTabletopNames.Count; i++)
        //      print(i + " ==== " + cardsOnTabletopNames[i]);
        //   }

        // if (d.name == "DoorCard(Clone)" && name == "ActionHand")
        // {
        //     //print("test2");
        //     if (haveDoorCard == false)
        //     {
        //         d.transform.SetParent(GameControl.actionHand.transform);
        //         d.parentToReturnTo = GameControl.actionHand.transform;

        //         Academy.characterCards.RemoveAt(8);
        //         Academy.CharacterCardsReturn();
        //         Player.AddDoorCard();
        //         Fairy.cards.RemoveAt(8);
        //         haveDoorCard = true;
        //         GameObject canvasCode = GameObject.Find("CanvasCode");
        //         Academy canvasCodeScript = canvasCode.GetComponent<Academy>();
        //         canvasCodeScript.controlButton.interactable = true;
        //     }
        // }

        if (d.name == "DoorCard(Clone)" && name == "CardHand")
        {
            //     //  print("test2");
            if (haveDoorCard == false)
            {
                //d.transform.SetParent(GameControl.cardHandPanel.transform);
                //d.parentToReturnTo = GameControl.cardHandPanel.transform;

                Academy.characterCards.RemoveAt(8);
                Academy.CharacterCardsReturn();
                Player.AddDoorCard();

                //Fairy.cards.RemoveAt(8);

                haveDoorCard = true;
                GameObject canvasCode = GameObject.Find("CanvasCode");
                Academy canvasCodeScript = canvasCode.GetComponent<Academy>();
                canvasCodeScript.controlButton.interactable = true;
            }
        }

        if (d.name == "CloseCard(Clone)" && name == "CardHand")
        {
            if (haveCloseCard == false)
            {
                Player.AddCloseCard();

                haveCloseCard = true;
                GameObject canvasCode = GameObject.Find("CanvasCode");
                Academy canvasCodeScript = canvasCode.GetComponent<Academy>();
                canvasCodeScript.controlButton.interactable = true;
            }
        }

        if (d.name == "TheCard(Clone)" && name == "CardHand")
        {
            if (haveTheCard == false)
            {
                Player.AddCloseCard();

                haveTheCard = true;
                GameObject canvasCode = GameObject.Find("CanvasCode");
                Academy canvasCodeScript = canvasCode.GetComponent<Academy>();
                canvasCodeScript.controlButton.interactable = true;
            }
        }


        if (d.name == "EvaCard(Clone)" && name == "CardHand")
        {
            print(haveEvaCard);
            if (haveEvaCard == false)
            {
                // print("test2");
                // d.transform.SetParent(GameControl.speechHand.transform, false);
                // d.parentToReturnTo = GameControl.speechHand.transform;

                // Academy.fairy.SetActive(false);
                // Academy.dialogue.text = "";

                Academy.characterCards.RemoveAt(3);
                Academy.CharacterCardsReturn();
                Player.AddEvaCard();
                //Student06.cards.RemoveAt(3);
                haveEvaCard = true;
                GameObject canvasCode = GameObject.Find("CanvasCode");
                Academy canvasCodeScript = canvasCode.GetComponent<Academy>();
                canvasCodeScript.controlButton.interactable = true;
            }
        }

        if (d.name == "MeetCard(Clone)" && name == "CardHand")
        {
            if (haveMeetCard == false)
            {
                // print("test2");
                //  d.transform.SetParent(GameControl.speechHand.transform, false);
                //  d.parentToReturnTo = GameControl.speechHand.transform;

                // Academy.fairy.SetActive(false);
                // Academy.dialogue.text = "";

                Academy.characterCards.RemoveAt(16);
                Academy.CharacterCardsReturn();
                Player.AddMeetCard();
                //   Dino.cards.RemoveAt(16);
                haveMeetCard = true;
                GameObject canvasCode = GameObject.Find("CanvasCode");
                Academy canvasCodeScript = canvasCode.GetComponent<Academy>();
                canvasCodeScript.controlButton.interactable = true;
                Academy.DinoCardsDisappear();
            }
        }
    }
    public void playAudio()
    {
        StartCoroutine(Play());
    }
    IEnumerator Play()
    {
        if (d != null)
        {
            int children = transform.childCount;
            for (int i = 0; i < children; ++i)
            {
                SoundManager.playWordSound(transform.GetChild(i).GetComponent<Draggable>().audioClip);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    // public void SpeechReturnCardsToHand()
    // {
    //     int children = transform.childCount;
    //     for (int i = 0; i < children; ++i)
    //     {
    //         transform.GetChild(0).transform.SetParent(GameControl.speechHand.transform, false);
    //     }
    // }

    // public void ReturnActionCardsToHand()
    // {
    //     int children = transform.childCount;
    //     for (int i = 0; i < children; ++i)
    //     {
    //         transform.GetChild(0).transform.SetParent(GameControl.actionHand.transform, false);
    //     }
    // }

    public void ReturnPlayerCardsToHand()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(0).transform.SetParent(GameControl.cardHandPanel.transform, false);
        }
    }
}
