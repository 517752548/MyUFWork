using System.Collections.Generic;
using app.config;
using app.zone;
using app.avatar;
using app.human;
using app.net;
using app.battle;

namespace app.system
{
    public class SystemSettings
    {
        private bool mIsHideOthers = false;
        private bool mIsShowPaticleEffects = false;
        private bool mIsPlayBackgroundSound = false;
        private bool mIsPlayEffectSound = false;
        private bool misAutoPlayShijieYuyin = false;
        private bool misAutoPlayDangqianYuyin = false;
        private bool misAutoPlayBangpaiYuyin = false;
        private bool misAutoPlayDuiwuYuyin = false;
        private static SystemSettings mIns = null;

        public static SystemSettings ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new SystemSettings();
                }
                return mIns;
            }
        }
        public SystemSettings()
        {
            PlayerData playerData = PlayerDataManager.Ins.GetPlayerData(PlayerDataKeyDef.CUSTOM_DATA);
            string isHideOthersStr = playerData.getData(PlayerDataKeyDef.CUSTOM_DATA_IS_HIDE_OTHERS);
            string isPlayBackgroundSoundStr = playerData.getData(PlayerDataKeyDef.CUSTOM_DATA_IS_PLAY_BG_SOUND);
            string isPlayEffectSoundStr = playerData.getData(PlayerDataKeyDef.CUSTOM_DATA_IS_PLAY_EFFECT_SOUND);
            string isShowParticleEffectsStr = playerData.getData(PlayerDataKeyDef.CUSTOM_DATA_IS_SHOW_PARTICLE_EFFECTS);
            string isAutoPlayShijieYuyinStr = playerData.getData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_SHIJIE_YUYIN);
            string isAutoPlayDangqianYuyinStr = playerData.getData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_DANGQIAN_YUYIN);
            string isAutoPlayBangpaiYuyinStr = playerData.getData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_BANGPAI_YUYIN);
            string isAutoPlayDuiwuYuyinStr = playerData.getData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_DUIWU_YUYIN);

            if (!string.IsNullOrEmpty(isHideOthersStr))
            {
                bool.TryParse(isHideOthersStr, out mIsHideOthers);
            }
            
            if (!string.IsNullOrEmpty(isPlayBackgroundSoundStr))
            {
                bool.TryParse(isPlayBackgroundSoundStr, out mIsPlayBackgroundSound);
            }
            else
            {
                mIsPlayBackgroundSound = true;
                playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_PLAY_BG_SOUND, mIsPlayBackgroundSound.ToString());
            }
            
            if (!string.IsNullOrEmpty(isPlayEffectSoundStr))
            {
                bool.TryParse(isPlayEffectSoundStr, out mIsPlayEffectSound);
            }
            else
            {
                mIsPlayEffectSound = true;
                playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_PLAY_EFFECT_SOUND, mIsPlayEffectSound.ToString());
            }

            if (!string.IsNullOrEmpty(isShowParticleEffectsStr))
            {
                bool.TryParse(isShowParticleEffectsStr, out mIsShowPaticleEffects);
            }
            else
            {
                mIsShowPaticleEffects = true;
                playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_SHOW_PARTICLE_EFFECTS, mIsShowPaticleEffects.ToString());
            }

            if (!string.IsNullOrEmpty(isAutoPlayShijieYuyinStr))
            {
                bool.TryParse(isAutoPlayShijieYuyinStr, out misAutoPlayShijieYuyin);
            }
            else
            {
                misAutoPlayShijieYuyin = false;
                playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_SHIJIE_YUYIN, misAutoPlayShijieYuyin.ToString());
            }

            if (!string.IsNullOrEmpty(isAutoPlayDangqianYuyinStr))
            {
                bool.TryParse(isAutoPlayDangqianYuyinStr, out misAutoPlayDangqianYuyin);
            }
            else
            {
                misAutoPlayDangqianYuyin = false;
                playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_DANGQIAN_YUYIN, misAutoPlayDangqianYuyin.ToString());
            }

            if (!string.IsNullOrEmpty(isAutoPlayBangpaiYuyinStr))
            {
                bool.TryParse(isAutoPlayBangpaiYuyinStr, out misAutoPlayBangpaiYuyin);
            }
            else
            {
                misAutoPlayBangpaiYuyin = false;
                playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_BANGPAI_YUYIN, misAutoPlayBangpaiYuyin.ToString());
            }

            if (!string.IsNullOrEmpty(isAutoPlayDuiwuYuyinStr))
            {
                bool.TryParse(isAutoPlayDuiwuYuyinStr, out misAutoPlayDuiwuYuyin);
            }
            else
            {
                misAutoPlayDuiwuYuyin = false;
                playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_DUIWU_YUYIN, misAutoPlayDuiwuYuyin.ToString());
            }

            PlayerDataManager.Ins.SaveData(PlayerDataKeyDef.CUSTOM_DATA, playerData);
        }

        public void UpdateSetting(
            int displayQuality, 
            bool isHideOthers, 
            bool isShowParticleEffects, 
            bool playBackgroundSound, 
            bool playEffectSound,
            bool isAutoPlayShijieYuyin,
            bool isAutoPlayDangqianYuyin,
            bool isAutoPlayBangpaiYuyin,
            bool isAutoPlayDuiwuYuyin,
            bool isBattleSpeedUp)
        {
            DisplayQualitySettings.ins.UpdateCurDisplayQuality(displayQuality);

            PlayerData playerData = PlayerDataManager.Ins.GetPlayerData(PlayerDataKeyDef.CUSTOM_DATA);
            playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_HIDE_OTHERS, isHideOthers.ToString());
            playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_PLAY_BG_SOUND, playBackgroundSound.ToString());
            playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_PLAY_EFFECT_SOUND, playEffectSound.ToString());
            playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_SHOW_PARTICLE_EFFECTS, isShowParticleEffects.ToString());
            playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_SHIJIE_YUYIN, isAutoPlayShijieYuyin.ToString());
            playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_DANGQIAN_YUYIN, isAutoPlayDangqianYuyin.ToString());
            playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_BANGPAI_YUYIN, isAutoPlayBangpaiYuyin.ToString());
            playerData.addData(PlayerDataKeyDef.CUSTOM_DATA_IS_AUTO_PLAY_DUIWU_YUYIN, isAutoPlayDuiwuYuyin.ToString());
            PlayerDataManager.Ins.SaveData(PlayerDataKeyDef.CUSTOM_DATA, playerData);

            if (mIsHideOthers != isHideOthers)
            {
                mIsHideOthers = isHideOthers;
                if (isHideOthers)
                {
                    ZoneCharacterManager.ins.RemoveOthers();
                }
                else
                {
                    ZoneCharacterManager.ins.AddOthers();
                }
            }
            
            if (mIsShowPaticleEffects != isShowParticleEffects)
            {
                mIsShowPaticleEffects = isShowParticleEffects;
                
                List<MemCachePool> cachePools = MemCache.GetPoolsByCacheType(MemCacheType.AVATAR);
                int len = cachePools.Count;
                for (int i = 0; i < len; i++)
                {
                    List<ICacheable> caches = cachePools[i].caches;
                    int cachesLen = caches.Count;
                    for (int j = 0; j < cachesLen; j++)
                    {
                        AvatarDisplayCache cache = caches[j] as AvatarDisplayCache;
                        if (cache != null)
                        {
                            cache.SetParticleEffectsActive(isShowParticleEffects);
                        }
                    }
                }
            }
            
            if (mIsPlayBackgroundSound != playBackgroundSound)
            {
                mIsPlayBackgroundSound = playBackgroundSound;
                AudioManager.Ins.SetYinYueMute(!playBackgroundSound);
            }
            
            if (mIsPlayEffectSound != playEffectSound)
            {
                mIsPlayEffectSound = playEffectSound;
                AudioManager.Ins.SetYinXiaoMute(!playEffectSound);
            }

            misAutoPlayShijieYuyin = isAutoPlayShijieYuyin;
            misAutoPlayDangqianYuyin = isAutoPlayDangqianYuyin;
            misAutoPlayBangpaiYuyin = isAutoPlayBangpaiYuyin;
            misAutoPlayDuiwuYuyin = isAutoPlayDuiwuYuyin;

            if (Human.Instance.PlayerModel.canBattlePlayFastForward == 1)
            {
                BattleCGHandler.sendCGBattleSpeedup(isBattleSpeedUp ? BattleModel.ins.battleSpeedFast : BattleDef.PLAY_REPORT_NOR_SPEED);
            }
        }

        public bool isHideOthers
        {
            get
            {
                return mIsHideOthers;
            }
        }
        
        public bool isPlayBackgroundSound
        {
            get
            {
                return mIsPlayBackgroundSound;
            }
        }
        
        public bool isPlayEffectSound
        {
            get
            {
                return mIsPlayEffectSound;
            }
        }
        
        public bool isShowParticleEffects
        {
            get
            {
                return mIsShowPaticleEffects;
            }
        }

        public bool isAutoPlayShijieYuyin
        {
            get
            {
                return misAutoPlayShijieYuyin;
            }
        }

        public bool isAutoPlayDangqianYuyin
        {
            get
            {
                return misAutoPlayDangqianYuyin;
            }
        }

        public bool isAutoPlayBangpaiYuyin
        {
            get
            {
                return misAutoPlayBangpaiYuyin;
            }
        }

        public bool isAutoPlayDuiwuYuyin
        {
            get
            {
                return misAutoPlayDuiwuYuyin;
            }
        }
    }

    public class SystemSettingView : BaseWnd
    {
        //[Inject(ui = "SystemSettingUI")]
        //public GameObject ui;

        public SystemSettingUI UI;
        
        public SystemSettingView()
        {
            uiName = "SystemSettingUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<SystemSettingUI>();
            UI.Init();
            UI.okBtn.SetClickCallBack(OnOkBtnClicked);
            UI.cancelBtn.SetClickCallBack(OnCancelBtnClicked);
            UI.banbenhao.text = "版本号: "+ ClientVersionConfig.Ins.GetAppVersion();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.displayQualityTG.SetIndexWithCallBack(DisplayQualitySettings.ins.currentDisplayQuality);
            UI.infoTips.SetActive(DisplayQualitySettings.ins.isCurDisplayQualityTooHigh);
            UI.hideOthers.isOn = SystemSettings.ins.isHideOthers;
            UI.openEffects.isOn = SystemSettings.ins.isShowParticleEffects;
            UI.playBackgroundSound.isOn = SystemSettings.ins.isPlayBackgroundSound;
            UI.playEffectSound.isOn = SystemSettings.ins.isPlayEffectSound;
            UI.shijieyuyin.isOn = SystemSettings.ins.isAutoPlayShijieYuyin;
            UI.dangqianyuyin.isOn = SystemSettings.ins.isAutoPlayDangqianYuyin;
            UI.bangpaiyuyin.isOn = SystemSettings.ins.isAutoPlayBangpaiYuyin;
            UI.duiwuyuyin.isOn = SystemSettings.ins.isAutoPlayDuiwuYuyin;
            UI.battleFastForward.gameObject.SetActive(Human.Instance.PlayerModel.canBattlePlayFastForward == 1);
            UI.battleFastForward.isOn = (Human.Instance.PlayerModel.battlePlaySpeed != BattleDef.PLAY_REPORT_NOR_SPEED);
        }

        private void OnOkBtnClicked()
        {
            SystemSettings.ins.UpdateSetting(
                UI.displayQualityTG.index, 
                UI.hideOthers.isOn, 
                UI.openEffects.isOn, 
                UI.playBackgroundSound.isOn, 
                UI.playEffectSound.isOn, 
                UI.shijieyuyin.isOn, 
                UI.dangqianyuyin.isOn, 
                UI.bangpaiyuyin.isOn, 
                UI.duiwuyuyin.isOn,
                UI.battleFastForward.isOn
            );
            hide();
        }

        private void OnCancelBtnClicked()
        {
            hide();
        }
    }
}