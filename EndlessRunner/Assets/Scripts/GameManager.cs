using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Coins;
    public GameObject loseMenu;
    public Text CoinsText;
    public GameObject Plane;
    public GameObject Barrier;
    public GameObject Coin;
    public bool Alive;

    // Start is called before the first frame update
    void Start()
    {
        Alive = true;
        CoinsText.text = "Coins: " + Coins.ToString();
        StartCoroutine(PlaneGenerator());
        StartCoroutine(BarrierGenerator());
        StartCoroutine(CoinGenerator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lose()
    {
        Alive = false;
        loseMenu.SetActive(true);
        Debug.Log("Hit!!!");
    }

    public void getCoin()
    {
        Coins++;
        CoinsText.text = "Coins: " + Coins.ToString();
    }

    IEnumerator PlaneGenerator()
    {
        while (true)
        {
            if (Alive)
            {
                Instantiate(Plane, new Vector3(-127.9f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
                yield return new WaitForSeconds(17);
            }
        }
    }

    IEnumerator BarrierGenerator()
    {
        while (true)
        {
            if (Alive)
            {
                GameObject B = Instantiate(Barrier, new Vector3(-35.74f, 0.31f, Random.Range(-4, 4)), new Quaternion(0f, 0f, 0f, 0f));
                Destroy(B, 8);
                yield return new WaitForSeconds(2);
            }
        }
    }

    IEnumerator CoinGenerator()
    {
        
        while (true)
        {
            if (Alive)
            {
                GameObject B = Instantiate(Coin, new Vector3(-29.91f, 0.27f, Random.Range(-4, 4)), new Quaternion(0f, 0f, 0f, 0f));
                Destroy(B, 20);
                yield return new WaitForSeconds(Random.Range(4, 7));
            }
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
}
