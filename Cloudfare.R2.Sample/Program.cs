// See https://aka.ms/new-console-template for more information

using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using PromptSharp;
using System.Net.Http.Headers;


var accountId = "<YOUR R2 ACCOUNT ID>";
var accessKey = "<YOUR R2 ACCESS KEY>";
var secretKey = "<YOUR R2 SECRET KEY>";
var bucketName = "<YOUR R2 BUCKET NAME>";
var url = $"https://{accountId}.r2.cloudflarestorage.com/{bucketName}";

var file = Prompt.Input<string>("Select a file to submit to R2 Bucket");



var credentials = new BasicAWSCredentials(accessKey, secretKey);
var s3Client = new AmazonS3Client(credentials, new AmazonS3Config
{
    ServiceURL = $"https://{accountId}.r2.cloudflarestorage.com",
});

var request = new PutObjectRequest
{
    FilePath = file,
    BucketName = bucketName,
    DisablePayloadSigning = true //DisablePayloadSigning = true must be passed as Cloudflare R2 does not currently support the Streaming SigV4 implementation used by AWSSDK.S3.
};

var response = await s3Client.PutObjectAsync(request);

Console.WriteLine("ETag: {0}", response.ETag);


