/*
*    DESCRIPTION     :
*        Handler for text editor events created using jquery.
*        Loads a list of files in the myFiles folder 
*        and provides functionality based on button selection.
*/

// FUNCTION     : $(document).ready(function()
// DESCRIPTION  : When the web page is launched, 
//                the list of myFiles folders is retrieved through the post method
// PARAMETERS   : none
// RETURNS      : none
$(document).ready(function(){
    $.post("getFileList.php", function(data){  
        $("#fileList").html(data);
    })
});


// FUNCTION     : $("#fileList").change(function()
// DESCRIPTION  : When user select a file in the file list, add the name to the saved file
// PARAMETERS   : none
// RETURNS      : none
$("#fileList").change(function(){
    $("#saveFileName").val($("#fileList").val());
});


// FUNCTION     : $("#btn_openFile").click(function()
// DESCRIPTION  : Loads the contents of a file in the file list
// PARAMETERS   : none
// RETURNS      : none
$("#btn_openFile").click(function(){    
    $.post("openFile.php", {name: $("#fileList").val()}, function(data){
        $("#editor").val(data);
    })   
});


// FUNCTION     : $("#btn_saveFile").click(function()
// DESCRIPTION  : Save the file with the applied file name
// PARAMETERS   : none
// RETURNS      : none
$("#btn_saveFile").click(function(){
    var checkFileName = $("#saveFileName").val();
    var fileName = "myFiles/" + $("#saveFileName").val();
    if(checkFileName == ""){
        alert("You should input the file name");
    }else{
        var text = $("#editor").val().replace(/\r?\n/g,"\\n").toString();
        var json = '{"name":"' + fileName + '","text":"' + text + '"}';
        $.get("saveFile.php?data="+json, function(data){
            $("#editor").val(data);
        });
    }
});

