using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public static PlayerInfo pi;
    public static  void StartGame() 
    {
      pi = new PlayerInfo();
      SceneManager.LoadScene(1);
    }
}
