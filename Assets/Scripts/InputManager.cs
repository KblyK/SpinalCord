using Assets.Scripts;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject widthInput, heightInput, depthInput;
    public GameObject x_Dot1, y_Dot1, z_Dot1;
    public GameObject x_Dot2, y_Dot2, z_Dot2;
    public GameObject x_Dot3, y_Dot3, z_Dot3;
    public GameObject x_Dot4, y_Dot4, z_Dot4;
    public GameObject x_target_Dot1, y_target_Dot1, z_target_Dot1;
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
        Inputs size = GenerateSize();
        if (size == null) return;
        BaseDots dots = GenerateBaseDots();
        TargetDots targetDots = GenerateTargets();

        gridManager.Draw(size, dots, targetDots);
    }

    private TargetDots GenerateTargets()
    {
        string _x_Dot1 = x_target_Dot1.GetComponent<InputField>().text;
        string _y_Dot1 = y_target_Dot1.GetComponent<InputField>().text;
        string _z_Dot1 = z_target_Dot1.GetComponent<InputField>().text;

        TargetDots dots = new TargetDots();
        if (int.TryParse(_x_Dot1, out int x_dot1))
        {
            dots.x_Dot1 = x_dot1;
        }

        if (int.TryParse(_y_Dot1, out int y_dot1))
        {
            dots.y_Dot1 = y_dot1;
        }

        if (int.TryParse(_z_Dot1, out int z_dot1))
        {
            dots.z_Dot1 = z_dot1;
        }

        return dots;
    }

    private BaseDots GenerateBaseDots()
    {
        string _x_Dot1 = x_Dot1.GetComponent<InputField>().text;
        string _y_Dot1 = y_Dot1.GetComponent<InputField>().text;
        string _z_Dot1 = z_Dot1.GetComponent<InputField>().text;

        string _x_Dot2 = x_Dot2.GetComponent<InputField>().text;
        string _y_Dot2 = y_Dot2.GetComponent<InputField>().text;
        string _z_Dot2 = z_Dot2.GetComponent<InputField>().text;

        string _x_Dot3 = x_Dot3.GetComponent<InputField>().text;
        string _y_Dot3 = y_Dot3.GetComponent<InputField>().text;
        string _z_Dot3 = z_Dot3.GetComponent<InputField>().text;

        string _x_Dot4 = x_Dot4.GetComponent<InputField>().text;
        string _y_Dot4 = y_Dot4.GetComponent<InputField>().text;
        string _z_Dot4 = z_Dot4.GetComponent<InputField>().text;

        BaseDots dots = new BaseDots();
        if (int.TryParse(_x_Dot1, out int x_dot1))
        {
            dots.x_Dot1 = x_dot1;
        }

        if (int.TryParse(_y_Dot1, out int y_dot1))
        {
            dots.y_Dot1 = y_dot1;
        }

        if (int.TryParse(_z_Dot1, out int z_dot1))
        {
            dots.z_Dot1 = z_dot1;
        }

        if (int.TryParse(_x_Dot2, out int x_dot2))
        {
            dots.x_Dot2 = x_dot2;
        }

        if (int.TryParse(_y_Dot2, out int y_dot2))
        {
            dots.y_Dot2 = y_dot2;
        }

        if (int.TryParse(_z_Dot2, out int z_dot2))
        {
            dots.z_Dot2 = z_dot2;
        }

        if (int.TryParse(_x_Dot3, out int x_dot3))
        {
            dots.x_Dot3 = x_dot3;
        }

        if (int.TryParse(_y_Dot3, out int y_dot3))
        {
            dots.y_Dot3 = y_dot3;
        }

        if (int.TryParse(_z_Dot3, out int z_dot3))
        {
            dots.z_Dot3 = z_dot3;
        }

        if (int.TryParse(_x_Dot4, out int x_dot4))
        {
            dots.x_Dot4 = x_dot4;
        }

        if (int.TryParse(_y_Dot4, out int y_dot4))
        {
            dots.y_Dot4 = y_dot4;
        }

        if (int.TryParse(_z_Dot4, out int z_dot4))
        {
            dots.z_Dot4 = z_dot4;
        }

        return dots;
    }

    private Inputs GenerateSize()
    {
        string _width = widthInput.GetComponent<InputField>().text;
        string _height = heightInput.GetComponent<InputField>().text;
        string _depth = depthInput.GetComponent<InputField>().text;

        if (String.IsNullOrEmpty(_width) || String.IsNullOrEmpty(_height) || String.IsNullOrEmpty(_depth))
        {
            NullableMessage("Width, height or depth can not be nullable.");
            return null;
        }

        Inputs size = new Inputs();
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

        return size;
    }
}
