using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController2 : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    Text timerUI;
    Text kecepatanUI;
    Text pemukulUI;
    Text rondeUI;
    GameObject panelSelesai;
    Text txPemenang;
    AudioSource audioKu;
    public AudioClip hitSound;
    public AudioClip hitSoundPlayer;
    float timer = 30.0f;
    int ronde = 1;
    int kelipatan = 1;
    // Use this for initialization
    void Start()
    {
        scoreUIP1 = GameObject.Find("ScoreKiri").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("ScoreKanan").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();
        kecepatanUI = GameObject.Find("Kecepatan").GetComponent<Text>();
        pemukulUI = GameObject.Find("Pemukul").GetComponent<Text>();
        txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
        rondeUI = GameObject.Find("Ronde").GetComponent<Text>();
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
        audioKu = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rondeUI.text = "Ronde = " + ronde;
        if (ronde % 2 == 1)
        {
            pemukulUI.text = "Pemukul = Merah";
            GameObject.Find("Bola").GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            pemukulUI.text = "Pemukul = Biru";
            GameObject.Find("Bola").GetComponent<Renderer>().material.color = Color.blue;
        }
        kecepatanUI.text = "Kecepatan = " + kelipatan;
        timerUI.text = System.Math.Round(timer, 2) + "";
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            ResetBall();
            timer = 30.0f;
            ronde = ronde + 1;
        }
        if (ronde == 5)
        {
            panelSelesai.SetActive(true);
            if (scoreP1 > scoreP2)
            {
                txPemenang.text = "Player Biru Pemenang!";
                Destroy(gameObject);
                return;
            }
            else if (scoreP1 < scoreP2)
            {
                txPemenang.text = "Player Merah Pemenang!";
                Destroy(gameObject);
                return;
            }
            else
            {
                txPemenang.text = "Permainan Seri!";
                Destroy(gameObject);
                return;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "PemukulKiri" && ronde % 2 == 1)
        {
            audioKu.PlayOneShot(hitSound);
            scoreP2 += 1;
            TampilkanScore();
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            kelipatan = 1;
            rigid.AddForce(arah * force * 2 * kelipatan);
            kelipatan = 2;
        }
        else if (coll.gameObject.name == "PemukulKanan" && ronde % 2 == 0)
        {
            audioKu.PlayOneShot(hitSound);
            scoreP1 += 1;
            TampilkanScore();
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            kelipatan = 1;
            rigid.AddForce(arah * force * 2 * kelipatan);
            kelipatan = 2;
        }
        else
        {
            audioKu.PlayOneShot(hitSoundPlayer);
            if ((coll.gameObject.name == "PemukulKanan" && ronde % 2 == 1) || (coll.gameObject.name == "PemukulKiri" && ronde % 2 == 0))
            {
                float sudut = (transform.position.y - coll.transform.position.y) * 5f;
                Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
                rigid.velocity = new Vector2(0, 0);
                rigid.AddForce(arah * force * 2 * kelipatan);
                kelipatan = kelipatan + 1;
            }
        }
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
        if (ronde % 2 == 0)
        {
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if (ronde % 2 == 1)
        {
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        kelipatan = 1;
    }

    void TampilkanScore()
    {
        // Debug.Log("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }
}
