using UnityEngine;
using System.Collections;
using System;
//using Renci.SshNet;          // SSH�ڑ��ɕK�v
//using Renci.SshNet.Common;   // SSH�֘A�̗�O�����ȂǂɕK�v
//using MySql.Data.MySqlClient; // MySQL�ڑ��ɕK�v
public class O_GetDB_Script : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public static string getDB()
    //{
    //    // ������̃z�X�g��
    //    string host = "iiiiii.sakura.ne.jp";
    //    // �����烆�[�U�[��
    //    string user = "iiiiii";
    //    // �p�X���[�h
    //    string Spassword = "password";


    //    // SSH�ڑ�
    //    var sshClient = new SshClient(host, 22, user, Spassword);
    //    sshClient.Connect();

    //    uint dbPort = 3306;
    //    uint localPort = 3306;
    //    //�f�[�^�x�[�X�̃f�[�^�x�[�X�̖��O�ƃ��[�U�[��
    //    string dbname = "DBname";
    //    string dbuser = "DBuser";
    //    string dbpassword = "Dpassword";
    //    //mysql0000.db�̂��
    //    string serverName = "mysql1018.db.sakura.ne.jp";

    //    //�T�[�o�[�t�H���[�f�B���O
    //    var sshForward = new ForwardedPortLocal("127.0.0.1", localPort, serverName, dbPort);
    //    sshClient.AddForwardedPort(sshForward);
    //    sshForward.Start();

    //    var connectStr = "server=" + "127.0.0.1" + ";";
    //    connectStr += "port=" + dbPort + ";";
    //    connectStr += "user=" + dbuser + ";";
    //    connectStr += "password=" + dbpassword + ";";
    //    connectStr += "database=" + dbname + ";";
    //    connectStr += "Pooling = False";

    //    string table = "testtb";

    //    //������SQL��������
    //    var sql = "SELECT * FROM " + table;

    //    string res = null;

    //    //MySQL�T�[�o�[�ڑ�
    //    using (var connection = new MySqlConnection(connectStr))
    //    using (var com = new MySqlCommand(sql, connection))
    //    {
    //        connection.Open();

    //        var selectCmd = new MySqlCommand(sql, connection);

    //        // ���s
    //        MySqlDataReader selectResult = selectCmd.ExecuteReader();

    //        // MySqlDataReader�Ƃ����N���X�Ɍ��ʂ������Ă���
    //        // Read()���ĂԂ��ƂŎ��̍s�ɃA�N�Z�X����

    //        while (selectResult.Read())
    //        {
    //            var name = selectResult.GetString("name");  // �t�B�[���h���ł̃A�N�Z�X
    //            string data = selectResult.GetString(1);  // �J�����C���f�b�N�X�ł̃A�N�Z�X
    //            if (name != "")
    //            {
    //                //�����ł��������ɏ���
    //                res += String.Format("{0}${1}\n", name, data);
    //            }
    //        }

    //        // ���ʂ����
    //        selectResult.Close();
    //        connection.Close();
    //        sshForward.Stop();
    //        sshClient.Disconnect();
    //        return res;
    //    }
    //}
}
