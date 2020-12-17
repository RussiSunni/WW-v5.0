using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
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
        // Debug.Log(gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }

        // print(d.name);
        if (d.name == "HelloCard(Clone)")
        {
            Destroy(d.gameObject);
            // Academy.dialogue.text = "You already have that one";
            Academy.dialogue.text = "";
            Academy.fairy.SetActive(false);
        }

        if (d.name == "DoorCard(Clone)")
        {
            Destroy(d.gameObject);
            GameControl.doorCard.SetActive(true);
            GameControl.DestroyCharacterCards();

            GameObject notSure = GameObject.Find("New Game Object");
            Destroy(notSure);
        }

        if (d.name == "HiCard(Clone)")
        {
            Destroy(d.gameObject);
            GameControl.hiCard.SetActive(true);
            GameControl.DestroyCharacterCards();

            // GameObject notSure = GameObject.Find("New Game Object");
            // Destroy(notSure);
            Academy.dialogue.text = "";
            Academy.fairy.SetActive(false);
        }
    }
}
