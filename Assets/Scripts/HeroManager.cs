using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour {

	public float walkSpeed = 1.0f;
	public float runSpeed = 1.0f;
	public bool lookingRight = true;
	public Animator anim;

	public tk2dCamera cameraObject;


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

		/*

		Vector3 testPos = Vector3.zero;
		testPos = Input.mousePosition;

			Vector3 crosshairposition = cameraObject.ScreenCamera.ScreenToWorldPoint (testPos); //new Vector3 (testPos.x / 100.0f, testPos.y / 100.0f, 0.0f);
			crosshairposition.z = 0.0f;
			//Crosshair.transform.position = crosshairposition;
			
			Vector3 m_aimDirection = crosshairposition - Player.instance.ShooterHand.transform.position;
			m_aimDirection.Normalize ();
			Player.instance.SetShooterHandDirection (m_aimDirection);
			
		}
		if ((shootTriger) &&(!Player.instance.reloading))
		{

				
				Shoot ();
				Player.instance.UpdateMagazine();
				shootTriger = false;
				Player.instance.PlayShoot();
			}
			else 	leaveOneClick = false;
			
			
		}

*/

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
