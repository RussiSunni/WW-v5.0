
using UnityEngine;
using UnityEngine.UI;

public class CardMoveToggle : MonoBehaviour
{
    public static Toggle toggle;
    public Text m_Text;

    void Start()
    {
        //Fetch the Toggle GameObject
        toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        toggle.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(toggle);
        });
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        if (toggle.isOn)
            CardPhraseToggle.toggle.isOn = false;
        // Debug.Log(toggle.isOn);
    }
}