using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public string mName, mDesc;
    public int hp, dmg;
    private bool isAttacked = false;
    private Vector2 knockback_pos;
    private void OnTriggerStay2D(Collider2D col)
    {        
        if (col.gameObject.name == "Blade" && !isAttacked && GameObject.Find("Player").GetComponent<My_Player>().canAttack)
        {
            Attacked();
        }
    }

    public void Attacked()
    {
        knockback_pos = (Vector2)transform.position + new Vector2(0.5f, 0);
        isAttacked = true;
    }
    private void Update()
    {
        if (isAttacked)
        {
            transform.position = Vector2.Lerp(transform.position, knockback_pos, 0.15f);
            if ((Vector2)transform.position == knockback_pos)
                isAttacked = false;
        }
        if (Input.GetKeyDown(KeyCode.M))        
            Attacked();
    }
}
