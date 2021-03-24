_G._T = function(str)
	--遍历整个项目代码找出_T这个全局方法包含的字符，然后将其统一生成一个KEY VALUE的文件，然后在这里再加入相应的多语言表查找逻辑找出
	--所以暂时咱项目中涉及到多语言的地方直接用_T包含一下就可以了
	if not str or str == "" then
		return "KEY is empty"
	end
	local result = t_text[str]
	if result then
		return result.EN
	else
		return str
	end
end