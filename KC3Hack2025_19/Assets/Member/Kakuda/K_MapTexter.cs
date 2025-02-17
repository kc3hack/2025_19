using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class K_MapTexter : MonoBehaviour
{
    private const string STATIC_MAP_URL = "https://maps.googleapis.com/maps/api/staticmap?key=AIzaSyAYgTXuEofJwvKwEwX1RqYwlUS4CJzcxK8&zoom=15&size=640x640&scale=2&maptype=roadmap";

    public List<double> pin_latitude = new List<double>();
    public List<double> pin_longitude = new List<double>();

    // Start is called before the first frame update
    void Start()
    {
        // �񓯊�����
        StartCoroutine(getStaticMap());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReloadMap()
    {
        StartCoroutine(getStaticMap());
    }

    IEnumerator getStaticMap()
    {
        Debug.Log("GetMap");
        var query = "";

        // center�Ŏ擾����~�j�}�b�v�̒������W��ݒ�
        query += "&center=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));

        for (int i = 0; i < pin_longitude.Count; i++)
        {
            // markers�œn�������W(=���݈ʒu)�Ƀ}�[�J�[�𗧂Ă�
            query += "&markers=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", pin_latitude[i], pin_longitude[i]));
        }
        // ���N�G�X�g�̒�`
        var req = UnityWebRequestTexture.GetTexture(STATIC_MAP_URL + query);
        // ���N�G�X�g���s
        yield return req.SendWebRequest();

        if (req.error == null)
        {
            // ���łɕ\�����Ă���}�b�v���X�V
            Destroy(GetComponent<Renderer>().material.mainTexture);
            GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)req.downloadHandler).texture;
        }
    }
}
