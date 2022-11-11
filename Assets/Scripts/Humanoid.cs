using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour {

	// Events
	public delegate void PlayerHealthChangedEvent(float dmgAmnt, float currHealth);
	public event PlayerHealthChangedEvent OnPlayerHealthChanged;
	public delegate void PlayerPointsChangedEvent(float changeAmnt, float currPoints);
	public event PlayerPointsChangedEvent OnPlayerPointsChanged;
	public delegate void PlayerDiedEvent(float lastDamageAmnt);
	public event PlayerDiedEvent OnPlayerDied;
	public delegate void PlayerMaxHealthChanged(float changeAmnt, float currMaxHealth);
	public event PlayerMaxHealthChanged OnPlayerMaxHealthChanged;

	// Player data
	public float health { get; private set; }
	public float maxHealth { get; private set; }

	public float points { get; private set; }

	public GameManager.PlayerState humanoidState = GameManager.PlayerState.Alive;

	public void AddPoints(float points) {
		this.points += points;
		OnPlayerPointsChanged(points, this.points);
	}

	public void RemovePoints(float points) {
		this.points -= points;
		OnPlayerPointsChanged(points, this.points);
	}

	public void TakeDamage(float amnt) {
		if (humanoidState != GameManager.PlayerState.Dead &&
			humanoidState != GameManager.PlayerState.Invincible) {
			health -= amnt;
			OnPlayerHealthChanged(amnt, health);
			if (health <= 0) {
				health = 0;
				humanoidState = GameManager.PlayerState.Dead;
				OnPlayerDied(amnt);
			}
		}
	}

	public void Heal(float amnt) {
		if (humanoidState != GameManager.PlayerState.Dead && health < maxHealth) {
			health += amnt;
			if (health > maxHealth)
				health = maxHealth;
			OnPlayerHealthChanged(amnt, health);
		}
	}

	public void IncreaseMaxHealth(float amnt) {
		if (humanoidState != GameManager.PlayerState.Dead) {
			maxHealth += amnt;
			health += amnt;
			OnPlayerMaxHealthChanged(amnt, maxHealth);
		}
	}

	public void DecreaseMaxHealth(float amnt) {
		if (humanoidState != GameManager.PlayerState.Dead) {
			maxHealth -= amnt;
			OnPlayerMaxHealthChanged(amnt, maxHealth);
		}
	}

}
