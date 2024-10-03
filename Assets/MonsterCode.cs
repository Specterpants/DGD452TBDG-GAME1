using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterCode : MonoBehaviour
{
    public SpriteRenderer spriterenderer;

    public Sprite[] sprites;

    public AudioClip[] SpawnAudioClips;

    private AudioSource audioSource;

    private int clicksRequired;
    private int clicksReceived;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clicksRequired = Random.Range(1, 6);
        clicksReceived = 0;
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
            Debug.Log("Player clicked on Monster");
        }
    }

    private void DestroyMonster()
    {
        Destroy(gameObject);
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
