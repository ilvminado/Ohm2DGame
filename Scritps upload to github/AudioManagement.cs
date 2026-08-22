using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    // Start is called before the first frame update

    private Player player;

    //Audio FX for animations
    // in case of wanting to use different arrays for clips // public AudioClip[] Audio;
    public AudioSource MusicFirstLevel;
    public AudioClip MusicSecondLevel;
    public AudioClip SoundFX;

    public AudioClip Step;
    public AudioClip Punching ;
    public AudioClip Kicking;
    public AudioClip Jumping;
    public AudioClip Shotting;
    public AudioClip Gettinghit;
    public AudioSource Other;





    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

      // SoundFX.clip = Steps;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
