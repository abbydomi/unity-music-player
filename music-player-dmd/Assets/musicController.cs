using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;



public class musicController : MonoBehaviour
{
    public AudioClip[] songs;
    public int currentsong;
    public List<int> history;
    public Animator[] discAnimators;
    public Animator turntableAnimator;
    public TextMeshProUGUI songname; 

    [HideInInspector]
    public AudioSource selfsource;
    

    // Start is called before the first frame update
    void Start()
    {
        selfsource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (currentsong)
        {
            case -1:
                songname.text = "No song playing";
                break;
            case 0:
                //momento azul rojuu
                songname.text = "momenTo azul - Rojuu";
                break;

            case 1:
                //n64 alex g
                songname.text = "Nintendo 64 - Alex G";
                break;

            case 2:
                //papi gnash
                songname.text = "papi - Gnash";
                break;

            case 3:
                //dbz cia
                songname.text = "dragon ball z budokai tenkaichi 4 - Camping in Alaska";
                break;

            case 4:
                //glowing superweaks
                songname.text = "Glowing - The Superweaks";
                break;
        }
    }
    public void PlaySong(int s)
    {
        if (currentsong != s)
        {
            currentsong = s;
            if (history.Last() != -1)
            {
                discAnimators[history.Last()].SetTrigger("stop");
                turntableAnimator.SetTrigger("pausetrigger");
            }

            turntableAnimator.SetTrigger("playtrigger");


            switch (s)
            {
                case 0:
                    discAnimators[s].Play("rojuuplay");
                    break;
                case 1:
                    discAnimators[s].Play("alexgplay");
                    break;
                case 2:
                    discAnimators[s].Play("gnashplay");
                    break;
                case 3:
                    discAnimators[s].Play("ciaplay");
                    break;
                case 4:
                    discAnimators[s].Play("supweakplay");
                    break;

            }
            history.Add(currentsong);
            selfsource.clip = songs[currentsong];
            selfsource.Play();
        }
    }
}
