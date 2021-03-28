_G.LoginModel    = Model.New()

LoginModel.token = nil

function LoginModel:SetToken(val)
	self.token = val
end

function LoginModel:GetToken()
	return self.token
end

function LoginModel:OnLogoutGame()
	self.token = nil
end

--调用支付宝的逻辑
function LoginModel:CallPay()
	local androidcall = AndroidCall.New()
	androidcall:SetClassName("com.alipay.AliPayActivity")
	local unitycs = UnityReceiveNativeMessage.New("com.alipay.UnityListener")
	unitycs:SetLuaListener(function(id,intvalue,strvalue)
		logError(strvalue)
	end)
	androidcall:CallMethod_Para("SetListener",unitycs)
	androidcall:SetActivity()
	androidcall:CallMethod("payV2")
end
