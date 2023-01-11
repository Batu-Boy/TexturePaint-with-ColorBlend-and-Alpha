using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TexturePainter : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] Color brushColor;
    [SerializeField] private int brushSize = 1;
    
    [Header("References")]
    [SerializeField] private Texture2D dirtBrush;
    [SerializeField] private Material material;
    [SerializeField] private Texture2D mainTexBase;

    private Texture2D paintingTexture;
    private Camera cam;
    private void Start()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        paintingTexture = new Texture2D(mainTexBase.width, mainTexBase.height);
        paintingTexture.SetPixels(mainTexBase.GetPixels());
        paintingTexture.alphaIsTransparency = false;
        paintingTexture.Apply();
        material.SetTexture("_MainTex", paintingTexture);
        
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            print("origin: " + ray.origin);
            print("dir: " + ray.direction);
            if (Physics.Raycast(ray, out RaycastHit raycastHit)) PaintOnHit(raycastHit);
        }
    }

    private void PaintOnHit(RaycastHit hit)
    {
        Vector2 textureCoord = hit.textureCoord;

        print(textureCoord);
        int pixelX = (int)(textureCoord.x * paintingTexture.width);
        int pixelY = (int)(textureCoord.y * paintingTexture.height);

        int pixelXOffset = pixelX - (dirtBrush.width / 2);
        int pixelYOffset = pixelY - (dirtBrush.height / 2);

        for (int x = 0; x < dirtBrush.width; x++)
        {
            for (int y = 0; y < dirtBrush.height; y++)
            {
                Color pixelDirt = dirtBrush.GetPixel(x, y);
                Color pixelMain = paintingTexture.GetPixel(pixelXOffset + x, pixelYOffset + y);

                float alpha = 1 - pixelDirt.g;
                Color mixedColor = (brushColor * alpha + pixelMain) / (1 + alpha);
                mixedColor.a = 1;

                paintingTexture.SetPixel(
                    pixelXOffset + x,
                    pixelYOffset + y,
                    mixedColor
                );
            }
        }
        paintingTexture.Apply();
    }
}
