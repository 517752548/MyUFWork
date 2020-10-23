/**
 * 为了后面扩展方法留下的文件，部署的时候做到只需要替换即可
 */

function favSite()
{
       setTimeout("dalyFavorite();",500);
}

//收藏网站代码 
function dalyFavorite() {
    if (window.sidebar) {
         window.sidebar.addPanel(agents().webTitle, agents().favorite,"");
         return true;
    } else if( document.all ) {
    	try{
    		 window.external.AddFavorite(agents().favorite, agents().webTitle);
         	return true;
    	}catch(error){
    		return true;
    	}
    } else if( window.opera && window.print ) {
         return true;
    }
}

//跳转到官网登录页面
function gotoLoginPage(){
	var url = agents().loginWebSite;
	if(url!=""){
 		url=url;
 		return url;
	}
	return url;
}

//跳转到官网首页
function gotoWebSite(){
	var url = agents().webSite;
	if(url!=""){
 		url=url;
 		return url;
	}
	return url;
}

//跳转到官网论坛
function gotoWebBBS(){
	var url = agents().bbSWebSite;
	if(url!=""){
 		url=url;
 		return url;
	}
	return url;
}

//跳转到官网帮助页面
function gotoWebHelp(){
	var url = agents().helpWebSite;
	if(url!=""){
 		url=url;
 		return url;
	}
	return url;
}

//跳转到官网充值页面
function gotoWebAddMoney(username){
	var url = agents().moneyWebSite;
	if(url!=""){
 		url=url + username;
 		return url;
	}
	return url;
}

function ltrim(s){
    return s.replace( /^[" "|"　"]*/, "");
}
//去右空格;
function rtrim(s){
     return s.replace( /[" "|"　"]*$/, "");
}
//左右空格;
function trim(s){
     return rtrim(ltrim(s));
}


//获取跳转统计的地址
//type 操作类型 1- 打开页面, 2- 下载游戏, 3-创建账号 
function getRecordUrl(userName, playerName, type){
	if(serverObj.recordUrl==""){
		return "";
	}
	var url = serverObj.recordUrl + "?";
	if(userName!= null && userName != ""){
		url = url+"userName="+userName+"&";
	}
	if(playerName!= null && playerName != ""){
		url = url+"playerName="+playerName+"&";
	}
	if(type!= null && type != ""){
		url = url+"type="+type;
	}
	return url;
}

//保存快捷方式
function collectGame(){
	var warning="收藏《战龙决》到收藏夹，以便下次登录游戏"; 
	//alert(warning);
	return "shortcut.php" + "?filename=" + agents().webTitle + "&URL=" + agents().loginWebSite ;
}


//设置关闭页面是否弹出收藏夹
function setUnloadHandler(count){
	if(count <= 1){
		window.onbeforeunload = onbeforeunloadHandler; 
		window.onunload = onunloadHandler; 
	}
}


//关闭页面弹出收藏游戏网址
function onbeforeunloadHandler(){ 
	var warning="添加《战龙决》到收藏夹，以便下次登录游戏？";    
	if(confirm(warning)){
		dalyFavorite();
	}else{
		//dalyFavorite();
	}
	
} 

function onunloadHandler(){ 
   //dalyFavorite();
}

//退出游戏地址
function exitGame(){
	var url = agents().exitGame;
	if(url!=""){
 		url=url;
 		return url;
	}
	return url;
}


var testConfig = new Object;
testConfig.isShowSystemTime = false;     //是否显示系统时间,false表示不显示,true表示显示
testConfig.isShowGuiderMC = true;       //是否播放新手任务的动画,false表示不播放,true表示播放
testConfig.isLog = false;                //快捷键是否可以打开客户端log,false表示不可以,true表示可以

/**
 * 0-非Debug，1-Debug模式，显示“清缓存”按钮
 */
function debug() {
	return 1;
}

function testConf()
{
    return testConfig;
}

/**
 * 刷新当前页
 */
function refreshPage()
{
	location.replace(location.href);
}

//添加浏览器尺寸改变的侦听
function addResizeListener()
{
	//reSize();
	//window.onresize = function(){reSize();}
}

var rect = new Object;
rect.minWidth = 800;
rect.minHeight = 400;
rect.maxWidth = 1250;
rect.maxHeight = 650;

//全屏
function resize()
{
	var isMain = true;
	var fl=document.getElementById("index");
	if (fl == null)
	{
		isMain = false;
		fl=document.getElementById("BattleReportPlayer");
	}
	//获取窗口宽度
 	if (window.innerWidth)
 	{
   		 winWidth = window.innerWidth;
    }
    else if ((document.body) && (document.body.clientWidth))
    {
    	winWidth = document.body.clientWidth;
    }
    //获取窗口高度
    if (window.innerHeight)
    {
    	winHeight = window.innerHeight;
    }
    else if ((document.body) && (document.body.clientHeight))
    {
    	winHeight = document.body.clientHeight;
    }
    //通过深入Document内部对body进行检测，获取窗口大小
 //   if (document.documentElement  && document.documentElement.clientHeight && document.documentElement.clientWidth)
    //{
    	//winHeight = document.documentElement.clientHeight;
    	//winWidth = document.documentElement.clientWidth;
   // }
    //结果输出至两个文本框
	if (winWidth < rect.minWidth)
	{
		winWidth = rect.minWidth;
	}
	else if (winWidth > rect.maxWidth)
	{
		winWidth = rect.maxWidth;
	}
	if (winHeight < rect.minHeight)
	{
		winHeight = rect.minHeight;
	}
	else if (winHeight > rect.maxHeight)
	{
		winHeight = rect.maxHeight;
	}
	if(isMain)
	{
		if(fl.resetSize)
		{
			fl.resetSize(winWidth,winHeight,"js");
		}
	}
	//fl.width = winWidth;
	//fl.height = winHeight;
}

function getBrowerWH()
{
	var winWidth;
	var winHeight;
	if (window.innerWidth)
 	{
   		 winWidth = window.innerWidth;
    }
    else if ((document.body) && (document.body.clientWidth))
    {
    	winWidth = document.body.clientWidth;
    }
    //获取窗口高度
    if (window.innerHeight)
    {
    	winHeight = window.innerHeight;
    }
    else if ((document.body) && (document.body.clientHeight))
    {
    	winHeight = document.body.clientHeight;
    }
    //通过深入Document内部对body进行检测，获取窗口大小
 //   if (document.documentElement  && document.documentElement.clientHeight && document.documentElement.clientWidth)
    //{
    	//winHeight = document.documentElement.clientHeight;
    	//winWidth = document.documentElement.clientWidth;
   // }
    //结果输出至两个文本框
	if (winWidth < rect.minWidth)
	{
		winWidth = rect.minWidth;
	}
	else if (winWidth > rect.maxWidth)
	{
		winWidth = rect.maxWidth;
	}
	if (winHeight < rect.minHeight)
	{
		winHeight = rect.minHeight;
	}
	else if (winHeight > rect.maxHeight)
	{
		winHeight = rect.maxHeight;
	}
	return [winWidth,winHeight];
} 
//收藏网站代码 
function myAddFavorite() {

   if(!getCookie("lgCookie"))
   {
	    setCookie("lgCookie", 1);
	    if (window.sidebar) {
	         window.sidebar.addPanel(agents().webTitle, agents().favorite,"");
	         return true;
	    } else if( document.all ) {
	    	try{
	    		 window.external.AddFavorite(agents().favorite, agents().webTitle);
	         	return true;
	    	}catch(error){
	    		return true;
	    	}
	    } else if( window.opera && window.print ) {
	         return true;
	    }
    }
}
function setCookie(sName, sValue)
{
   date = new Date();
   date.setYear(date.getYear()+1)
   document.cookie = sName + "=" + escape(sValue) + "; expires=" + date.toGMTString();
}
function getCookie(sName)
{
	// cookies are separated by semicolons
	var aCookie = document.cookie.split("; ");
	for (var i=0; i < aCookie.length; i++)
	{
	// a name/value pair (a crumb) is separated by an equal sign
	var aCrumb = aCookie[i].split("=");
	if (sName == aCrumb[0])
	return unescape(aCrumb[1]);
	}
}

function getUrlcookie(name){
		var url = location.href;
		var gameCookie = url.substr(url.indexOf("?")+1);
		if(gameCookie=='') return 'fail';
		var pairs=gameCookie.split('&');
		var targetKey = name+'=';
		
		for(var i=0;i<pairs.length;i++)
		{
			if(pairs[i].indexOf(targetKey)==0)
			{
				return pairs[i].replace(targetKey,'');
			}
		}
		return  'fail';
}

//商战创世纪
function getcookiecsj(name) {
	   //var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
	   //if (arr != null){
       //     return unescape(arr[2]);
       //}else{
       		return getUrlcookie(name);
       //}
}

