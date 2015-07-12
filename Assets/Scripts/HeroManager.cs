using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour {

	public float walkSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float nextposition = this.transform.position.x  + walkSpeed * Time.deltaTime;
		this.transform.position = new Vector3(nextposition,this.transform.position.y,this.transform.position.z);

	}
}
