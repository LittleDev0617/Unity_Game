using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public GameObject Story_UI;
    [TextArea]
    public string[] texts;
    private int index = 0;
    private Text Dialogue_text;

    private void Start()
    {
        Dialogue_text = Story_UI.transform.GetChild(0).GetChild(1).GetComponent<Text>();
    }
    private void ShowDialogue()
    {
        Dialogue_text.transform.parent.parent.gameObject.SetActive(true);
    }

    private IEnumerator Print(int i)
    {
        Text tmp = Dialogue_text;
        tmp.text = "";
        foreach(char a in texts[i])
        {
            tmp.text += a; 
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void PrintText(int i)
    {
        index = i;
        ShowDialogue();
        StartCoroutine(Print(i));
    }

    private void Skip()
    {
        StopAllCoroutines();
        Dialogue_text.text = texts[index];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Dialogue_text.text.Length > 5 && Dialogue_text.gameObject.activeSelf)
        {
            Skip();
        }
    }
}
