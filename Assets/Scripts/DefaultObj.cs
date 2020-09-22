using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultObj : MonoBehaviour
{
    private GameObject Cursor_UI;
    public string name = "";
    [TextArea]
    public string description = "";

    private void Start()
    {
        Cursor_UI = GameObject.Find("Player").GetComponent<My_Player>().Cursor_UI;
    }

    private void OnMouseEnter()
    {
        SpriteRenderer r = gameObject.GetComponent<SpriteRenderer>();
        r.color = new Color(r.color.r - 0.1f, r.color.g - 0.1f, r.color.b - 0.1f);
        GameObject.Find("Player").GetComponent<My_Player>().SetTarget(gameObject.name);
    }
    private void OnMouseOver()
    {
        Cursor_UI.transform.GetChild(0).GetComponent<Text>().text = description;
        Cursor_UI.transform.position = Input.mousePosition;
        Cursor_UI.SetActive(true);
    }
    private void OnMouseExit()
    {
        SpriteRenderer r = gameObject.GetComponent<SpriteRenderer>();
        r.color = new Color(r.color.r + 0.1f, r.color.g + 0.1f, r.color.b + 0.1f);
        GameObject.Find("Player").GetComponent<My_Player>().OutFocus();
        Cursor_UI.SetActive(false);
    }
}
