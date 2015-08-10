using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour {

	//Player Related
	public List<GameObject> weapons;
	public float hitpoints = 10;
	public KeyCode changeWeapon = KeyCode.E;
	public KeyCode shoot = KeyCode.Mouse0;

	[HideInInspector]
	public int selectedWeapon = 0;

	void Awake(){
		weapons = new List <GameObject> ();
		weapons.Add ((GameObject)Instantiate (Resources.Load ("Weapons/weapon_default") as GameObject));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
