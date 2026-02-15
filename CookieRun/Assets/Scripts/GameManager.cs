using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Text scoreUI;
    public GameObject gameOverUI;
    public Button restartBtn;

    [Header("ÇÁ¸®Æé")]
    public GameObject[] obstacles;

    public int Score = 0;
    public bool isGameOver = false;

    private ObstacleSpawner obstSpwn;
    private PlayerControl playCtrl;

    void Start()
    {
        obstSpwn = GetComponent<ObstacleSpawner>();
        playCtrl = GetComponent<PlayerControl>();

        StartCoroutine(GameFlowRoutine());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
        }
    }

    IEnumerator GameFlowRoutine()
    {
        while (!isGameOver)
        {
            StartCoroutine(ObstacleRoutine());
            yield return StartCoroutine(ScoreRoutine());
            if (playCtrl.Die())
            {
                isGameOver = true;
            }
        }

        yield return new WaitForSecondsRealtime(1f);
        gameOverUI.SetActive(true);
    }


    IEnumerator ObstacleRoutine()
    {
        yield return new WaitForSecondsRealtime(1.5f); 
        obstSpwn.SpawnObstacle();
    }

    IEnumerator ScoreRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        Score++;
        scoreUI.text = $"Score:{Score}";
    }
}
