using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	public double damage = 1;
	public int bulletSpeed = 4;
	public bool enemyBullet = false;
		

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, 30);
	}
	
	void OnTriggerEnter2D (Collider2D entity)
	{
		Debug.Log ("triggered something:  " + entity.gameObject.tag);
		switch (entity.gameObject.tag) {
		case "Bullet":
			break;
		case "Enemy":
			if (!enemyBullet) {
				Enemy enemy = entity.gameObject.GetComponent<Enemy> ();
				//enemy.Damaged (damage) here
				if (enemy.Damaged (damage)&& GameObject.Find ("Turret")) {
					Debug.Log("HIT ENEMY");
					//GameObject.Find ("Turret").GetComponent<Turret> ().score += enemy.pointsWorth;
					//GameObject.Find ("Turret").GetComponent<Turret> ().updateScore ();
				}
				Destroy (gameObject);
			}
		
			break;
		case "Player":
						//if (enemyBullet) {

							//	Player player = entity.gameObject.GetComponent<Player> ();
							//	player.TookDamage (damage);
							//	Destroy (gameObject);
					//	}
			break;
		}
		if (entity.gameObject.tag.ToLower ().Contains ("wall")) {
			Destroy (gameObject);
		}
	}

	void OnBecameInvisible ()
	{
		// Destroy the bullet 
		Destroy (gameObject);
	}


}
