using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller
public class ScreenshotHandler : MonoBehaviour
{
    // screen shot
    [SerializeField] GameObject canvas;
    string imgEnding = ".png";
    Texture2D screenshotTexture { get; set; }

    private void Awake()
    {
        screenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
    }


    IEnumerator updateScreenshotTexture()
    {
        canvas.SetActive(false);
        yield return new WaitForEndOfFrame();
        RenderTexture transformedRenderTexture = null;
        RenderTexture renderTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, 1);
        try
        {
            print("happens");
            ScreenCapture.CaptureScreenshotIntoRenderTexture(renderTexture);
            transformedRenderTexture = RenderTexture.GetTemporary( screenshotTexture.width, screenshotTexture.height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, 1);
            Graphics.Blit( renderTexture, transformedRenderTexture, new Vector2(1, -1), new Vector2(0, 1));
            RenderTexture.active = transformedRenderTexture;
            screenshotTexture.ReadPixels( new Rect(0, 0, screenshotTexture.width, screenshotTexture.height), 0, 0);

        }
        catch (Exception e)
        {
            Debug.Log(e);
            yield break;
        }
        finally
        {
            print("finally");

            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(renderTexture);
            if (transformedRenderTexture != null)
            {
                RenderTexture.ReleaseTemporary(transformedRenderTexture);
            }
        }

        screenshotTexture.Apply();
        turnTexture2DIntoPNG(screenshotTexture);
        canvas.SetActive(true);
    }

    void turnTexture2DIntoPNG(Texture2D texture2D)
    {
        byte[] byteArray = texture2D.EncodeToPNG();
        string imgName = System.DateTime.Now.ToFileTime().ToString();
        print(imgName);

        System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/HomeDesignerScreenCapture");
        System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/HomeDesignerScreenCapture/" + imgName + imgEnding, byteArray);
    }

    public void takeScreenshotFromBtn()
    {
        print("button press");
        StartCoroutine(updateScreenshotTexture());
        //instance.takeScreenshot(Screen.width, Screen.height);
    }

}
