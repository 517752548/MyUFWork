<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<%@ include file="logHeader.jsp"%>
<%@ include file="logEnder.jsp"%>

<script type="text/javascript">
function goTo(i){
	  //Mark1
	  var sort = $("#sortImg").attr("src");
	  var sortType="log_time";
	  var order="asc";
	  var logType=Request.QueryString("logType");
	  if(sort.indexOf("nav_down.gif")!=-1){
		  sortType="log_time";
		  order="desc";
	  }
	  var roleID = $("#roleID").val();
	  var date = $("#date").val();
	  var reason=$("#reason").val();
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  
	  var serchStr= serchSb();
	  if(!serchStr){
		 // alert("!failure");
		  window.location.href="autoLog.do?action=init&currentPage="+i+"&roleID="+roleID+"&date="+date+"&reason="+reason+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime+"&logType="+logType//Mark2;	  
	  }else{
		//  alert("!success");
		  window.location.href="autoLog.do?action=init&currentPage="+i+"&roleID="+roleID+"&date="+date+"&reason="+reason+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime+"&logType="+logType+serchStr//Mark4;
	  } 
}
function search(){
	  //Mark3
	  var i = serchCurrencyPage();
	  goTo(i);
}
function searchs(){
	var i = serchCurrencyPage();
	goTo(i);
}
</script>