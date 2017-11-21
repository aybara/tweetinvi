﻿using System;
using System.Collections.Generic;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Public.Events;
using Tweetinvi.Parameters;

namespace Tweetinvi.Core.Parameters
{
    /// <summary>
    /// https://dev.twitter.com/rest/media/uploading-media
    /// </summary>
    public interface IUploadQueryParameters
    {
        /// <summary>
        /// Binaries that you want to publish
        /// </summary>
        List<byte[]> Binaries { get; set; }

        /// <summary>
        /// Type of element that you want to publish.
        /// This will be used as the ContenType in the HttpRequest.
        /// </summary>
        string MediaType { get; set; }

        /// <summary>
        /// Type of upload. `tweet_video` allows to access the STATUS of the upload processing.
        /// </summary>
        string MediaCategory { get; set; }

        /// <summary>
        /// Maximum size of a chunk size (in bytes) for a single upload.
        /// </summary>
        int MaxChunkSize { get; set; }

        /// <summary>
        /// Timeout after which a chunk request will fail.
        /// </summary>
        TimeSpan? Timeout { get; set; }

        /// <summary>
        /// User Ids who are allowed to use the uploaded media.
        /// </summary>
        List<long> AdditionalOwnerIds { get; set; }

        /// <summary>
        /// When an upload completes Twitter takes few seconds to process the media
        /// and confirm that it is a media that can be used on the platform. 
        /// With WaitForTwitterProcessing enabled, Tweetinvi will wait for Twitter
        /// to confirm that the media has been successfully processed.
        /// </summary>
        bool WaitForTwitterProcessing { get; set; }

        /// <summary>
        /// Additional parameters to use during the upload INIT HttpRequest.
        /// </summary>
        ICustomRequestParameters InitCustomRequestParameters { get; set; }

        /// <summary>
        /// Additional parameters to use during the upload APPEND HttpRequest.
        /// </summary>
        ICustomRequestParameters AppendCustomRequestParameters { get; set; }

        /// <summary>
        /// Event to notify that the upload state has changed
        /// </summary>
        Action<UploadStateChangedEventArgs> UploadStateChanged { get; set; }
    }

    /// <summary>
    /// https://dev.twitter.com/rest/media/uploading-media
    /// </summary>
    public class UploadQueryParameters : IUploadQueryParameters
    {

        public UploadQueryParameters()
        {
            Binaries = new List<byte[]>();
            MediaType = "media";
            MaxChunkSize = TweetinviConsts.UPLOAD_MAX_CHUNK_SIZE;
            AdditionalOwnerIds = new List<long>();
            WaitForTwitterProcessing = true;

            InitCustomRequestParameters = new CustomRequestParameters();
            AppendCustomRequestParameters = new CustomRequestParameters();
        }

        public List<byte[]> Binaries { get; set; }
        public string MediaType { get; set; }
        public string MediaCategory { get; set; }
        public int MaxChunkSize { get; set; }
        public TimeSpan? Timeout { get; set; }
        public List<long> AdditionalOwnerIds { get; set; }
        public bool WaitForTwitterProcessing { get; set; }

        public ICustomRequestParameters InitCustomRequestParameters { get; set; }
        public ICustomRequestParameters AppendCustomRequestParameters { get; set; }
        public Action<UploadStateChangedEventArgs> UploadStateChanged { get; set; }
    }
}