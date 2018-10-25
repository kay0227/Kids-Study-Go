using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                 // 자료형 Image를 사용하려면 using 시켜줘야 한다.

public class SoundOnOffScripts : MonoBehaviour {
    public Sprite[] ChangeImg;        // 바뀔 이미지.  
    public Image CanvasImage;         // 캔버스에 존재하는 이미지.

    private bool BgmSoundSw = false;  // 사운드 스위치.

    // Use this for initialization
    void Start()
    {
        //SoundPlay();
    }

    // Update is called once per frame
    void Update()
    {
        //SoundPlay();
    }

    public void SoundPlay()
    {
        if (!BgmSoundSw)
        {
            CanvasImage.GetComponent<Image>().sprite = //ChangeImg[1];    // 그림을 Off이미지로 바꿔준다.
                Resources.Load("SoundOff", typeof(Sprite)) as Sprite;
            //this.GetComponent<AudioSource>().volume = 0;                // 볼륨을 0으로.
            BgmSoundSw = true;
        }
        else
        {
            CanvasImage.GetComponent<Image>().sprite = //ChangeImg[0];    // 그림 On이미지로 바꿔준다.
                Resources.Load("SoundOn", typeof(Sprite)) as Sprite;
            //this.GetComponent<AudioSource>().volume = 1;                // 볼륨을 1로.
            BgmSoundSw = false;
        }
    }
}


/*
    public Sprite[] ChangeImg;        // 바뀔 이미지.  
    public Image CanvasImage;         // 캔버스에 존재하는 이미지.

    private bool BgmSoundSw = false;  // 사운드 스위치.

	

private SpriteRenderer sRander;
public Sprite[] sprites;
private bool BgmSoundSw = false;

// Use this for initialization
void Start()
{
    sRander = GetComponent<SpriteRenderer>();
    if (!BgmSoundSw)
    {
        sRander.sprite = sprites[0];
        BgmSoundSw = true;
    }
    else
    {
        sRander.sprite = sprites[1];
        BgmSoundSw = false;
    }
}

// Update is called once per frame
void Update()
{

}

    public Image image;

    // Use this for initialization
    void Start()
    {
        Sprite newSprite = Resources.Load<Sprite>("SoundOn");
        image.overrideSprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
