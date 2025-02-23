using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

public class K_MapTexter : MonoBehaviour
{
    //URL���}�b�v��\������B
//    center �}�b�v�̒��S�̈ʒu�B����,���W���\
//markers �}�[�J�[�̈ʒu�B�u|�v�ɂ�蕡���}�[�J�[��ݒu���邱�Ƃ��\ ����, ���W���\
//key API�̃L�[�������B
//zoom 1�`21�ŕύX�\ �傫������قǔ{������
//maptype �\���`����ς���B�ȉ��̒ʂ�
//roadmap: �ʏ�̓��H�n�}��\��
//satellite: �q���ʐ^��\��
//hybrid: �n�C�u���b�h�n�}��\��
//terrain: �n�`�}��\��

    private const string STATIC_MAP_URL = "https://maps.googleapis.com/maps/api/staticmap?key=AIzaSyAYgTXuEofJwvKwEwX1RqYwlUS4CJzcxK8&size=320x640&scale=2&maptype=roadmap";

    //�s����ۑ����邽�߂�double�^��List �o�x�ƈܓx��2��
    public List<double> pin_latitude = new List<double>();
    public List<double> pin_longitude = new List<double>();
    public int zoom=15;

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
        // �񓯊������H���߂Ɉ��ĂԁB
        StartCoroutine(getStaticMap());
    }

    //�O������ĂԂ��߂ɕ������B
    public void ReloadMap()
    {
        if (zoom > 20 || zoom < 0)
        {
            zoom = 15;
        }
        StartCoroutine(getStaticMap());
    }

    //�}�b�v�̓��e���X�V����֐��@Reload�ŌĂ΂��֐�
    IEnumerator getStaticMap()
    {
        //�ύX���邽�߂̕������ۑ�������string
        var query="";

        query += "&zoom=" + zoom;
        // center�Ŏ擾����~�j�}�b�v�̒������W��ݒ�@Input.location.lastData��GPS�ɂ�錻�݂̍��W���擾
        query += "&center=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));

        pin_latitude.Add(Input.location.lastData.latitude);
        pin_longitude.Add(Input.location.lastData.longitude);

        //�ۑ�����Ă���}�[�J�[�̉񐔌J��Ԃ��B
        for (int i = 0; i < pin_longitude.Count; i++)
        {
            // markers�œn�������W(=���݈ʒu)�Ƀ}�[�J�[�𗧂Ă�
            query += "&markers=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", pin_latitude[i], pin_longitude[i]));
        }
        // ���N�G�X�g�̒�`
        var req = UnityWebRequestTexture.GetTexture(STATIC_MAP_URL + query);

        Debug.Log(req);
        // ���N�G�X�g���s
        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("�}�b�v�摜�̎擾�G���[: " + req.error);
        }
        else
        {
            // �擾����Texture2D����Sprite���쐬
            Texture2D texture = ((DownloadHandlerTexture)req.downloadHandler).texture;
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            // Image�R���|�[�l���g��sprite�v���p�e�B���X�V
            Image targetImage = GetComponent<Image>();
            if (targetImage != null)
            {
                targetImage.sprite = newSprite;

                // �Â�Sprite�������Destroy (���������[�N�΍� - �K�v�ɉ�����)
                if (targetImage.sprite != newSprite && targetImage.sprite != null)
                {
                    Destroy(targetImage.sprite);
                }
            }
            else
            {
                Debug.LogError("Image�R���|�[�l���g��������܂���I");
            }
        }
    }
}
