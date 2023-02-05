using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RopeMaxLen;
    public GameObject currentLen;
    public GameObject player;
    public GameObject rope;
    
    private Image _imageRopeMaxLen;
    private Image _imageCurrentLen;
    private float _currentLenRatio;
    private float _ropeMaxLenRatio;
    private float _ropeTargetLen;

    void Start()
    {
        _imageCurrentLen = currentLen.GetComponent<Image>();
        _imageRopeMaxLen = RopeMaxLen.GetComponent<Image>();
    }

    void Update()
    {
        _currentLenRatio = rope.GetComponent<NewRopeScript>().dist / _ropeTargetLen;
        _ropeMaxLenRatio = rope.GetComponent<NewRopeScript>().maxDist / _ropeTargetLen;
        _imageCurrentLen.fillAmount = _currentLenRatio;
        _imageRopeMaxLen.fillAmount = _ropeMaxLenRatio;
    }
}