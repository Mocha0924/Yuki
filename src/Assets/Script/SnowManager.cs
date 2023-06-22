using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManager : MonoBehaviour
{
    [SerializeField] private GameObject Star;
    [SerializeField] private int Time = 100;
    private int save_Time;
    private float addX = 0.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(add_change());
        save_Time = Time;
    }
    void FixedUpdate()
    {
        if (Time <= 0)
        {
            Star_Marker(Star);
            Time = save_Time;
        }
        else
            Time--;
    }
    private IEnumerator add_change()
    {

        yield return new WaitForSeconds(5);
        addX = Random.Range(-0.3f, 0.3f);
        StartCoroutine(add_change());
    }
    private void Star_Marker(GameObject Star)
    {
        float X = Random.Range(-8.0f, 9.0f);
        Instantiate(Star, new Vector3(X, 7.0f, 0), Quaternion.identity);
        Star.GetComponent<SnowController>().add_power = addX;
    }
}
