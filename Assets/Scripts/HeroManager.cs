using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour {

	public float walkSpeed = 1.0f;
	public float runSpeed = 1.0f;
	public bool lookingRight = true;
	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float speed = walkSpeed;
		if (Input.GetKey (KeyCode.D)) 
		{
			if (!lookingRight)
				Flip();
			if (Input.GetKey (KeyCode.LeftShift))
			{
				anim.SetInteger("State",2);
				speed = runSpeed;
			}
			else anim.SetInteger("State",1);
			float nextposition = this.transform.position.x  + speed * Time.deltaTime;
			this.transform.position = new Vector3(nextposition,this.transform.position.y,this.transform.position.z);

		}
		else if (Input.GetKey (KeyCode.A)) 
		{
			if (lookingRight)
				Flip();
			if (Input.GetKey (KeyCode.LeftShift))
			{
				anim.SetInteger("State",2);
				speed = runSpeed;
			}
			else anim.SetInteger("State",1);

			float nextposition = this.transform.position.x  - speed * Time.deltaTime;
			this.transform.position = new Vector3(nextposition,this.transform.position.y,this.transform.position.z);

		}
		else anim.SetInteger("State",0);

		if (Input.GetKey (KeyCode.W)) 
			anim.SetBool("Jump",true);
		else anim.SetBool("Jump",false);

	}
	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = anim.transform.gameObject.transform.localScale;
		myScale.x *= -1;
		anim.transform.gameObject.transform.localScale = myScale;
	}
}
