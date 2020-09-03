using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    // the canvas to disable while taking the screenshot
    [SerializeField] GameObject canvas;
    // the image file ending
    string imgEnding = ".png";
    // the texture holding the screenshot
    Texture2D screenshotTexture { get; set; }

    private void Awake()
    {
        // instantiate the texture with the screen size
        screenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
    }

    IEnumerator updateScreenshotTexture()
    {
        // the canvas gets disabled since it not wanted in the picture
        canvas.SetActive(false);
        // wait for the end of the frame
        yield return new WaitForEndOfFrame();
        // this render texture is responsible for combining the scene with the post processing effects
        RenderTexture transformedRenderTexture = null;
        // instantiate the RenderTexture with the screen size
        RenderTexture renderTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, 1);
        try
        {
            // get the current render
            ScreenCapture.CaptureScreenshotIntoRenderTexture(renderTexture);
            // instantiate the transformed render Texture with the size of the Texture2D screenshot 
            transformedRenderTexture = RenderTexture.GetTemporary( screenshotTexture.width, screenshotTexture.height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, 1);
            // cpoy renderTexture into transformedRenderTexture
            Graphics.Blit( renderTexture, transformedRenderTexture, new Vector2(1, -1), new Vector2(0, 1));
            // transformedRenderTexture is now the active render texture
            RenderTexture.active = transformedRenderTexture;
            // read pixels from screen into the texture
            screenshotTexture.ReadPixels( new Rect(0, 0, screenshotTexture.width, screenshotTexture.height), 0, 0);

        }
        catch (Exception e)
        {
            yield break;
        }
        finally
        {
            // the render textures get cleaned up
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(renderTexture);
            // if there's a result
            if (transformedRenderTexture != null)
            {
                // relaease that too
                RenderTexture.ReleaseTemporary(transformedRenderTexture);
            }
        }
        // actually apply the read pixels
        screenshotTexture.Apply();
        // save the texture into an image
        turnTexture2DIntoPNG(screenshotTexture);
        // enable the canvas again
        canvas.SetActive(true);
    }

    void turnTexture2DIntoPNG(Texture2D texture2D)
    {
        // encode the texture into PNG format
        byte[] byteArray = texture2D.EncodeToPNG();
        // the picture name
        string imgName = System.DateTime.Now.ToFileTime().ToString();

        // create the directory if it doesn't exist already
        System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/HomeDesignerScreenCapture");
        // save the picure
        System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/HomeDesignerScreenCapture/" + imgName + imgEnding, byteArray);
    }

    // call the method with an onClick event
    public void takeScreenshotFromBtn() { StartCoroutine(updateScreenshotTexture()); }

}
