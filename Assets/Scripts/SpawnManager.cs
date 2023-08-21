using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
  [SerializeField]
  private GameObject _enemyPrefab;
  [SerializeField]
  private GameObject _enemyContainer;

  private bool _stopSpawning = false;

  void Start() {
    StartCoroutine(SpawnRoutine());
  }

  void Update() {
      
  }

  IEnumerator SpawnRoutine() {
    while (!_stopSpawning) {
      Vector3 startPos = new Vector3(Random.Range(-9.0f, 9.0f), 11.0f, 0);
      GameObject newEnemy = Instantiate(_enemyPrefab, startPos, Quaternion.identity);
      newEnemy.transform.parent = _enemyContainer.transform;
      yield return new WaitForSeconds(2.0f);
    }
  }

  public void OnPlayerDeath() {
    _stopSpawning = true;
  }
}
