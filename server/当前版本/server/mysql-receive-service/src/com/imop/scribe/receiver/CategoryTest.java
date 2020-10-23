package com.imop.scribe.receiver;

import com.imop.scribe.receiver.category.Perf;
import com.imop.scribe.receiver.category.User;

public class CategoryTest {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		Perf perf = new Perf();

		System.out
			.println(perf
				.messageToInsertSQL(
					"probe.perf",
					"logversion=1,gameid=l,svrid=s37.l.mop.com,svcid=1,svc_type=game,hostid=TJHY164-101.opi.com,ts_begin=2011-01-05 02:19:09,ts_end=2011-01-05 02:24:09,cpu_avg=0.0,cpu_max=0.06,mem_total=1519,mem_usage=226,thr_cur=32,ygc_time=708,ygc_count=13,fgc_time=0,fgc_count=0,bytes_in=6718,bytes_out=795,req_reach=126,req_ok=126,req_flop=0,msg_profile=1,msg_0=126,msg_1=0,msg_2=0,msg_3=0,msg_4=0,msg_5=0,msg_6=0,msg_7=0,msg_flop=0,msg_avg=0,msg_max=0,db_profile=1,db_0=0,db_1=0,db_2=0,db_3=0,db_4=0,db_5=0,db_6=0,db_7=0,db_flop=0,db_avg=0,db_max=0,rpc_profile=1,rpc_0=0,rpc_1=0,rpc_2=0,rpc_3=0,rpc_4=0,rpc_5=0,rpc_6=0,rpc_7=0,rpc_flop=0,rpc_avg=0,rpc_max=0,users=0"));

		User user = new User();
		System.out
			.println(user
				.messageToInsertSQL(
					"probe.user",
					"{\"logversion\":1,\"gameid\":\"d\",\"svrid\":\"s99.d.renren.com\",\"svcid\":\"1\",\"svc_type\":\"game\",\"hostid\":\"TJHY256-14.opi.com\",\"ts_begin\":\"2011-01-05 02:19:24\",\"ts_end\":\"2011-01-05 02:24:24\",\"cpu_avg\":0.02,\"mem_usage\":613,\"users\":0,\"login_users\":0,\"logout_users\":0,\"fmt\":\"j\",\"detail_blob\":{\"scene_num\":\"3\",\"scene_human\":\"n40001=0,n20101=0,n10101=0\",\"sceneMonster\":\"n40001=0,n20101=210,n10101=0\"}}"));

		// Perf2 perf2 = new Perf2();
	}

}
