
using System;
using System.Net;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageDownloadSetUtility : MonoBehaviour {

    public string urlToSetImageFrom;

    private Image _image;

    private void Awake () {

        _image = GetComponent<Image>();
    }

    private void Start () {

        WebClient webClient = new WebClient();

        webClient.DownloadDataCompleted += OnDownloadFinish;
        webClient.DownloadDataAsync(new Uri(urlToSetImageFrom));
    }

    private void OnDownloadFinish (object sender, DownloadDataCompletedEventArgs e) {

        if (e.Error != null) {

            Debug.LogError("Failed to download Url! '" + urlToSetImageFrom + "'");
            return;
        }

        Texture2D texture = new Texture2D(64,64, TextureFormat.Alpha8, false);
        texture.LoadImage(e.Result);
        _image.sprite = Sprite.Create(texture,
            new Rect(0,0, texture.width, texture.height),
            new Vector2(.5f,.5f), 100
        );
    }
}
