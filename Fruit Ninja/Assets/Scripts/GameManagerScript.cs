using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public Text scoreText;

    public Image fadeImage;

    private int score;

    private Blade blade;
    private Spawner spawner;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();

        ClearScene();
    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();
        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach(Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        foreach(Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void Explode()
    {
        

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while(elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        NewGame();

        elapsed = 0f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
    }
}
