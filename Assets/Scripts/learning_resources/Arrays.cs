using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrays : MonoBehaviour {
  // 3 ways to declare an array
  public string[] names;
  public string[] items = new string[5];
  public int[] ages = new int[] { 0, 1, 2, 3, 4 };
  void Start() {
    Array.Reverse(names);
    Debug.Log(names[names.Length - 1]);

    foreach (int age in ages) {
      Debug.Log(age);
    }
  }

  void Update() {
      
  }
}
