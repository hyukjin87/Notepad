<?php

/*
*    DESCRIPTION     :
*        Pass the contents of the file located in the myFiles folder to the client
*/

    $fileName = $_POST["name"];
    $path = getcwd();
    $path .= "/myFiles//";
    $path .= $fileName;
    $fp = fopen($path,"r");
    // Check Paths
    if(isSet($fileName)){
        if(!$fp){
            die("Failed to open file, Please check the file path");
          }
          else{
            while(!feof($fp)){
              $fileText = fgets($fp);              
            }
            fclose($fp);
          }        
        echo $fileText;
    }

?>