using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    // screen shot
    [SerializeField] Camera myCam;

    private static ScreenshotHandler instance;
    private bool takeScreenshotOnNextFrame;
    string imgEnding = ".png";

    private void Awake()
    {
        instance = this;
    }

    private void OnPostRender()
    {
        if(takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCam.targetTexture;

            Texture2D renderRes = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderRes.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderRes.EncodeToPNG();
            string imgName = System.DateTime.Now.ToFileTime().ToString();       //ToString();       //ToLongTimeString();   // ToLongDateString();
            print(imgName);

            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/HomeDesignerScreenCapture");

            System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/HomeDesignerScreenCapture/" + imgName + imgEnding, byteArray);

            RenderTexture.ReleaseTemporary(renderTexture);
            myCam.targetTexture = null;
        }
    }

    private void takeScreenshot(int width, int height)
    {
        myCam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    public void takeScreenshotFromBtn()
    {
        instance.takeScreenshot(500, 500);
    }

}
