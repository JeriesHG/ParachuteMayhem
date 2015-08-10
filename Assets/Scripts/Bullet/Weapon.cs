using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

		public enum WeaponType
		{
				Default,
				Shotgun
		}
		;

		public WeaponType weaponType;
		public Bullet bullet;
		public float clipSize;
		public float shotsLeft;
		public bool infinite;
		public float bulletCount = 2;
		public float bulletRandomnes;
		public float bulletSpread;
		public float bulletSpacing;
		public float fireRate;
		public AudioClip shootSound;
		

		// Use this for initialization
		void Start ()
		{
				clipSize = shotsLeft;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
