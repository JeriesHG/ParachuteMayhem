using UnityEngine;
using System.Collections;

public class TurretShoot : MonoBehaviour
{

	private Turret player;
	private float lastFire;
	private Weapon selectedWeapon;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Turret").GetComponent<Turret> ();
	}

	void FixedUpdate ()
	{
		if (Input.GetKey (player.shoot) && Time.time > lastFire) {
	
			selectedWeapon = ((GameObject)player.weapons [player.selectedWeapon]).GetComponent<Weapon> ();
			if (selectedWeapon.infinite || selectedWeapon.shotsLeft >= 1) {
				StartCoroutine (Fire ());
			} else {
				//if there are no bullets it will look for a weapon with bullets
				//LookForWeapon ();
				//	StartCoroutine (Fire ());
			}
			lastFire = Time.time + selectedWeapon.fireRate;
		}
	}

	IEnumerator Fire ()
	{
		yield return new WaitForSeconds (0);
		switch (selectedWeapon.weaponType) {
		case Weapon.WeaponType.Default:
			doDefaultWeapon ();
			break;
		}
			

		if (!selectedWeapon.infinite) {
			selectedWeapon.shotsLeft--;
		}
		
		
	}

	void doDefaultWeapon ()
	{
		for (int i = 0; i<selectedWeapon.bulletCount; i++) {
			Vector3 pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			pos = Camera.main.ScreenToWorldPoint (pos);        
			Quaternion q = Quaternion.FromToRotation (Vector3.up, pos - transform.position);
			Bullet go = (Bullet)Instantiate (selectedWeapon.bullet, transform.position, q);
			go.GetComponent<Rigidbody2D> ().AddForce (go.transform.up * go.bulletSpeed);	
		}
	}
}
