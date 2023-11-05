using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
  [SerializeField] private AudioSource deathSound;
  private Animator anim;
  private Rigidbody2D rb;
  [SerializeField] private TMP_Text lifesLeft;
  // private static PlayerInfo pi =  new();
  
  private void Start()
  {
  
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    lifesLeft.text = "GYVYBĖS: " + StartMenu.pi.life;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.CompareTag("Trap"))
    {
      deathSound.Play();
      rb.bodyType = RigidbodyType2D.Static;
      anim.SetTrigger("death");
      StartMenu.pi.life--;
      Die();     
    }
  }

  private void Die() 
  {
   
  
    if(StartMenu.pi.life < 0)
    {
      Invoke(nameof(EndGame), 1f);
    }
    else
    {
       Invoke(nameof(RestartLevel), 1f); 
    }
   
  }

  private void RestartLevel() 
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  private void EndGame()
  {
     SceneManager.LoadScene(3);
  }
}
