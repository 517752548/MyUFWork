<%@ page language="java" contentType="text/html; charset=UTF-8"  pageEncoding="UTF-8"%>
<%@ include file="../../common/taglibs.jsp"%>

<script type="text/javascript" src="jslib/jquery.js"></script>
<style type="text/css">
  #pageBut{
  margin-left: 30%;
  }
  #num_style a {
       display:inline;
	    clear:both;
		background:#F7F9FF none repeat scroll 0;
		border:1px solid #B2C9D3;
		color:#333333;
		font-size:12px;
		margin-right:3px;
		padding:3px 6px 2px;
		text-decoration:none;
		height: 50px;
		display: inline;
}
 .curPage{
   color: red;
  }
  #pno{  
  display: inline;
  border: 1px solid rgb(122, 174, 189);
  width: 25px; height: 12px; 
  font-size: 12px;
  }
</style>
<script type="text/javascript">
  function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&searchType="+searchType+"&searchValue="+searchValue;
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

</script>
<div id="num_style"></data>
</div>