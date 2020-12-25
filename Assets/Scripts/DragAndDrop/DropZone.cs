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

        if (name == "SpeechTabletop")
        {
            // cardsOnTabletopNames.Add(d.name);
            cardsOnTabletop.Add(d);

            //  print(cardsOnTabletop.Count);
            //   for (int i = 0; i < cardsOnTabletopNames.Count; i++)
            // print(i + " ==== " + cardsOnTabletopNames[i]);
        }
        else if (name == "SpeechHand")
        {
            //  cardsOnTabletopNames.Remove(d.name);
            cardsOnTabletop.Remove(d);

            //print(cardsOnTabletop.Count);
            //   for (int i = 0; i < cardsOnTabletopNames.Count; i++)
            //      print(i + " ==== " + cardsOnTabletopNames[i]);
        }

        if (d.name == "DoorCard(Clone)" && name == "ActionHand")
        {
            if (haveDoorCard == false)
            {
                d.transform.SetParent(GameControl.actionHand.transform, false);
                d.parentToReturnTo = GameControl.actionHand.transform;

                Academy.characterCards.RemoveAt(8);
                Academy.CharacterCardsReturn();
                Player.AddDoorCard();
                Fairy.cards.RemoveAt(8);
                haveDoorCard = true;
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
    public void SpeechReturnCardsToHand()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(0).transform.SetParent(GameControl.speechHand.transform, false);
        }
    }

    public void ReturnActionCardsToHand()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(0).transform.SetParent(GameControl.actionHand.transform, false);
        }
    }
}
