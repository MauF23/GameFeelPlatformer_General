using DG.Tweening;
using UnityEngine;

public class HpEnemy : HpBase
{
	private float deathTweenTime = 0.3f;
	public Rigidbody2D rigidbody;
	public SpriteRenderer spriteRenderer;
	protected override void Death()
	{
		base.Death();
		rigidbody.velocity = Vector2.zero;
		//transform.DOScale(0, deathTweenTime).OnComplete(VanishEnemy);
		spriteRenderer.DOFade(0, deathTweenTime).OnComplete(VanishEnemy);
	}

	private void VanishEnemy()
	{
		gameObject.SetActive(false);
	}
}
