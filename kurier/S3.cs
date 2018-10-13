using System;
using System.Collections.Generic;
using System.Text;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using System.Windows.Forms;
using Amazon;

namespace kurier
{
    class S3
    {
        private AmazonS3Client _client;

        public S3()
        {
            this._client = new AmazonS3Client(Properties.S3Settings.Default.AWS_ACCESS_KEY, Properties.S3Settings.Default.AWS_SECRET_KEY, RegionEndpoint.EUCentral1);
        }

        public void send(string bucket, string filePath, string remotePath)
        {
            PutObjectRequest request = new PutObjectRequest { 
                BucketName = bucket,
                Key = remotePath,
                ContentBody = File.ReadAllText(filePath) };
            this._client.PutObject(request);
        }
    }
}
