using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class My_Player : MonoBehaviour
{
    private bool isFocus = false;
    private GameObject target;
    private float aSpeed = 1;

    public bool canAttack = true;
    public int hp, dmg;
    public bool canMove = true;
    public GameObject Cursor_UI;
    public GameObject Esc_UI;
    public GameObject Target_UI;
    public Sprite OpenedChest;

    private IEnumerator ACT()
    {
        yield return new WaitForSeconds(aSpeed);
        canAttack = true;
    }
    public void AttackCoolTime()
    {
        canAttack = false;
        StartCoroutine(ACT());
    }

    public void Escape()
    {
        if (Esc_UI.activeSelf)
            Esc_UI.SetActive(false);
        else
        {
            canMove = true;
            foreach (GameObject a in GameObject.FindGameObjectsWithTag("Popup"))
            {
                a.SetActive(false);
            }
        }
    }
    public void SetTarget(string name)
    {
        isFocus = true;
        target = GameObject.Find(name);
        DisplayTarget();
    }

    public void OutFocus()
    {
        isFocus = false;
        Target_UI.SetActive(false);
    }

    private void DisplayTarget()
    {
        if(isFocus)
        {
            Target_UI.SetActive(true);
            Target_UI.transform.GetChild(0).GetComponent<Image>().sprite = target.GetComponent<SpriteRenderer>().sprite;
            Target_UI.transform.GetChild(2).GetComponent<Text>().text = target.GetComponent<DefaultObj>().name;
        }
    }

    IEnumerator FadeOut(GameObject o)
    {
        Renderer renderer = o.GetComponent<SpriteRenderer>();
        int i = 10;
        while (i > 0)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(o);
    }

    void OpenChest(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().sprite = OpenedChest;
        StartCoroutine(FadeOut(obj));        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (!(isFocus && target.GetInstanceID() == col.gameObject.GetInstanceID())) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (col.gameObject.tag == "Chest")
            {
                OpenChest(col.gameObject);
            }
            else if (col.gameObject.tag == "StoryBoard" && canMove)
            {
                canMove = false;
                int id = int.Parse(col.gameObject.name.Split('_')[1]);
                GameObject.Find("StoryManager").GetComponent<StoryManager>().PrintText(id);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Escape();
    }
}
