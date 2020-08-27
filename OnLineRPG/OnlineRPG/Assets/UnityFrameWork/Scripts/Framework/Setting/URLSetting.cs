using BetaFramework;

public static class URLSetting
{
   

    public static string APP_LOGIN_URL
    {
        get
        {
            //同步数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/calmRegister";
            }
            else
            {
                return "https://us-central1-wordcrossytwo.cloudfunctions.net/calmRegister";
            }
        }
    }

    

    public static string SERVER_SYNC_URL
    {
        get
        {
            //同步数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeUpdateAData";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeUpdateAData";
            }
        }
    }

    
    public static string SERVER_FastRaceRankList_URL
    {
        get
        {
            //同步数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/crazeAcGet";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeAcGet";
            }
        }
    }
    
    
    public static string SERVER_FastRaceGetReward_URL
    {
        get
        {
            //同步数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/crazeAcAward";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeAcAward";
            }
        }
    }
    
    public static string SERVER_UPLOAD_URL
    {
        get
        {
            //上传本地数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeWriteAdata";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeWriteAdata";
            }
        }
    }

    public static string SERVER_VALIDATERECEIPT_URL
    {
        get
        {
            //内购校验地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeRecharge";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeRecharge";
            }
        }
    }
    
    public static string SERVER_FastRaceUploadScore_URL
    {
        get
        {
            //同步数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/crazeAcUp";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeAcUp";
            }
        }
    }
    
    public static string SERVER_FastRaceMyRank_URL
    {
        get
        {
            //同步数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/crazeAcRink";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeAcRink";
            }
        }
    }

    public static string SERVER_GIFT_URL
    {
        get
        {
            //内购礼包地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeInitBusiness";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeInitBusiness";
            }
        }
    }

    public static string SERVER_BG_URL
    {
        get
        {
            //背景图地址
            return "http://game.online.wordzhgame.net/api/wordMania/levelbg?platform={0}&level={1}";
        }
    }

    public static string SERVER_FastRaceRoom_URL
    {
        get
        {
            //同步数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/crazeAcRoom";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeAcRoom";
            }
        }
    }
    
    public static string PetFromLine
    {
        get
        {

            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/calmGetProfile";
            }
            else
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/calmGetProfile";
            }
        }
    }

    public static string SERVER_FastRaceConfig_URL
    {
        get
        {
            //同步数据地址
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/crazeAcInit";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeAcInit";
            }
        }
    }
    
    public static string SERVER_DAILYSIGN_CONFIG
    {
        get
        {
            //每日签到礼物配置
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/giftDailyInit";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/giftDailyInit";
            }
        }
    }
    
    public static string SERVER_PRIZECLAW_CONFIG
    {
        get
        {
            //娃娃机配置
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/dollMachine";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/dollMachine";
            }
        }
    }
   
    public static string SERVER_WEEKRANK_UPLOAD_URL
    {
        get
        {
            //锦标赛数据上传
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeActiveUpload";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeActiveUpload";
            }
        }
    }

    public static string SERVER_WEEKRANK_GET_URL
    {
        get
        {
            //锦标赛排行榜获取
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeActiveGetLists";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeActiveGetLists";
            }
        }
    }

    public static string SERVER_WEEKRANK_REPORT_END_URL
    {
        get
        {
            //锦标赛上报活动结束
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeActiveSetEnd";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeActiveSetEnd";
            }
        }
    }

    public static string SERVER_WEEKRANK_REPORT_CLAIM_URL
    {
        get
        {
            //锦标赛上报领取奖励
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeActiveSetAward";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeActiveSetAward";
            }
        }
    }

    public static string SERVER_PROFILE_URL
    {
        get
        {
            //获取其他玩家统计数据
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeGetProfile";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeGetProfile";
            }
        }
    }
	public static string SERVER_CHESTS_URL {
		get {
			if (GameSetting.IsDebugMode) {
				return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/rewardSystem";
			} else {
				return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/rewardSystem";
			}
		}
	}
    
    public static string SERVER_AC_RANK
    {
        get
        {
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/crazeCollectUpdate";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeCollectUpdate";
            }
        }
    }
    
    public static string SERVER_EVENT_LIST
    {
        get
        {
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/activityMainInit";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/crazeActivityMainInit";
            }
        }
    }

    public static string SERVER_CARDBAG_GIFT
    {
        get
        {
            //5选1卡包奖品请求
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/cardPackage";
            }
            else
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/cardPackage";
            }
        }
    }
    public static string SERVER_OnLine_Item
    {
        get
        {
            //玩家在线数据
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/backPackSys";
            }
            else
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/backPackSys";
            }
        }
    }

    public static string SERVER_ACHIEVEMENT
    {
        get
        {
            //成就请求
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/achievementSys";
            }
            else
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/achievementSys";
            }
        }
    }
    
    public static string SERVER_PVE_DAN
    {
        get
        {
            //PVE所有段位
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/acLimitTimeDan";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/acLimitTimeDan";
            }
        }
    }

    public static string SERVER_PVE_ENTER
    {
        get
        {
            //参加PVE子活动并获取对手信息
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/acLimitTimeVs";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/acLimitTimeVs";
            }
        }
    }

    public static string SERVER_PVE_RANK
    {
        get
        {
            //获取PVE子活动排行榜
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/acLimitTimeGet";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/acLimitTimeGet";
            }
        }
    }

    public static string SERVER_PVE_UPLOAD
    {
        get
        {
            //上传PVE子活动分数
            if (GameSetting.IsDebugMode)
            {
                return "https://us-central1-wordswitch-cd2b3.cloudfunctions.net/acLimitTimeUp";
            }
            else
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/acLimitTimeUp";
            }
        }
    }
}