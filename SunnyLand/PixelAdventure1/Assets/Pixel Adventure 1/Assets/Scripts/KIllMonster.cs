using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIllMonster : MonoBehaviour
{
    private Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //string name_monster = collision.attachedRigidbody.gameObject.name;
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(GameObject.Find("Enemy"));
            
        }
    }
}
