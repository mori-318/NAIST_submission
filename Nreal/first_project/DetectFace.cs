using OpenCvSharp;
using OpenCvSharp.Demo;
using UnityEngine;
using UnityEngine.UI;

public class CascadeRecognizer : WebCamera
{
    public TextAsset faces;
    public TextAsset eyes;
    public RectTransform canvasRectTransform;
    private CascadeClassifier cascadeFaces;

    protected override void Awake()
    {
        base.Awake();

        // classifier
        FileStorage storageFaces = new FileStorage(eyes.text, FileStorage.Mode.Read | FileStorage.Mode.Memory);
        cascadeFaces = new CascadeClassifier();
        if (!cascadeFaces.Read(storageFaces.GetFirstTopLevelNode()))
        {
            throw new System.Exception("FaceProcessor.Initialize: Failed to load faces cascade classifier");
        }
    }

    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
    {
        Mat image = OpenCvSharp.Unity.TextureToMat(input);
        Mat gray = image.CvtColor(ColorConversionCodes.BGR2GRAY);
        Mat equalizeHistMat = new Mat();
        Cv2.EqualizeHist(gray, equalizeHistMat);
        OpenCvSharp.Rect[] rawFaces = cascadeFaces.DetectMultiScale(gray, 1.1, 6);
        for (int i = 0; i < rawFaces.Length; i++)
        {
            int x = rawFaces[i].X;
            int y = rawFaces[i].Y;
            int width = x/20*3;
            int height = y/20*3;
            
            OpenCvSharp.Rect fillRect = new OpenCvSharp.Rect(x-width/2, y, width*3/2, height);

            Cv2.Rectangle(image, fillRect, Scalar.Black, -1);

        }
        output = OpenCvSharp.Unity.MatToTexture(image);
        return true;
    }
}