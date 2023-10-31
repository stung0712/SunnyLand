using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    [SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("trap"))
        {
            
            Die();
        }

    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        
    }

    private void RestrartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
