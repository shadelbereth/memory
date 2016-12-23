using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   transform.Rotate(Vector3.up * 50 * Time.deltaTime);
       transform.Rotate(Vector3.right * 30 * Time.deltaTime);
	}
}
