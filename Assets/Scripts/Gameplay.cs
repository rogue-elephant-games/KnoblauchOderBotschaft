using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    public Image image; //change this image
    public Sprite[] spritearray;
    public float timeLeft = 20.0f;
    int index = 0;

    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        // image. = Resources.Load<TextAsset>("Text/textFile01");
        sceneLoader = GetComponent<SceneLoader>();
        GetNextPhoto();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = (timeLeft).ToString("0");
        }
        else
            sceneLoader.LoadGameOverScene();

    }

    void GetNextPhoto()
    {
        index += 1;
        if (index > spritearray.Length - 1)
        {//if index is too big
            index = 0; //loop back around
        }
        image.sprite = spritearray[index];
    }

    public void CheckAnswer(bool isKnobLauch)
    {
        var imageIsKnoblauch = image.sprite.name.ToLower().Contains("knoblauch");
        if(
            (isKnobLauch && imageIsKnoblauch)
            || (!isKnobLauch && !imageIsKnoblauch)
            )
            GetNextPhoto();
        else
            sceneLoader.LoadGameOverScene();

    }
}
