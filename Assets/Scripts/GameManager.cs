using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  public bool _isGameOver;

  void Update() {
    if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true) {
      SceneManager.LoadScene(1); // current game scene
    }
  }

  public void GameOver() {
    _isGameOver = true;
  }
}
