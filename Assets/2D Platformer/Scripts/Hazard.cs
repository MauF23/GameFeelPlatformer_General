using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		HpPlayer hpPlayer = collision.gameObject.GetComponent<HpPlayer>();
		hpPlayer?.RemoveHp(hpPlayer.maxHp);
	}
}

