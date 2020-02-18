using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trampoline : MonoBehaviour {

    public ParticleSystem pSystem;
    public GameManager scoreScript;
	public Text scoreText;
	public Score getScore;


//	void Start () {
//		
//	}
//	
//	void Update () {
//       // scoreScript = GameObject.Find("GameManager").GetComponent<GameManager>();
//     //   pSystem = GetComponentInChildren<ParticleSystem>();
//
//	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            //Score Point
            scoreScript.score++;
            //Particle effect
            pSystem.Play();
			scoreText.text = "Score: " + scoreScript.score.ToString();

			getScore.CountScore ();

          //  Debug.Log("Trampoline Hit");
        }

    }
}
