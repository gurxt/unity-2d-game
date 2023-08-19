using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats {
  public string name;
  public float fireRate;
  public int ammoCount;

  public WeaponStats(string name, float fireRate, int ammoCount) {
    this.name = name;
    this.fireRate = fireRate;
    this.ammoCount = ammoCount;

    Debug.Log(name + fireRate + ammoCount);
  }
}

public class Classes : MonoBehaviour {
  public WeaponStats blasters;
  public WeaponStats rockets;

  void Start() {
    blasters = new WeaponStats("Blasters", 0.25f, 100);
    rockets = new WeaponStats("Rockets", 1.25f, 20);
  }

  void Update() {
      
  }
}
