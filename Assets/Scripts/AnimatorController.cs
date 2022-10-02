using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
	Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}
	public void IdleAnimation()
	{
		animator.SetBool("idle", true);

	}
	public void RunAnimation()
	{
		animator.SetBool("running", true);
	}
	public void StopRun()
	{
		animator.SetBool("running", false);
	}


}
