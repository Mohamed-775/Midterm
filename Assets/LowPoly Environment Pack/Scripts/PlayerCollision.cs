using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource correctSound;
    public AudioSource incorrectSound;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Collectible collectible = other.GetComponent<Collectible>();

            if (collectible != null)
            {
                Destroy(other.gameObject);
                // Check color match
                if (collectible.collectibleColor == gameManager.targetColor)
                {
                    gameManager.UpdateScore(1);
                    correctSound.Play();
                }
                else
                {
                    gameManager.UpdateScore(-1);
                    incorrectSound.Play();
                }
        }
    }
}

    }

