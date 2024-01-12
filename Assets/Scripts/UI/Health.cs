using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Image heartsImg;
    public Sprite fullHeart, emptyHeart, halfHeart;
    private void Awake() {
        heartsImg = GetComponent<Image>();
    }

    public void setHeartImage(HeartStatus heartStatus){
        switch (heartStatus){
            case HeartStatus.Empty:
                heartsImg.sprite = emptyHeart;
                break;
            case HeartStatus.Half:
                heartsImg.sprite = halfHeart;
                break;
            case HeartStatus.Full:
                heartsImg.sprite = fullHeart;
                break;
        }
    }

    void Start()
    {
        
    }
    public enum HeartStatus{
        Empty = 0,
        Half = 1,
        Full = 2
    }
}
