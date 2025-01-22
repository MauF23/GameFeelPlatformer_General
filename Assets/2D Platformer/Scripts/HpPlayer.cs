
using Platformer;
using UnityEngine;
using DG.Tweening;

public class HpPlayer : HpBase
{
	public PlayerController playerController;
	public GameManager gameManager;
	private const float KNOCK_FORCE = 250f;

	//Variables del Tween Efecto de daño
	[Header("Tween Parameters")]
	public SpriteRenderer spriteRenderer; //Referencia al sprite del jugador
	public Color damageColor;
	public float damageTweenTime;
	public int damageTweenLoops;
	public int inmuneLayer = 6; //layer de inmunidad, no interactúa con el enemigo
	public int defaultLayer = 0; //layer predeterminado, interactúa con el enemigo
	private bool canTakeDamage = true; //Hacer que el jugador reciba daño minetras no esté en tween

	protected override void Start()
	{
		base.Start();
		if (playerController == null)
		{
			playerController = GetComponent<PlayerController>();
		}
		EnableDamage();
	}

	public override void RemoveHp(int amount)
	{
		//Regresar de la función si no se puede tomar daño
		if (!canTakeDamage) //canTakeDamage == false
		{
			return;
		}

		base.RemoveHp(amount);
		Vector2 knockbackForce = playerController.facingRight ? (Vector2.left * KNOCK_FORCE) : (Vector2.right * KNOCK_FORCE);
		playerController.Knockback(knockbackForce);
		playerController.Knockback(Vector2.up * (KNOCK_FORCE / 2));
		spriteRenderer.DOColor(damageColor, (damageTweenTime / damageTweenLoops))
			.SetLoops(damageTweenLoops, LoopType.Yoyo)
			.OnStart(DisableDamage)
			.OnComplete(EnableDamage);
	}

	protected override void Death()
	{
		base.Death();
		playerController.deathState = true;
		gameManager?.GameOver();
	}

	public override void Revive()
	{
		base.Revive();
		playerController.deathState = false;
	}

	private void EnableDamage()
	{
		canTakeDamage = true;
		gameObject.layer = defaultLayer;
	}

	private void DisableDamage()
	{
		canTakeDamage = false;
		gameObject.layer = inmuneLayer;
	}
}

