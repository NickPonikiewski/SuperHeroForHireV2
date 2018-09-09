using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMannager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Button ContinueBtn;

    public Animator animator;
    private Queue<string> sentences;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        ContinueBtn.gameObject.SetActive(false);
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        ContinueBtn.gameObject.SetActive(false);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            ContinueBtn.GetComponentInChildren<Text>().text = "Close";
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        ContinueBtn.gameObject.SetActive(false);
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.05f);
        }
        ContinueBtn.gameObject.SetActive(true);
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
