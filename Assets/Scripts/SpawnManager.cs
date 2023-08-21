using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
  [SerializeField]
  private GameObject _enemyPrefab;
  [SerializeField]
  private GameObject _enemyContainer;
  [SerializeField]
  private GameObject _tripleShotPrefab;
  [SerializeField]
  private GameObject _speedBoostPrefab;
  [SerializeField]
  private GameObject _shieldBoostPrefab;

  private bool _stopSpawning = false;

  void Start() {
    StartCoroutine(SpawnEnemyRoutine());
    StartCoroutine(SpawnPowerupRoutine());
  }

  void Update() {
      
  }

  IEnumerator SpawnEnemyRoutine() {
    while (!_stopSpawning) {
      Vector3 startPos = new Vector3(Random.Range(-9.0f, 9.0f), 11.0f, 0);
      GameObject newEnemy = Instantiate(_enemyPrefab, startPos, Quaternion.identity);
      newEnemy.transform.parent = _enemyContainer.transform;
      yield return new WaitForSeconds(Random.Range(1, 4));
    }
  }

  IEnumerator SpawnPowerupRoutine() {
    while (!_stopSpawning) {
      Vector3 startPos = new Vector3(Random.Range(-9.0f, 9.0f), 11.0f, 0);
      // get random number from 0-2 to determine which powerup to spawn.
      int randPowerup = Random.Range(0, 3);

      switch (randPowerup) {
        case 0:
          Instantiate(_tripleShotPrefab, startPos, Quaternion.identity);
          break;
        case 1:
          Instantiate(_speedBoostPrefab, startPos, Quaternion.identity);
          break;
        case 2:
          Instantiate(_shieldBoostPrefab, startPos, Quaternion.identity);
          break;
        default:
          Debug.Log("An error occurred in SpawnPowerupRoutine()");
          break;
      }

      yield return new WaitForSeconds(Random.Range(7, 12));
    }
  }

  public void OnPlayerDeath() {
    _stopSpawning = true;
  }
}
