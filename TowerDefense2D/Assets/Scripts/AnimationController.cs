using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	public void ShootingAnimation()
	{
		animator.SetBool ("isShooting",true);


	}
	public void NotShootingAnimation()
	{
		animator.SetBool ("isShooting",false);

	}
}
