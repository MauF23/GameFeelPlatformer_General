using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageEffect : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  public float fadeTime;

  [Tooltip("introducir número par para que regrese al color original")]
  public int loops;
  public KeyCode debugKey;

  void Update()
  {
    if (Input.GetKeyDown(debugKey))
    {
      spriteRenderer.DOColor(Color.red, fadeTime).SetLoops(loops, LoopType.Yoyo);
    }
  }
}
