using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

	//Enemy Positioning
	public float startXPos = -6f;
	public float startYPos = 5f;
	public bool isFalling = false;
	float moveDirection = 1.0f;
	float  fallingDirection = -1f;
	public float moveSpeed = 2f;

	public string enemyName = "";
	public double hitpoints = 5f;
	public int pointsWorth = 0;

	public List<GameObject> weapons;
	public int defaultAmmo = 0;
	public float maxShotInterval = 1f;

	Vector3 moveAmount;
	private Weapon currentWeapon;
	[HideInInspector]
	public int
		selectedWeapon = 0;

	private Animator animator;
	

	void Start ()
	{
		weapons = new List <GameObject> ();
		animator = GetComponent<Animator>();
		characterSettings ();


		//weapons.Add ((GameObject)Instantiate (Resources.Load ("Weapons/weapon_enemyBasic1") as GameObject));
		//InvokeRepeating ("EnemyShoot", Random.Range (0f, 1f), Random.Range (0.5f, maxShotInterval));
	}
	

	void Update ()
	{
	
		if (isFalling) {
			moveAmount.y = fallingDirection * moveSpeed * Time.deltaTime;
		} else {
			moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
		}
		transform.Translate (moveAmount);
	}
	
	void OnCollisionEnter2D (Collision2D Entity)
	{
	
		switch (Entity.gameObject.tag) {
		case "Player":
			Turret player = Entity.gameObject.GetComponent<Turret> ();
			//player.TookDamage (1);
			Damaged (1);
			break;
		case "Floor":
			isFalling = false;
			//transform.position = new Vector3(transform.position.x,-3.5f,transform.position.z);
			animator.SetBool("isFalling",false);
			break;
		}
	}

	private void characterSettings(){
		startXPos = transform.position.x;
		//if the starting position is in the right side (x>0) then it should run to the left
		//else it will flip the sprite animation
		if (startXPos > 0) {
			moveDirection *=-1;
		} else {
			//flipping animation
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	
	public bool Damaged (double damage)
	{
		hitpoints -= damage;
		if (hitpoints < 1) {
			Destroy (gameObject);
			return true;
		}
		return false;
	}
	
	void EnemyShoot ()
	{
		currentWeapon = ((GameObject)weapons [selectedWeapon]).GetComponent<Weapon> ();
		for (int i = 0; i<currentWeapon.bulletCount; i++) {
			Quaternion target = Quaternion.identity;
			target.eulerAngles = new Vector3 (currentWeapon.bullet.bulletSpeed, currentWeapon.bulletSpread * (i - 1.8f));
			Vector3 newVector = transform.position;
			newVector.y = transform.position.y - GetComponent<BoxCollider2D> ().size.y;
			Bullet bullet = (Bullet)Instantiate (currentWeapon.bullet, newVector, target);
			bullet.enemyBullet = true;
			bullet.GetComponent<Rigidbody2D> ().AddForce (bullet.transform.forward * bullet.bulletSpeed);
		}
	}
}
