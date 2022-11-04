using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text dialogueText;

    int duration;

    private void Awake()
    {
       // dialogueBox.SetActive(true);
    }
    public void ShowDialogue(string dialogue, int displayTime) {

        duration = displayTime;

        Debug.Log("Starting Dialog");

        dialogueText.text = dialogue;

        StartCoroutine(pause());

        Debug.Log("Ending Dialog");
    }
    IEnumerator pause() // Unity makes me do this to wait for seconds
    {
        
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(duration);
        dialogueBox.SetActive(false);

        Debug.Log("Wait is over");
    }

}
