using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {


	public static BallSpawner current;

	public GameObject pooledBall;
	public List <GameObject> pooledBalls;
	public int pooledAmount = 10;


	public bool willSpawn = true;

	public float pooledTime = 0.5f;


	void Awake ()
	{
		current = this;
	}


	void Start ()
	{
		InvokeRepeating ("SpawnBall", pooledTime, pooledTime);



		pooledBalls = new List <GameObject> ();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate (pooledBall);
			obj.SetActive (false);
			pooledBalls.Add (obj);
		}

	}

	public GameObject BallToPool()
	{
		for (int i = 0; i < pooledBalls.Count; i++)
		{
			if (!pooledBalls [i].activeInHierarchy)
			{
				return pooledBalls [i];
			}


		}

		if (willSpawn)
		{
			GameObject obj = (GameObject)Instantiate (pooledBall);
			pooledBalls.Add (obj);
			return obj;
		}
		return null;

	}

	void SpawnBall()
	{
		GameObject selectedBall = BallSpawner.current.BallToPool ();

		if (selectedBall == null)
			return;


		selectedBall.transform.position = transform.position;
		selectedBall.transform.rotation = transform.rotation;
		Rigidbody selectedRigidbody = selectedBall.GetComponent<Rigidbody>();
		selectedRigidbody.velocity = Vector3.zero;
		selectedRigidbody.angularVelocity = Vector3.zero;
		selectedBall.SetActive (true);
	}
}