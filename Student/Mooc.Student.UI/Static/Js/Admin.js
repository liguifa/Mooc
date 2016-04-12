$(document).ready(function ()
{
    $(".menu-ul li").click(function ()
    {
        $(".menu-ul").find("li").attr("class", "");
        $(this).attr("class", "active");
        var url = $(this).attr("data-url");
        var parameters = "";
        var title = $(this).text();
        GetHtmlContext(url, parameters,title);
    });
    function GetHtmlContext(url, parameters,title)
    {
        //$("#operation").empty();
        //$("#operation").prepend("<div style='windth:180px;margin:auto;margin-top:200px;text-align:center'><img src=\"../../images/loading.gif\"><p>玩命加载中....</p><div>");
        $.ajax({
            type: "post",
            url: url,
            data: {
            },
            dataType: "html",
            success: function (data)
            {
                $("#handle").tabs('add',{
                    title: title,
                    content:data,
                    closable:true
                });
            }
        });
    }
});