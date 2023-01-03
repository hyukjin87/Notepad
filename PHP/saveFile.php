<?php   

/*
*        Decode the json file received from the client and save the file
*/

    $fileText = json_decode($_GET["data"]);
    $fileName = $fileText->{"name"};
    $text = $fileText->{"text"};
    // Save File
    $fp = fopen($fileName, "w");
    fwrite($fp,$text);
    fclose($fp);
    echo "Save File success";
?>