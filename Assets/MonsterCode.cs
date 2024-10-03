using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MonsterCode : MonoBehaviour
{
    public SpriteRenderer spriterenderer;

    public Sprite[] sprites;

    public AudioClip[] SpawnAudioClips;

    private AudioSource audioSource;

    private int clicksRequired;
    private int clicksReceived;

    private float SpawnTime;
    public float MaxActiveTime = 45f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clicksRequired = Random.Range(1, 6);
        clicksReceived = 0;
        SpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - SpawnTime > MaxActiveTime)
        {
            Debug.Log("you lose");

            //SceneManager.LoadScene("GameOver");
        }
    }

    public void Initialize(int index)
    {
        if (index >= 0 && index < sprites.Length)
        {
            spriterenderer.sprite = sprites[index];
            audioSource.clip = SpawnAudioClips[index];
            audioSource.Play();
        }
    }
    private void OnMouseDown()
    {
        OnClick();
    }
    
    public void OnClick()
    {
        clicksReceived++;

        if (clicksReceived >= clicksRequired) 
        {
            DestroyMonster();
        }
        else
        {
            Debug.Log("Player clicked on enemy");
        }
    }

    private void DestroyMonster()
    {
        Destroy(gameObject);
    }
}
