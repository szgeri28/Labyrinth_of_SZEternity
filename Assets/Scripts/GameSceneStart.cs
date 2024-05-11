using UnityEngine;
using UnityEngine.SceneManagement;

public class WallCollision : MonoBehaviour
{
    private string game = "Game";
    private string game1 = "Game 1";
    private string game2 = "Game 2";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player-rel való ütközés esetén
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.stageCounter == 0)
        {
            // Betölti a Game scenet
            SceneManager.LoadScene(game);

        }

        else if (collision.gameObject.CompareTag("Player") && GameManager.Instance.stageCounter == 1)
        {
            // Betölti a Game scenet
            SceneManager.LoadScene(game1);

        }

        else if (collision.gameObject.CompareTag("Player") && GameManager.Instance.stageCounter == 2)
        {
            // Betölti a Game scenet
            SceneManager.LoadScene(game2);

        }
    }
}