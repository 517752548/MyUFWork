<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<%@ include file="../../../common/logHeader.jsp"%>
<%@ include file="../../../common/logEnder.jsp"%>

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
	  window.location.href="basicLog.do?action=init&currentPage="+i+"&roleID="+roleID+"&date="+date+"&reason="+reason+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime+"&logType="+logType//Mark2;
}
function search(){
	  //Mark3
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
	  window.location.href="basicLog.do?action=init&roleID="+roleID+"&date="+date+"&reason="+reason+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime+"&logType="+logType//Mark4;
	}
function searchs(opporationType,opporationValue){
	  //Mark3
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
	  window.location.href="basicLog.do?action=init&roleID="+roleID+"&date="+date+"&reason="+reason+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime+"&logType="+logType+opporationType+opporationValue//Mark4;
	}
</script>