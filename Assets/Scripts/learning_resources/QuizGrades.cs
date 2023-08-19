using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizGrades : MonoBehaviour {
  // Start is called before the first frame update
  [SerializeField]
  private float quiz1;
  [SerializeField]
  private float quiz2;
  [SerializeField]
  private float quiz3;
  [SerializeField]
  private float quiz4;
  [SerializeField]
  private float quiz5;

  void Start() {
    quiz1 = Random.Range(25.0f, 100.0f);
    quiz2 = Random.Range(25.0f, 100.0f);
    quiz3 = Random.Range(25.0f, 100.0f);
    quiz4 = Random.Range(25.0f, 100.0f);
    quiz5 = Random.Range(25.0f, 100.0f);

    float average = Mathf.Floor((quiz1 + quiz2 + quiz3 + quiz4 + quiz5) / 5.0f * 100.0f) / 100.0f;

    if (average <= 50.0f) {
      Debug.Log("You are all failures: " + average + "%");
    } else if (average <= 75.0f) {
      Debug.Log("You are all average: " + average + "%");
    } else {
      Debug.Log("You are all genius': " + average + "%");
    }
  }
}
