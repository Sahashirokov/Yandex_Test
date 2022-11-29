using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public enum DeformationType
{
    Width,
    Height
}
public class GateAppearaence : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Image _topImage;
    [SerializeField] Image _glassImage;
    [SerializeField] Color _colorPositive;
    [SerializeField] Color _colorNegative;
    [SerializeField] Color _colorNeutral;

    

    [SerializeField] GameObject _expanLabel;
    [SerializeField] GameObject _shrinkLabel;
    
    [SerializeField] GameObject _upLabel;
    [SerializeField] GameObject _DownLabel;


    public void UpdateVisual(DeformationType deformationType,int value)
    {
        string prefix = "";

        
        if (value > 0)
        {
            prefix = "+";
            SetColor(_colorPositive);
        }else if (value < 0)
        {
            SetColor(_colorNegative);
        }
        else
        {
            SetColor(_colorNeutral);
        }
        _text.text = prefix +value.ToString();
        _expanLabel.SetActive(false);
        _shrinkLabel.SetActive(false);
        _upLabel.SetActive(false);
        _DownLabel.SetActive(false);
        if(deformationType == DeformationType.Width) {
            if(value > 0)
            {
                _expanLabel.SetActive(true);
            }
            else
            {
                _shrinkLabel.SetActive(true);

            }
        }
        else if(deformationType == DeformationType.Height)
        {
            if (value > 0)
            {
                _upLabel.SetActive(true);
            }
            else
            {
                _DownLabel.SetActive(true);
            }
        }
    
    }
   void SetColor(Color color)
    {
        _topImage.color = color;
        _glassImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }
}

