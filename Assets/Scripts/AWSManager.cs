using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Model;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AWSManager : MonoBehaviour
{
    private static AWSManager _instance;
    public static AWSManager Instance => _instance;
    
    public GameObject imageTarget;

    string _idPool = "us-east-2:32690323-db25-474c-87de-92cee4c0071f";
    string _bucketName = "horsearassetbundle";

    public string S3Region = RegionEndpoint.USEast2.SystemName;
    private RegionEndpoint _s3Region
    {
        get { return RegionEndpoint.GetBySystemName(S3Region); }
    }

    private AmazonS3Client _s3Client;
    public AmazonS3Client S3Client
    {
        get
        {
            if (_s3Client == null)
            {
                _s3Client = new AmazonS3Client(new CognitoAWSCredentials(_idPool, RegionEndpoint.USEast2), _s3Region);
            }
            return _s3Client;
        }
    }

    private void Awake()
    {
        _instance = this;
        UnityInitializer.AttachToGameObject(this.gameObject);
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;

        GetObject();

        //StartCoroutine(BundleRoutine());
    }

    private void GetObject()
    {
        var request = new ListObjectsRequest()
        {
            BucketName = _bucketName
        };

        S3Client.ListObjectsAsync(request, (responseObject) =>
        {
            if (responseObject.Exception == null)
            {
                {
                    responseObject.Response.S3Objects.ForEach((obj) =>
                    {
                        Debug.Log("Asset bundle obj " + obj.Key);
                        StartCoroutine(BundleRoutine());
                    });
                }
            }
            else
            {
                Debug.LogError("Geting objects from AWS error: " + responseObject.Exception);
            }

        });
        
    }

    IEnumerator BundleRoutine()
    {
        string uri = "https://horsearassetbundle.s3.us-east-2.amazonaws.com/horsy";
        var request = new WWW(uri);
        yield return request;

        AssetBundle bundle = request.assetBundle;
        GameObject horse = bundle.LoadAsset<GameObject>("horse");
        var horseClone = Instantiate(horse);
        horseClone.transform.parent = imageTarget.transform;
    }


}
