﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	private Animator animator;
	//public AnimationClip attack_north, attack_south, attack_east, attack_west;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		
		if (vertical > 0)
		{
			animator.SetInteger("Direction", 2);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				animator.SetInteger("Attack", 2);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
		}
		else if (vertical < 0)
		{
			animator.SetInteger("Direction", 0);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				animator.SetInteger("Attack", 0);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("Direction", 3);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				animator.SetInteger("Attack", 3);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("Direction", 1);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				animator.SetInteger("Attack", 1);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
		}
		else
		{
			animator.SetFloat("Change", 0.0f);
			if(Input.GetMouseButtonDown(0)){
				animator.SetInteger("Attack", animator.GetInteger("Direction"));
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
		}
	}
}
