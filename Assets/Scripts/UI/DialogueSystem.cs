using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour 
{

	public GameObject[] objectsToDeactivate;
	public GameObject dialogueBox;
	public Text dialogueText;
	public string[] dialogueLines;
	public bool startOnAwake;


	private PauseMenu pauseMenu;
	private int currentLine;


	public void NextLine()
	{
		currentLine++;
		if (currentLine >= dialogueLines.Length)
		{
			EndDialogue();
		}
		else
		{
			dialogueText.text = dialogueLines[currentLine];
		}
	}


	void Awake()
	{
		pauseMenu = FindObjectOfType<PauseMenu>();
		if (startOnAwake)
		{
			StartDialogue();
		}
	}


	void StartDialogue()
	{
		dialogueBox.SetActive(true);
		pauseMenu.enabled = false;
		foreach (GameObject objectToDeactivate in objectsToDeactivate)
		{
			objectToDeactivate.SetActive(false);
		}
		currentLine = 0;
		dialogueText.text = dialogueLines[currentLine];
	}


	void EndDialogue()
	{
		dialogueBox.SetActive(false);
		pauseMenu.enabled = true;
		foreach (GameObject objectToDeactivate in objectsToDeactivate)
		{
			objectToDeactivate.SetActive(true);
		}
	}
}
