using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject widthInput, heightInput, depthInput;
    private GridManager gridManager;

    void Awake()
    {
        gridManager = GameObject.FindObjectOfType<GridManager>();
    }

    void NullableMessage(string message)
    {
        if (EditorUtility.DisplayDialog("Error", message, "Ok"))
        {
            Debug.Log("yes");
        }
        else
        {
            Debug.Log("No");
        }
    }

    public void Generate()
    {
        string _width = widthInput.GetComponent<InputField>().text;
        string _height = heightInput.GetComponent<InputField>().text;
        string _depth = depthInput.GetComponent<InputField>().text;
        Debug.Log(_width + "-" + _height + "-" + _depth);

        if (String.IsNullOrEmpty(_width) || String.IsNullOrEmpty(_height) || String.IsNullOrEmpty(_depth))
        {
            NullableMessage("Width, height or depth can not be nullable.");
            return;
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

        if (int.TryParse(_depth, out int depth))
        {
            size.Depth = depth;
        }

        gridManager.Draw(size.Width, size.Height, size.Depth);
    }
}

public class Size
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; }
}
