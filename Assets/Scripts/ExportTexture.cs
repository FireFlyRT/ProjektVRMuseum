
using System.IO;
using UnityEngine;

public static class ExportTexture
{
    public static void ExportRenderTexture(RenderTexture renderTexture)
    {
        string savePath = $"{Application.dataPath}/Pictures/picture1.png";
        savePath = savePath.Replace("/Assets", "");

        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();
        byte[] data = texture.EncodeToPNG();
        File.Open(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        // Todo: Sharing Violation Exception Fixen
        File.WriteAllBytes(savePath, data);
    }
}
