using UnityEngine;
using System.Collections;
using System;
//using Renci.SshNet;          // SSH接続に必要
//using Renci.SshNet.Common;   // SSH関連の例外処理などに必要
//using MySql.Data.MySqlClient; // MySQL接続に必要
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
    //    // さくらのホスト名
    //    string host = "iiiiii.sakura.ne.jp";
    //    // さくらユーザー名
    //    string user = "iiiiii";
    //    // パスワード
    //    string Spassword = "password";


    //    // SSH接続
    //    var sshClient = new SshClient(host, 22, user, Spassword);
    //    sshClient.Connect();

    //    uint dbPort = 3306;
    //    uint localPort = 3306;
    //    //データベースのデータベースの名前とユーザー名
    //    string dbname = "DBname";
    //    string dbuser = "DBuser";
    //    string dbpassword = "Dpassword";
    //    //mysql0000.dbのやつ
    //    string serverName = "mysql1018.db.sakura.ne.jp";

    //    //サーバーフォワーディング
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

    //    //ここにSQL文を書く
    //    var sql = "SELECT * FROM " + table;

    //    string res = null;

    //    //MySQLサーバー接続
    //    using (var connection = new MySqlConnection(connectStr))
    //    using (var com = new MySqlCommand(sql, connection))
    //    {
    //        connection.Open();

    //        var selectCmd = new MySqlCommand(sql, connection);

    //        // 実行
    //        MySqlDataReader selectResult = selectCmd.ExecuteReader();

    //        // MySqlDataReaderというクラスに結果が入っている
    //        // Read()を呼ぶことで次の行にアクセスする

    //        while (selectResult.Read())
    //        {
    //            var name = selectResult.GetString("name");  // フィールド名でのアクセス
    //            string data = selectResult.GetString(1);  // カラムインデックスでのアクセス
    //            if (name != "")
    //            {
    //                //ここでいい感じに処理
    //                res += String.Format("{0}${1}\n", name, data);
    //            }
    //        }

    //        // 結果を閉じる
    //        selectResult.Close();
    //        connection.Close();
    //        sshForward.Stop();
    //        sshClient.Disconnect();
    //        return res;
    //    }
    //}
}
