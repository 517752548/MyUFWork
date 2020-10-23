package com.imop.lj.gameserver.guide;

import com.imop.lj.gameserver.guide.pusher.ArenaGuidePusher;
import com.imop.lj.gameserver.guide.pusher.CraftGuidePusher;
import com.imop.lj.gameserver.guide.pusher.DailySignGuidePusher;
import com.imop.lj.gameserver.guide.pusher.ExamGuidePusher;
import com.imop.lj.gameserver.guide.pusher.FirstBattleGuidePusher;
import com.imop.lj.gameserver.guide.pusher.ForageGuidePusher;
import com.imop.lj.gameserver.guide.pusher.HangGuidePusher;
import com.imop.lj.gameserver.guide.pusher.LevelRewardGuidePusher;
import com.imop.lj.gameserver.guide.pusher.PetFightGuidePusher;
import com.imop.lj.gameserver.guide.pusher.PetTalentGuidePusher;
import com.imop.lj.gameserver.guide.pusher.PubGuidePusher;
import com.imop.lj.gameserver.guide.pusher.TheSweeneyGuidePusher;
import com.imop.lj.gameserver.guide.pusher.TreasureMapGuidePusher;
import com.imop.lj.gameserver.guide.pusher.UpstarGuidePusher;
import com.imop.lj.gameserver.guide.pusher.UseEquipGuidePusher;
import com.imop.lj.gameserver.guide.pusher.WelcomeGuidePusher;
import com.imop.lj.gameserver.guide.pusher.WizardRaidGuidePusher;

public class GuidePusherFactory {

	public static IGuidePusherFactory WelcomeGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new WelcomeGuidePusher();
		}
	};
	
	public static IGuidePusherFactory UseEquipGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new UseEquipGuidePusher();
		}
	};
	
	public static IGuidePusherFactory PetFightGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new PetFightGuidePusher();
		}
	};
	
	public static IGuidePusherFactory FirstBattleGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new FirstBattleGuidePusher();
		}
	};
	
	
	public static IGuidePusherFactory DailySignGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new DailySignGuidePusher();
		}
	};
	
	public static IGuidePusherFactory ExamGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new ExamGuidePusher();
		}
	};
	
	
	public static IGuidePusherFactory ArenaGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new ArenaGuidePusher();
		}
	};
	
	public static IGuidePusherFactory WizardRaidGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new WizardRaidGuidePusher();
		}
	};
	
	public static IGuidePusherFactory UpstarGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new UpstarGuidePusher();
		}
	};
		
	public static IGuidePusherFactory LevelRewardGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new LevelRewardGuidePusher();
		}
	};
		
	public static IGuidePusherFactory PubGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new PubGuidePusher();
		}
	};
	
	public static IGuidePusherFactory HangGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new HangGuidePusher();
		}
	};
	
	public static IGuidePusherFactory TreasureMapGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new TreasureMapGuidePusher();
		}
	};
	
	public static IGuidePusherFactory ForageGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new ForageGuidePusher();
		}
	};
	
	public static IGuidePusherFactory TheSweeneyGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new TheSweeneyGuidePusher();
		}
	};
	
	public static IGuidePusherFactory CraftGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new CraftGuidePusher();
		}
	};
	
	public static IGuidePusherFactory PetTalentGuidePusherFactory = new IGuidePusherFactory() {
		
		@Override
		public AbstractGuidePusher createGuidePusher() {
			return new PetTalentGuidePusher();
		}
	};
	
	
}
