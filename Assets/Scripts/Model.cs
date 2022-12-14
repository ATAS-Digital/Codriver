using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    public NNModel modelSource;
    private Unity.Barracuda.Model model;
    private IWorker worker;
    //WebCamTexture texture;
    private string[] names = {"1_1", "1_10", "1_11", "1_11_1", "1_12", "1_12_2", "1_13", "1_14", "1_15", "1_16", "1_17",
        "1_18", "1_19", "1_2", "1_20", "1_20_2", "1_20_3", "1_21", "1_22", "1_23", "1_25", "1_26", "1_27", "1_30", "1_31",
        "1_33", "1_5", "1_6", "1_7", "1_8", "2_1", "2_2", "2_3", "2_3_2", "2_3_3", "2_3_4", "2_3_5", "2_3_6", "2_4", "2_5",
        "2_6", "2_7", "3_1", "3_10", "3_11_n13", "3_11_n17", "3_11_n20", "3_11_n23", "3_11_n5", "3_11_n8", "3_11_n9", "3_12_n10",
        "3_12_n3", "3_12_n5", "3_12_n6", "3_13_r2.5", "3_13_r3", "3_13_r3.3", "3_13_r3.5", "3_13_r3.7", "3_13_r3.9", "3_13_r4",
        "3_13_r4.1", "3_13_r4.2", "3_13_r4.3", "3_13_r4.5", "3_13_r5", "3_13_r5.2", "3_14_r2.7", "3_14_r3", "3_14_r3.5", "3_14_r3.7",
        "3_16_n1", "3_16_n3", "3_18", "3_18_2", "3_19", "3_2", "3_20", "3_21", "3_24_n10", "3_24_n20", "3_24_n30", "3_24_n40", "3_24_n5",
        "3_24_n50", "3_24_n60", "3_24_n70", "3_24_n80", "3_25_n20", "3_25_n40", "3_25_n50", "3_25_n70", "3_25_n80", "3_27", "3_28", "3_29",
        "3_30", "3_31", "3_32", "3_33", "3_4_1", "3_4_n2", "3_4_n5", "3_4_n8", "3_6", "4_1_1", "4_1_2", "4_1_2_1", "4_1_2_2", "4_1_3", "4_1_4",
        "4_1_5", "4_1_6", "4_2_1", "4_2_2", "4_2_3", "4_3", "4_5", "4_8_2", "4_8_3", "5_11", "5_12", "5_14", "5_15_1", "5_15_2", "5_15_2_2",
        "5_15_3", "5_15_5", "5_15_7", "5_16", "5_17", "5_18", "5_19_1", "5_20", "5_21", "5_22", "5_3", "5_4", "5_5", "5_6", "5_7_1", "5_7_2",
        "5_8", "6_15_1", "6_15_2", "6_15_3", "6_16", "6_2_n20", "6_2_n40", "6_2_n50", "6_2_n60", "6_2_n70", "6_3_1", "6_4", "6_6", "6_7",
        "6_8_1", "6_8_2", "6_8_3", "7_1", "7_11", "7_12", "7_14", "7_15", "7_18", "7_2", "7_3", "7_4", "7_5", "7_6", "7_7", "8_13", "8_13_1",
        "8_14", "8_15", "8_16", "8_17", "8_18", "8_1_1", "8_1_3", "8_1_4", "8_23", "8_2_1", "8_2_2", "8_2_3", "8_2_4", "8_3_1", "8_3_2", "8_3_3",
        "8_4_1", "8_4_3", "8_4_4", "8_5_2", "8_5_4", "8_6_2", "8_6_4", "8_8"};

    void Start()
    {
        model = ModelLoader.Load(modelSource);
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, model);
        StaticData.texture = new WebCamTexture();
        StaticData.texture.Play();
        InvokeRepeating("Predict", 0f, 2f);
    }

    private void Predict()
    {
        var img = GetPhoto();
        var inputTensor = new Tensor(img, 3);
        worker.Execute(inputTensor);

        var output = worker.PeekOutput();
        int ind = 0;
        double max = -Mathf.Infinity;
        for(int k =0; k<output.length; ++k)
        {
            if(max < output[k])
            {
                max = output[k];
                ind = k;
            }
        }
        //if(max<0)
        //    gameObject.GetComponent<Text>().text = "Не вижу знак";
        //else
            gameObject.GetComponent<Text>().text = DataBaseManager.GetSignName(names[ind]);
        inputTensor.Dispose();
        output.Dispose();
    }

    private Texture2D GetPhoto()
    {
        Texture2D photo = new Texture2D(StaticData.texture.width, StaticData.texture.height);
        photo.SetPixels(StaticData.texture.GetPixels());
        //photo.Resize(720, 1080);
        photo.Apply();
        return photo;
    }
}