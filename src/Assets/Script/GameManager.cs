using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float Time;
    [SerializeField] private TextMeshProUGUI time_text;
    [SerializeField] private GameObject score_Panel;
    [SerializeField]private TextMeshProUGUI score_text;
    [SerializeField] private GameObject player;
    private int score;
    private bool gameFinish = false;
    // Start is called before the first frame update
    private void Start()
    {
       score_Panel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Time -= 0.02f;
        if(Time <= 0.0f)
        {
            Time = 0.0f;
        }
        time_text.text = Time.ToString("F0");
        if (Time <= 0.0f && !gameFinish)
        {
            score = ScoreCheck(player);
            score_Panel.SetActive(true);
            score_text.text = score.ToString();
            gameFinish = true;
        }
    }
    private int ScoreCheck(GameObject player)
    {
        if(player.transform.childCount - 1 < 0)
            return 0;
        return player.transform.childCount - 1;
    }
}
