using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text dialogueText;

    public void ShowDialogue(string dialogue) {
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }

}
