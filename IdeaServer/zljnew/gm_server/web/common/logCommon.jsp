<%@ include file="taglibs.jsp"%>
<link rel="stylesheet" type="text/css" href="jslib/jsTimePicker/timepicker.css" />
<script type="text/javascript" src="jslib/jsTimePicker/timepicker.js"></script>
<script type="text/javascript">
function sort(){
	  var sort = $("#sortImg").attr("src");
	  if(sort.indexOf("nav_down.gif")!=-1){
		  $("#sortImg").attr("src","images/nav_up.gif");
	  }else{
		  $("#sortImg").attr("src","images/nav_down.gif");
	   }
	  search(); 
}
function jumpTo(){
 var pno=$("#pno").val();
 if(is_int(pno)==false){
		alert('<%= lang.readGm(GMLangConstants.INTERVAL_NOT_NEG)%>');
		$("#pno").focus();
		return false;
	}
 goTo(pno);
 }
function list_sub_nav(Id){
    $("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
        });
   if($("#"+Id).attr("class") == "bg_image"){
	  $("#"+Id).attr("class","bg_image_onclick");
   }
   showInnerText(Id);
}

function showInnerText(Id){
    var switchId = parseInt(Id.substring(8));
	var showText = "";
	switch(switchId){
	    case 1:
		   $("#searchType").val("username");
		   break;
	    case 2:
		   $("#searchType").val("userId");
		   break;
	}
}
</script>
