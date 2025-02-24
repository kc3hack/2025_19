<?php
// add_data.php

// JSONファイルのパス
$jsonFilePath = './userdata.json';

// POSTされたJSONデータを受け取る
$jsonData = file_get_contents('php://input');

// JSONデータをデコード
$newData = json_decode($jsonData, true);

// JSONファイルが存在するか確認
if (file_exists($jsonFilePath)) {
    // 既存のJSONファイルを読み込む
    $jsonString = file_get_contents($jsonFilePath);

    // JSON文字列が空でなければ、デコードを試みる。空なら空の配列を使う
    if (!empty($jsonString)) {
        // JSONを連想配列にデコード (true を指定)
        $existingData = json_decode($jsonString, true);

        // JSONの形式が不正な場合はエラーを出力して終了(空の場合はエラーにしない）
        if (json_last_error() !== JSON_ERROR_NONE) {
            http_response_code(500); // Internal Server Error
            echo json_encode(array("error" => "Invalid JSON format in existing file."));
            exit;
        }
    } 
    else {
        $existingData = array("users" => array()); // 空の配列
    }

    // 新しいデータを users 配列に追加
    if (isset($existingData['users']) && is_array($existingData['users'])) {
        $existingData['users'][] = $newData;  // 既存の配列に追加
    } 
    else {
        // users キーが存在しないか、配列でない場合。
        http_response_code(500);
        echo json_encode(array("error" => "Invalid JSON structure in existing file. 'users' key is missing or not an array."));
        exit;
    }
} 
else {
    // ファイルが存在しない場合は、新しい配列を作成
    $existingData = array("users" => array($newData));  // 新しいデータを含む配列
}

// 更新されたデータをJSON形式にエンコード (整形)
$updatedJsonString = json_encode($existingData, JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE);

// JSONファイルに書き込む
if (file_put_contents($jsonFilePath, $updatedJsonString) === FALSE) {  // === FALSE で厳密に比較
    http_response_code(500); // Internal Server Error
    echo json_encode(array("error" => "Failed to write to file."));
} 

else {
    echo json_encode(array("success" => true));
}
