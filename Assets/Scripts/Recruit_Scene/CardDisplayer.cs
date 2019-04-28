using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayer : MonoBehaviour
{
    [SerializeField] private Image picture;

    public void SetPictureColor(Color _color)
    {
        picture.color = _color;
    }

}
