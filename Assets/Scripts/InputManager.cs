using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject widthInput;
    public GameObject heightInput;
    private GridManager gridManager;
    
    void Awake()
    {
        gridManager = GameObject.FindObjectOfType<GridManager>();
    }

    public void Generate()
    {
        string _width = widthInput.GetComponent<InputField>().text;
        string _height = heightInput.GetComponent<InputField>().text;

        if(String.IsNullOrEmpty(_width) || String.IsNullOrEmpty(_height))
        {
            Debug.Log("Eksik girildi width height");
        }

        Size size = new Size();
        if (int.TryParse(_width, out int width))
        {
            size.Width = width;
        }

        if (int.TryParse(_height, out int height))
        {
            size.Height = height;
        }

        gridManager.Draw(size.Width, size.Height);
    }
}

public class Size
{
    public int Width { get; set; }
    public int Height { get; set; }
}
