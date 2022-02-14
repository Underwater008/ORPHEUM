using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {
  public static CameraShake ins;

  public float ShakeTime = 2.0f;
  public float ShakeAmount = 14f;
  public float ShakeSpeed = 0.2f;
  public bool cancelShake = true;
  private Transform ThisTransform = null;
  private void Awake() {
    ins = this;
  }
  // Use this for initialization
  void Start() {
    ThisTransform = GetComponent<Transform>();

  }

  public void Shake() {
    StartCoroutine(ShakeCamera1(ShakeSpeed, ShakeAmount, ShakeTime));
  }
  /// <summary>
  /// 摄像机震动
  /// </summary>
  /// <param name="shakeStrength">震动幅度</param>
  /// <param name="rate">震动频率</param>
  /// <param name="shakeTime">震动时长</param>
  /// <returns></returns>
  public IEnumerator ShakeCamera1(float shakeStrength = 0.2f, float rate = 14, float shakeTime = 0.4f) {
    float t = 0;
    float speed = 1 / shakeTime;
    Vector3 orgPosition = transform.localPosition;
    while (t < 1) {
      t += Time.deltaTime * speed;
      transform.position = orgPosition + new Vector3(Mathf.Sin(rate * t), Mathf.Cos(rate * t), 0) * Mathf.Lerp(shakeStrength, 0, t);
      yield return null;
    }
    transform.position = orgPosition;
  }

  public IEnumerator ShakeCamera2() {
    Vector3 OrigPosition = ThisTransform.localPosition;
    float ElapsedTime = 0.0f;
    while (ElapsedTime < ShakeTime) {
      Vector3 RandomPoint = OrigPosition + Random.insideUnitSphere * ShakeAmount;
      ThisTransform.localPosition = Vector3.Lerp(ThisTransform.localPosition, RandomPoint, Time.deltaTime * ShakeSpeed);
      yield return null;
      ElapsedTime += Time.deltaTime;
    }
    ThisTransform.localPosition = OrigPosition;
  }
}