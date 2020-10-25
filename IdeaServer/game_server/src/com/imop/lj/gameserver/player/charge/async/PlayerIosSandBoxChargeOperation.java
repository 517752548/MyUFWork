package com.imop.lj.gameserver.player.charge.async;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

import net.sf.json.JSONObject;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

/**
 * ipad充值校验
 *
 *
 * 注:对于AppStore验证成功但是TranscationEntity已经记录过此订单的情况,pass标记位仍然为true,
 */
public class PlayerIosSandBoxChargeOperation implements LocalBindUUIDIoOperation {

	private IChargeCallBack callback;

	private long roleUUID;

	private String chargeData = null;

//	private boolean pass = false;
//
//	private boolean repeat = false;

//	private String productid = null;

//	private String transcationid = null;

	private boolean isSuccess = false;

//	private int mmCost = 0;

	private ChargeOrderInfo orderInfo;


	public PlayerIosSandBoxChargeOperation(long roleUUID,String chargeData,IChargeCallBack callBack) {
		this.roleUUID = roleUUID;
		this.chargeData = chargeData;
		this.callback = callBack;
		this.orderInfo = new ChargeOrderInfo();
	}

	@Override
	public int doIo() {
		do {
			try{
				Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
				if (player == null) {
					// 直接结束
					return STAGE_STOP_DONE;
				}
				Human _human = player.getHuman();
				if (_human == null) {
					// 直接结束
					return STAGE_STOP_DONE;
				}

				String response = null;
				JSONObject json = new JSONObject();
				json.accumulate("receipt-data", chargeData);
//				response = "{\"receipt\":{\"item_id\":\"457804408\", \"original_transaction_id\":\"1000000007213442\", \"bvrs\":\"1.0.1\", \"product_id\":\"iron.one\", \"purchase_date\":\"2011-09-07 14:59:23 Etc/GMT\", \"quantity\":\"1\", \"bid\":\"com.renren.gamecenter\", \"original_purchase_date\":\"2011-09-07 14:59:23 Etc/GMT\", \"transaction_id\":\"1000000007213442\"}, \"status\":0}";
				response = checkAppleBusinessReq(json.toString());

				if(response == null
						|| "".equals(response)){
					return STAGE_IO_DONE;
				}

				JSONObject jsonobj = JSONObject.fromObject(response);
				Loggers.playerLogger.warn("transaction " + response);
				if ("0".equals(String.valueOf(jsonobj.get("status")))) {
					JSONObject receipt = JSONObject.fromObject(jsonobj.get("receipt"));

					String productid = String.valueOf(receipt.get("product_id"));
					String transcationid = String.valueOf(receipt.get("transaction_id"));

//					List<TranscationEntity> transcations = Globals.getDaoService().getTranscationDao().QueryTranscationByTranscationId(transcationid);
//
//					if(transcations == null || transcations.size() == 0){
//						IpadChargeTemplate template = Globals.getIpadChargeService().getIpadChargeTemplate(player.getAppid(),productid);
//
//						if(template != null && template.getAreaId() == 99){
//
//							orderInfo.setUser_id(player.getId());
//							//91充值没有余额
//							orderInfo.setBalance(0);
//							orderInfo.setOrderId(transcationid);
//							orderInfo.setAmount(template.getAmount());
//							orderInfo.setCurrency("CNY");
//							orderInfo.setChargeType("iosexpand");
//							orderInfo.setPay_channel("apple");
//							orderInfo.setSub_channel("");
//							orderInfo.setGamepoint(template.getCoins());
//
//							TranscationEntity transcationEntity = new TranscationEntity();
//
//							transcationEntity.setRoleId(player.getHuman().getUUID());
//							transcationEntity.setProductid(productid);
//							transcationEntity.setTranscationid(transcationid);
//							transcationEntity.setParam(response);
//							transcationEntity.setRegionid(Globals.getServerConfig().getRegionId());
//							transcationEntity.setServerid(Globals.getServerConfig().getServerId());
//							transcationEntity.setRolename(player.getHuman().getName());
//							transcationEntity.setUserid(player.getPassportId());
//							transcationEntity.setUsername(player.getPassportName());
//							transcationEntity.setUpdatetime(new Timestamp(Globals.getTimeService().now()));
//
//							Globals.getDaoService().getTranscationDao().save(transcationEntity);
//							isSuccess = true;
//						}
//						else{
//							Loggers.playerLogger.error("no :" + productid);
//						}
//					}
//					else{
//						Loggers.playerLogger.error("transaction is exist id:" + transcationid);
//					}
				}
				else{
					Loggers.playerLogger.error("transaction error " + response);
				}
			}
			catch(Exception e){
				Loggers.playerLogger.error("ChargeSandBoxIpadCallback.doIo :" + e);
			}
		} while (false);
		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			return IIoOperation.STAGE_STOP_DONE;
		}
		Human human = player.getHuman();
		if (human == null) {
			return IIoOperation.STAGE_STOP_DONE;
		}
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		if(isSuccess){
			callback.afterCheckComplete(roleUUID,orderInfo,isSuccess);
		}
		return STAGE_STOP_DONE;
	}

	private String checkAppleBusinessReq(String data){
		StringBuffer result = new StringBuffer();

		HttpClient httpclient = new DefaultHttpClient();

		HttpPost httppost = new HttpPost("https://"
				+ Globals.getServerConfig().getAppleStoreType()
				+ ".itunes.apple.com/verifyReceipt");
//		System.out.println(Globals.getServerConfig().getAppleStoreType());
		HttpResponse response = null;
		try{
			httppost.setEntity(new StringEntity(data,"text/xml; charset=UTF-8", "UTF-8"));
			response = httpclient.execute(httppost);
		}
		catch(ClientProtocolException ex){
			Loggers.playerLogger.error("1.ChargeSandBoxIpadCallback.checkAppleBusinessReq :" + ex);
		}
		catch (IOException ex) {
			Loggers.playerLogger.error("2.ChargeSandBoxIpadCallback.checkAppleBusinessReq :" + ex);
		}

		HttpEntity entity = response==null?null:response.getEntity();

		if (entity != null) {
			 InputStream instream = null;
			 try {
				 instream = entity.getContent();
			     BufferedReader reader = new BufferedReader(
			             new InputStreamReader(instream));
			     String line = null;
			     while((line=reader.readLine()) != null){
			    	 result.append(line);
			     }
			 } catch (IOException ex) {
				 Loggers.playerLogger.error("3.ChargeSandBoxIpadCallback.checkAppleBusinessReq :" + ex);
			 } catch (RuntimeException ex) {
				 Loggers.playerLogger.error("4.ChargeSandBoxIpadCallback.checkAppleBusinessReq :" + ex);
			 } finally {
			     try {
					instream.close();
				} catch (IOException ex) {
					Loggers.playerLogger.error("5.ChargeSandBoxIpadCallback.checkAppleBusinessReq :" + ex);
				}
			 }
			 httpclient.getConnectionManager().shutdown();
		}

		return result.toString();
	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}
}
