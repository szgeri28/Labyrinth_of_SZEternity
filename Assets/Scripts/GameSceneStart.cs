using UnityEngine;
using UnityEngine.SceneManagement;

public class WallCollision : MonoBehaviour
{
    private string game = "Game";
    private string game1 = "Game 1";
    private string game2 = "Game 2";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player-rel val� �tk�z�s eset�n
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.stageCounter == 0)
        {
            // Bet�lti a Game scenet
            SceneManager.LoadScene(game);

        }

        else if (collision.gameObject.CompareTag("Player") && GameManager.Instance.stageCounter == 1)
        {
            // Bet�lti a Game scenet
            SceneManager.LoadScene(game1);

        }

        else if (collision.gameObject.CompareTag("Player") && GameManager.Instance.stageCounter == 2)
        {
            // Bet�lti a Game scenet
            SceneManager.LoadScene(game2);

        }
    }
}