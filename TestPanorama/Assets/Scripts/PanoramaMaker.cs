using UnityEngine;

public class PanoramaRenderer : MonoBehaviour
{
    public Camera panoramaCamera;
    public Cubemap panoramaCubemap;

    void Start()
    {
        RenderPanorama();
    }

    void RenderPanorama()
    {
        panoramaCamera.RenderToCubemap(panoramaCubemap);

        // Save the cubemap to a PNG file (optional)
        Texture2D panoramaTexture2D = new Texture2D(panoramaCubemap.width, panoramaCubemap.height, TextureFormat.RGB24, false);
        panoramaTexture2D.SetPixels(panoramaCubemap.GetPixels(CubemapFace.PositiveX));
        panoramaTexture2D.Apply();
        byte[] bytes = panoramaTexture2D.EncodeToPNG();
        System.IO.File.WriteAllBytes("Panorama.png", bytes);
    }
}
