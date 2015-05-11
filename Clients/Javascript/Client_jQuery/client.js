/**
 * Created by Administrator on 12/03/2015.
 */


$("#invokeWcf").on("click",function(){

    var inputData={
        Customer:{
            FirstName:'Steve',
            LastName: "Jobs"
        },
        Account:{UserName:'my_user_name',Password:'my_password'}
    };

    var url=$("#wcfAddress").prop("value");
    $.ajax(url,{
            type:'POST',
            dataType:"json",
            contentType:'application/json; charset=utf-8;',
            data: JSON.stringify(inputData) ,
            success:function(response){
                console.log(response);
            },
            error:function(response,errorType,errorMessage){
                console.log(errorMessage);
            }
        }
    );


});