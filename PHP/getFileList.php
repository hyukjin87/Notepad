<?php

/*
*    DESCRIPTION     :
*        Add the files in the myFiles folder to the dropbox
*/

    $path = getcwd();
    $path .= "/myFiles";
    // default option value
    echo "<option id='fileSelect'>File List</option>";

    if(is_dir($path)){
        // Remove first and second array values (".", "..")
        $files = array_diff(scandir($path), array('.', '..'));
        
        foreach ($files as $fileList){
        echo "<option value='$fileList'>$fileList</option>";
        }
    }    
?>