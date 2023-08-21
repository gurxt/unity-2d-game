using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  // movement global variables
  public float speed = 10.0f;
  public float horizontalInput;
  public float verticalInput;

  // laser prefab
  [SerializeField]
  private GameObject _laserPrefab;
  [SerializeField]
  private float _fireRate;
  private float _canFire = -1.0f;

  // enemy prefab
  [SerializeField]
  private GameObject _enemyPrefab;
  
  // lives
  [SerializeField] 
  private int _lives = 3;

  // spawn manager
  private SpawnManager _spawnManager;

  // triple shot variables
  [SerializeField] 
  private GameObject _tripleShotPrefab;
  [SerializeField] 
  private bool _tripleShotActive;

  // speed boost variables
  [SerializeField]
  private bool _speedBoostActive;

  // shield boost variables
  [SerializeField]
  private bool _shieldBoostActive;

  // shield visual component
  [SerializeField]
  private GameObject _shield;


  /* ============= BUILT IN METHODS ============== */
  void Start() {
    transform.position = new Vector3(0, 0, 0);      
    _fireRate = 0.25f;
    _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
  }

  void Update() {
    CalculateMovement();
    if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) {
      FireLaser();
    }
  }
  /* ============================================= */

  /* ============= STAND ALONE METHODS =========== */
  void FireLaser() {
    _canFire = Time.time + _fireRate;

    if (_tripleShotActive) {
      Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
    } else {
      Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    }

  }

  public void Damage() {
    if (!_shieldBoostActive) {
      _lives--;
      Debug.Log("Lives Remaining: " + _lives);
    } else {
      _shield.SetActive(false);
      _shieldBoostActive = false;
    }

    // check if out of lives - destroy object and end spawning
    if (_lives < 1) {

      if (_spawnManager != null)
        _spawnManager.OnPlayerDeath();

      Destroy(this.gameObject);
    }

  }

  public void ShieldBoostActive() {
    // turn the shield sprite on
    _shield.SetActive(true);
    _shieldBoostActive = true;
    StartCoroutine(ShieldBoostPowerDownRoutine());
  }

  IEnumerator ShieldBoostPowerDownRoutine() {
    yield return new WaitForSeconds(5.0f);
    _shield.SetActive(false);
    _shieldBoostActive = false;
  }
  public void SpeedBoostActive() {
    _speedBoostActive = true;
    StartCoroutine(SpeedBoostPowerDownRoutine());
  }

  IEnumerator SpeedBoostPowerDownRoutine() {
    yield return new WaitForSeconds(5.0f);
    _speedBoostActive = false;
  }

  public void TripleShotActive() {
    _tripleShotActive = true;
    StartCoroutine(TripleShotPowerDownRoutine());
  }

  IEnumerator TripleShotPowerDownRoutine() {
    yield return new WaitForSeconds(5.0f);
    _tripleShotActive = false;
  }

  /* ============================================= */

  /* ============= MOVEMENT METHODS ============== */
  void CalculateMovement() {
    horizontalInput = GetPositionX();
    verticalInput = GetPositionY();

    Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
    transform.Translate(direction * speed * (_speedBoostActive ? 1.75f : 1.0f) * Time.deltaTime); // 50% speed boost
  }

  float GetPositionX() {
    horizontalInput = Input.GetAxis("Horizontal");

    if (transform.position.x >= 11.3f) {
      transform.Translate(-22.5f, 0, 0);
      return 0.0f;
    }

    if (transform.position.x <= -11.3f) {
      transform.Translate(22.5f, 0, 0);
      return 0.0f;
    }

    return horizontalInput;
  }

  float GetPositionY() {
    verticalInput = Input.GetAxis("Vertical");

    if (transform.position.y >= 11.1f) {
      transform.Translate(0, -13.1f, 0);
      return 0.0f;
    }

    if (transform.position.y <= -2.0f) {
      transform.Translate(0, 13.0f, 0);
      return 0.0f;
    }

    return verticalInput;
  }
  /* ============================================= */

}
