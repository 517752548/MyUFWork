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
