using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
  [SerializeField] private TMP_Text cherriesCount;
  [SerializeField] private AudioSource collectSound;


   private void Update()
  {
    cherriesCount.text = "VYŠNIOS: " + StartMenu.pi.cherries;    
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.CompareTag("Cherry"))
    {
      collectSound.Play();
      Destroy(collision.gameObject);
     StartMenu.pi.cherries++;
    }
  }
}
