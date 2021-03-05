using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCUI : MonoBehaviour
{
    public Text NPCTextPanel;

    public void UpdateNPCText(string NPCText)
    {
        NPCTextPanel.text = NPCText;
    }

}

