_G.Admob = {}

function Admob:Init()
    self.admobad = AdmobAD.New()
    self.admobad:Init()
end 

function Admob:ShowReward(back)
    self.admobad:ShowADVideo(function(ok)
        back(ok)
    end)
end 