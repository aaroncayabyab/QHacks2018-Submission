using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;
	public AudioClip deathClip;


	Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	Rigidbody rigidBody;
	bool isDead;
	bool isSinking;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
		enemyAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();

		currentHealth = startingHealth;
	}


	void Update ()
	{


	}
		


	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;

		enemyAudio.Play ();

		currentHealth -= amount;

		hitParticles.transform.position = hitPoint;
		hitParticles.Play();

		if(currentHealth <= 0)
		{
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;

		anim.SetTrigger ("isDead");

		enemyAudio.clip = deathClip;
		enemyAudio.Play ();

		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		ScoreManager.score += scoreValue;
		Destroy (this.gameObject, 2f);
	}


}
