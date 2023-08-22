using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
  [SerializeField]
  private TextMeshProUGUI _scoreText;
  [SerializeField]
  private Sprite[] _livesSprites;
  [SerializeField]
  private Image _livesImg; 
  [SerializeField]
  private TextMeshProUGUI _gameOverText;
  [SerializeField]
  private TextMeshProUGUI _restartText;
  private GameManager _gameManager;

  void Start() {
    _scoreText.text = "Score: " + 0;
    _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }

  public void UpdateScore(int playerScore) {
    _scoreText.text = "Score: " + playerScore;
  }

  public void UpdateLives(int currentLives) {
    _livesImg.sprite = _livesSprites[currentLives];
  }

  public void GameOver() {
    if (_gameManager != null)
      _gameManager.GameOver();
    _restartText.gameObject.SetActive(true);
    StartCoroutine(GameOverFlicker());
  }

  IEnumerator GameOverFlicker() {
    while (true) {
      _gameOverText.gameObject.SetActive(true);
      yield return new WaitForSeconds(0.20f);
      _gameOverText.gameObject.SetActive(false);
      yield return new WaitForSeconds(0.20f);
    }
  }
}
