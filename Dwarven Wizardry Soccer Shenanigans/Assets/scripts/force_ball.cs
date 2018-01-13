using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_ball : MonoBehaviour {

	public float speed;
	public float force;
	public Vector2 direction;
	private fpull_effect[] effects;
	public GameObject effect;

	// Use this for initialization
	void Start () {
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		effects = new fpull_effect[balls.Length];
		int i = 0;
		foreach (GameObject b in balls) {
			
			GameObject instance = GameObject.Instantiate (effect, b.transform.position, Quaternion.identity);
			fpull_effect ff = instance.GetComponent<fpull_effect> ();
			ff.follow = b;
			ff.pointto = gameObject;
			ff.duration = 40f;
			effects [i] = ff;

		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 delta = direction.normalized * speed * Time.deltaTime;
		gameObject.transform.position = gameObject.transform.position + new Vector3 (delta.x, delta.y, 0);
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject b in balls) {
			Rigidbody2D rbd = b.GetComponent<Rigidbody2D> ();
			rbd.AddForce ((gameObject.transform.position - b.transform.position).normalized * force*Time.deltaTime);
		}
		
	}
		

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Wall") {
			foreach (fpull_effect ff in effects) {
				Destroy (ff.gameObject);
			}
			Destroy (gameObject);
		}

	}
}
