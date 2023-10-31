using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectSoundEffect;
    private int cherry = 0;
    [SerializeField] private Text cherryText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherry++;
            cherryText.text = "Cherry: "+ cherry;
        }
    }

}
