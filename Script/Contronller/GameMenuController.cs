using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    public void playBtn()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
