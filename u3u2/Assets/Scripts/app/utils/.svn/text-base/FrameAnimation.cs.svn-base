using app.chat;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 序列帧动画
/// </summary>
public class FrameAnimation : MonoBehaviour
{
    public float fps = ChatContentBase.FACE_FRAME_RATE;
	public bool isPlayOnwake = false;
	private string biaoqingName;

    protected GameUUImageIgnoreRaycast comImage;
    protected float time;
    protected int frameLenght;
    protected bool isPlaying = false;
	protected int currentIndex = 0;
    protected Sprite[] spriteArr;

    public string BiaoqingName
    {
        get { return biaoqingName; }
        set
        {
            biaoqingName = value; 
            init();
        }
    }

    // Use this for initialization
    void init()
    {
        comImage = gameObject.GetComponent<GameUUImageIgnoreRaycast>();
        if (comImage == null)
        {
            comImage = gameObject.AddComponent<GameUUImageIgnoreRaycast>();
        }
        loadTexture();
		if (isPlayOnwake) {
			play ();
		}
    }

	public void loadTexture()
	{
		//load textures
        frameLenght = ChatModel.Ins.GetBiaoQingFrameLen(BiaoqingName);
        spriteArr = ChatModel.Ins.GetBiaoQingFrameList(BiaoqingName);
	}

    void Update()
    {
        if (isPlaying)
        {
            drawAnimation();
        }
    }

    // Update is called once per frame
    protected void drawAnimation()
    {
        if (spriteArr == null || (spriteArr != null && spriteArr.Length==0))
        {
            return;
        }
        comImage.sprite = spriteArr[currentIndex];
        comImage.SetNativeSize();
        comImage.transform.localScale = Vector3.one*1.5f;
        if (currentIndex < frameLenght)
        {
            time += Time.deltaTime;
            if (time >= 1.0f / fps)
            {
				currentIndex++;
                time = 0;
                if (currentIndex == frameLenght)
                {
                    currentIndex = 0;
                }
            }
        }
    }

    public void play()
    {
        isPlaying = true;
    }

    public void stop()
    {
        isPlaying = false;
        currentIndex = 0;
        if (spriteArr != null && spriteArr.Length>0)
        {
            comImage.sprite = spriteArr[0];
            comImage.SetNativeSize();
        }
        else
        {
            comImage.sprite = null;
        }
    }

    public void pause()
    {
        isPlaying = false;
    }
}
