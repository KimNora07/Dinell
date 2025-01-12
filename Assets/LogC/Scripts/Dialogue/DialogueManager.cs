using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject dialoguePanel;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel?.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialoguePanel?.SetActive(true);
        nameText.text = dialogue.characterName;
        sentences.Clear();
        
        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        dialoguePanel?.SetActive(false);
    }
}
