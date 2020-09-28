using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberGenerator : MonoBehaviour
{
  private static NumberGenerator _instance;
  public static NumberGenerator Instance
  {
    get
    {
      if (_instance == null)
      {
        Debug.LogError("Number Generator is NULL.");
      }
      return _instance;
    }
  }

  public Text number;
  public Text lowerSliderText;
  public Text upperSliderText;

  public Slider lowerSliderSlider;
  public Slider upperSliderSlider;

  private int _lowerValue;
  private int _upperValue;
  private int digit;

  private Queue<int> valuesGenerated = new Queue<int>();

  void Start()
  {
    this.number.text = "0";
    this._lowerValue = 1;
    this._upperValue = 10;
    this.valuesGenerated.Enqueue(0);
    this.valuesGenerated.Enqueue(0);
    this.valuesGenerated.Enqueue(0);
  }

  public void GenerateNumber()
  {
    for (int i = 0; i < 10; i++)
    {
      this.digit = UnityEngine.Random.Range(this._lowerValue, this._upperValue);
      if (!(this.valuesGenerated.Contains(this.digit)))
      {
        break;
      }
    }
    this.valuesGenerated.Dequeue();
    this.valuesGenerated.Enqueue(this.digit);
    this.number.text = this.digit.ToString();
  }

  public void LowerSliderEvent()
  {
    int value = Convert.ToInt32(this.lowerSliderSlider.value);
    this.lowerSliderText.text = "Min Value: " + value.ToString();
    this._lowerValue = value;
  }

  public void UpperSliderEvent()
  {
    int value = Convert.ToInt32(this.upperSliderSlider.value);
    this.upperSliderText.text = "Max Value: " + value.ToString();
    this._upperValue = value + 1;
  }

  public void ExitApplication()
  {
    Application.Quit();
  }
}
