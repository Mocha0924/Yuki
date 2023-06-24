using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnowManager : MonoBehaviour
{
    [SerializeField] private GameObject Star;
     private int Snow_Time = 0;
    [SerializeField] private int save_Time;
    private float addX = 0.0f;
    private float snow_quantity = 1;
    [SerializeField] private int Start_Time;
    [SerializeField] private float Time;
    [SerializeField] private TextMeshProUGUI time_text;
    [SerializeField] private GameObject score_Panel;
    [SerializeField] private TextMeshProUGUI score_text;
    [SerializeField] private TextMeshProUGUI evalation_text;
    [SerializeField] private TextMeshProUGUI Start_Time_text;
    [SerializeField] private GameObject player;
    [SerializeField] private Image evalation_image;
    [SerializeField] private Sprite[] evalation_sprite = new Sprite[4]; 
    private int score;
    private enum GAME_SCENE
    {
        start,
        play,
        finish
    };
    private GAME_SCENE scene = GAME_SCENE.start; 
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Start_Game());
        score_Panel.SetActive(false);
        time_text.text = Time.ToString("F0");
    }
    void FixedUpdate()
    {
        if(scene == GAME_SCENE.play)
        {
            Snow_Marker(Snow_Time);
            Time -= 0.02f;
            if (Time <= 0.0f)
            {
                Time = 0.0f;
            }
            time_text.text = Time.ToString("F0");
            if (Time <= 0.0f&&scene == GAME_SCENE.play)
            {
                scene = GAME_SCENE.finish;
                score = ScoreCheck(player);
                score_Panel.SetActive(true);
                score_text.text = "~" + score.ToString("D3");
                evalation_text.text = Score_TextCheck(score);
                StartCoroutine(Ranking());
            }
        }
      
    }
    private IEnumerator Ranking()
    {
        yield return new WaitForSeconds(3);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }
    private int ScoreCheck(GameObject player)
    {
        if (player.transform.childCount - 1 < 0)
            return 0;
        return player.transform.childCount - 1;
    }
    private IEnumerator add_change()
    {

        yield return new WaitForSeconds(5);
        addX = Random.Range(-1.0f, 1.0f);
        Star.GetComponent<SnowController>().add_power = addX;
        snow_quantity+=0.5f;
        StartCoroutine(add_change());
    }
    private IEnumerator Start_Game()
    {
        int time;
        for(time = 0;time<Start_Time;time++)
        {
            Start_Time_text.text = (Start_Time - time).ToString();
            yield return new WaitForSeconds(1);
        }
        scene = GAME_SCENE.play;
        Start_Time_text.enabled = false;
        StartCoroutine(add_change());
    }
    private void Snow_Marker(int time)
    {
        if (Snow_Time <= 0)
        {
            for (int i = 0; i < (int)snow_quantity; i++)
                StartCoroutine(Snow_Creator(i));


            Snow_Time = save_Time;
        }
        else
            Snow_Time--;
       
    }
    private IEnumerator Snow_Creator(int i)
    {
        yield return new WaitForSeconds(1*i);
        float X = Random.Range(-8.0f, 9.0f);
        float Y = Random.Range(7.0f, 9.0f);
        Instantiate(Star, new Vector3(X, Y, 0), Quaternion.identity);
    }
    private string Score_TextCheck(int score)
    {
        if (score >= 150)
        {
            evalation_image.sprite = evalation_sprite[0];
            return "‚©‚Ü‚­‚ç‚ª‚Å‚«‚Ü‚µ‚½";
        }
        else if (score >= 100)
        {
            evalation_image.sprite = evalation_sprite[1];
            return "‚ä‚«‚¾‚é‚Ü‚ª‚Å‚«‚Ü‚µ‚½";
        }
        else if (score >= 50)
        {
            evalation_image.sprite = evalation_sprite[2];
            return "‚ä‚«‚¤‚³‚¬‚ª‚Å‚«‚Ü‚µ‚½";
        }
        else
        {
            evalation_image.sprite = evalation_sprite[3];
            return "‚È‚É‚à‚Å‚«‚Ü‚¹‚ñ‚Å‚µ‚½";
        }
    }
}
