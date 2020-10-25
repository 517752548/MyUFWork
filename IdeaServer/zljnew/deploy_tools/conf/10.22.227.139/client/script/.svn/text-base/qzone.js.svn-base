/**应用连接后面的参数字符串*/
var qqurlcookie;


/**从应用连接后面的参数字符串中 获得 某个字段的值*/
function getQzoneUrlcookieParam(key){
	var pairs=qqurlcookie.split('&');
	var targetKey = name+'=';
	
	for(var i=0;i<pairs.length;i++)
	{
		if(pairs[i].indexOf(key)==0)
		{
			return pairs[i].replace(key,'');
		}
	}
	return  'fail';
}
/**
获得应用连接后面的参数
*/
function getQzoneUrlcookie(){
		var url = location.href;
		qqurlcookie = url.substr(url.indexOf("?")+1);
		if(qqurlcookie==''){
			return 'fail';
		}else{
		 	return qqurlcookie;
		}
}

/**
重新登录
*/
function relogin(){
	fusion2.dialog.relogin();	
}

/**
获取flash
*/
function getfl(){
	var fl=document.getElementById("index");
	if (fl == null)
	{
		fl=document.getElementById("BattleReportPlayer");
	}
	return fl;
}
/**
qq充值，包括(空间 朋友 微博)
*/
function fusion2_buy(disturb,param,sandbox,context)
{
	fusion2.dialog.buy({disturb:disturb,param:param,sandbox:sandbox,context:context,
	onSuccess:qq_buySuccess,onCancel:qq_buyCancel,onSend:qq_buySend,onClose:qq_buyClose});
}

function qq_buySuccess(opt){
	var fl = getfl();
	if(fl&&fl.qq_buySuccess)
	{
		fl.qq_buySuccess(opt);
	}
}

function qq_buyCancel(opt){
	var fl = getfl();
	if(fl&&fl.qq_buyCancel)
	{
		fl.qq_buyCancel(opt);
	}
}

function qq_buySend(opt){
	var fl = getfl();
	if(fl&&fl.qq_buySend)
	{
		fl.qq_buySend(opt);
	}
}

function qq_buyClose(opt){
	var fl = getfl();
	if(fl&&fl.qq_buyClose)
	{
		fl.qq_buyClose(opt);
	}
}


/**
开通黄钻
*/
function openVipGift(token,actid,zoneid,openid,version,paytime,defaultMonth,ch,pf,context)
{
	fusion2.dialog.openVipGift({token:token,actid:actid,zoneid:zoneid,openid:openid,version:version,
	paytime:paytime,defaultMonth:defaultMonth,ch:ch,pf:pf,contex:context,context:context,
	onSuccess:openVipGiftSuccess,onError:openVipGiftError,onClose:openVipGiftClose});
}

/**
开通黄钻成功
*/
function openVipGiftSuccess(opt){	
	var fl = getfl();
	if(fl&&fl.openVipGiftSuccess)
	{
		//opt.context;
		fl.openVipGiftSuccess(opt);
	}
}

/**
开通黄钻失败
*/
function openVipGiftError(opt){	
	var fl = getfl();
	if(fl&&fl.openVipGiftError)
	{
		fl.openVipGiftError(opt);
	}
}

/**
关闭开通黄钻界面
*/
function openVipGiftClose(opt){
	var fl = getfl();
	if(fl&&fl.openVipGiftClose)
	{
		fl.openVipGiftClose(opt);
	}
}

//分享
function sendStory(title,img,summary,msg,source,context)
{
	//if (pf == "pengyou" || pf == "qzone") {
		fusion2.dialog.sendStory
		({
		  title :title,
		  img:img,
		  //receiver:['17913234859447759108D9371','1353734266'],
		  summary :summary,
		  msg:msg,
		  //button :"进入应用",
		  source :source,
		  context:context,		  
		  onShown: qq_shareShown,
		  onSuccess:qq_shareSuccess,
		  onCancel:qq_shareCancel,
		  onClose: qq_shareClose
		});
	//}
}

function qq_shareSuccess(opt){
	var fl = getfl();
	if(fl&&fl.qq_shareSuccess)
	{
		fl.qq_shareSuccess(opt);
	}
}

function qq_shareCancel(opt){
	var fl = getfl();
	if(fl&&fl.qq_shareCancel)
	{
		fl.qq_shareCancel(opt);
	}
}

function qq_shareShown(opt){
	var fl = getfl();
	if(fl&&fl.qq_shareShown)
	{
		fl.qq_shareShown(opt);
	}
}

function qq_shareClose(opt){
	var fl = getfl();
	if(fl&&fl.qq_shareClose)
	{
		fl.qq_shareClose(opt);
	}
}

//好友邀请
function inviteFriend(msg,source,context)
{
	//if(pf == "pengyou" || pf == "qzone" || pf == "weibo"){
		var param = {
		  //receiver : "00000000000000000000000000009FED",
		  msg  : msg,
		  //img : "http://i.gtimg.cn/open/app_icon/01/34/61/27//1101346127_100.png",
		  source : source,
		  context : context,
		  onSuccess :qq_inviteSuccess,
		  onCancel :qq_inviteCancel,
		  onClose :qq_inviteClose
		};
		fusion2.dialog.invite(param);
	//}
}

function qq_inviteSuccess(opt){
	var fl = getfl();
	if(fl&&fl.qq_inviteSuccess)
	{
		fl.qq_inviteSuccess(opt);
	}
}

function qq_inviteCancel(opt){
	var fl = getfl();
	if(fl&&fl.qq_inviteCancel)
	{
		fl.qq_inviteCancel(opt);
	}
}

function qq_inviteClose(opt){
	var fl = getfl();
	if(fl&&fl.qq_inviteClose)
	{
		fl.qq_inviteClose(opt);
	}
}