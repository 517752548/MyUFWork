function is_null(elem) {
	// var pattern=/^\s+|\s+$/;
	if (elem.replace(/(^\s+|\s$)/g, "") == "") {
		return true;
	} else {
		return false;
	}
}
//数字
function is_num(elem){
  var pattern=/^[-]?[0-9]+$/;
  if(pattern.test(elem)){
	  return true;
  } else {
	  return false;
  }
    
}
//小数
function is_float(elem){
 var pattern=/^[-]?[0-9]+.[0-9]+$/;
 if(pattern.test(elem))
   return true;
 else
   return false;
}
//非负小数
function is_zfloat(elem){
 var pattern=/^[0-9]+.[0-9]+$/;
 if(pattern.test(elem))
   return true;
 else
   return false;
}


function is_int(elem){
	var pattern=/^([1-9][0-9]*)+$/;
	if(pattern.test(elem))
	return true;
	else return false;
}
//包含0的自然数
function is_int0(elem){
	var pattern=/^[0-9]+$/;
	if(pattern.test(elem))
	return true;
	else return false;
}
function is_intplus(elem){
	var pattern=/^[1-9]+$/;
	if(pattern.test(elem))
	return true;
	else
	return false;
}
//判断用户名：字母开头，2－32个字节，允许字母数字下划线
function is_username(s){
	var pattern = /^[a-zA-Z][a-zA-Z0-9_]{1,31}$/ig;
	if(!pattern.exec(s)) return false;
	return true;
}
//判断密码：字母数字开头，2－32个字节，允许字母数字下划线
function is_password(s){
	var pattern = /^[a-zA-Z0-9][a-zA-Z0-9_]{1,31}/ig;
	if(!pattern.exec(s)) return false;
	return true;
}
//判断时间戳
function validDateTime(d) {
	var regex = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$/;
	if (!regex.test(d)) {
			return false;
	}
	return true;
}

function validDate(d){
	var regex = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$/;
	if (!regex.test(d)) {
			return false;
	}
	return true;
}

function validTime(t){
	var regex = /^(20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$/;
	if (!regex.test(t)) {
			return false;
	}
}

//判断一个数组是否包含val值
function isContain(arr,val){
	var array = arr.split(",");
	var flag= false;
	for(var i= 0; i<array.length;i++){
       if($.trim(array[i])==$.trim(val)){
    	   flag = true;
    	   break;
        }
	}
	return flag;
}
