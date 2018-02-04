using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;


    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
		StartCoroutine ("PlayAgain");
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }

	IEnumerable PlayAgain() {
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("startMenu");
	}

}
