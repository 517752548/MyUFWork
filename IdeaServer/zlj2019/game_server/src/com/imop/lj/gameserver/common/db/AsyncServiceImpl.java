package com.imop.lj.gameserver.common.db;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.core.async.AsyncOperation;
import com.imop.lj.core.async.AsyncService;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.async.SyncOperation;
import com.imop.lj.core.server.IMessageProcessor;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.ExecutorUtil;
import com.imop.lj.gameserver.common.db.operation.BattleBindUUIDIoOperation;
import com.imop.lj.gameserver.common.db.operation.BattleIIoOperation;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.common.db.operation.ChatIIoOperation;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.common.db.operation.LocalIoOperation;
import com.imop.lj.gameserver.startup.GameServerRuntime;

/**
 * 异步操作管理器
 *
 */
public class AsyncServiceImpl implements AsyncService {
	private static final Logger logger = LoggerFactory.getLogger("async");

	/** 位于主线程的消息处理器,用于当异步操作完成后,在主线程中执行收尾操作 */
	private final IMessageProcessor messageProcessor;
	/** 与玩家角色绑定的线程池,即根据玩家角色的id号{@link PlayerCharacter#getTemplateId()},固定的操作总在同一个线程池中运行 */
	private final ExecutorService[] charBindExecutors;
	/** 不与玩家角色绑定的线程池 */
	private final ExecutorService charUnBindExecutor;

	/** 用于local的与玩家角色绑定的线程池*/
	private final ExecutorService[] localCharBindExecutors;
	/** 用于local的独立线程*/
	private final ExecutorService localCharUnBindExecutor;
	
	/** 战斗专用，与玩家角色绑定的线程池 */
	private final ExecutorService[] battleCharBindExecutors;
	/** 战斗专用，不与玩家角色绑定的线程池 */
	private final ExecutorService battleCharUnBindExecutor;
	
	/** 聊天专用，用于广播 */
	private final ExecutorService chatExecutor;

	/**
	 * 异步操作服务器类，用于异步操作
	 * @param charBindExecutorSize 与玩家角色绑定的线程池大小
	 * @param charUnBindExecutorSize 不与玩家角色绑定的线程池大小
	 * @param localCharUnBindExecutorSize 用于local使用的独立线程池大小
	 * @param messageProcessor
	 */
	public AsyncServiceImpl(final int charBindExecutorSize, final int charUnBindExecutorSize, 
			final int localCharBindExecutorSize, final int localCharUnBindExecutorSize,
			final int battleCharBindExecutorSize, final int battleCharUnBindExecutorSize, 
			IMessageProcessor messageProcessor) {
		this.messageProcessor = messageProcessor;
		charBindExecutors = new ExecutorService[charBindExecutorSize];
		for (int i = 0; i < charBindExecutorSize; i++) {
			charBindExecutors[i] = Executors.newSingleThreadExecutor();
		}
		this.charUnBindExecutor = Executors.newFixedThreadPool(charUnBindExecutorSize);

		localCharBindExecutors = new ExecutorService[localCharBindExecutorSize];
		for (int i = 0; i < localCharBindExecutorSize; i++) {
			localCharBindExecutors[i] = Executors.newSingleThreadExecutor();
		}
		this.localCharUnBindExecutor = Executors.newFixedThreadPool(localCharUnBindExecutorSize);
		
		battleCharBindExecutors = new ExecutorService[battleCharBindExecutorSize];
		for (int i = 0; i < battleCharBindExecutorSize; i++) {
			battleCharBindExecutors[i] = Executors.newSingleThreadExecutor();
		}
		this.battleCharUnBindExecutor = Executors.newFixedThreadPool(battleCharUnBindExecutorSize);

		this.chatExecutor = Executors.newSingleThreadExecutor();
	}

	@Override
	public void stop() {
		try {
			for (ExecutorService _executor : this.charBindExecutors) {
				ExecutorUtil.shutdownAndAwaitTermination(_executor);
			}
			ExecutorUtil.shutdownAndAwaitTermination(this.charUnBindExecutor);
			
			for (ExecutorService _localExecutor : this.localCharBindExecutors) {
				ExecutorUtil.shutdownAndAwaitTermination(_localExecutor);
			}
			ExecutorUtil.shutdownAndAwaitTermination(this.localCharUnBindExecutor);
			
			for (ExecutorService _executor : this.battleCharBindExecutors) {
				ExecutorUtil.shutdownAndAwaitTermination(_executor);
			}
			ExecutorUtil.shutdownAndAwaitTermination(this.battleCharUnBindExecutor);
			ExecutorUtil.shutdownAndAwaitTermination(this.chatExecutor);
			
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(CommonErrorLogInfo.DB_OPERATE_FAIL, "#GS.AsyncManagerImpl.stop", null), e);
			}
		}
	}


	@Override
	public SyncOperation createSyncOperationAndExecuteAtOnce(IIoOperation operation) {
		SyncOperation _operation = new SyncOperation(operation);
		_operation.execute();
		return _operation;
	}

	@Override
	public AsyncOperation createOperationAndExecuteAtOnce(IIoOperation operation) {
		if (GameServerRuntime.isShutdowning()) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(CommonErrorLogInfo.INVALID_STATE,
						"#GS.AsyncManagerImpl.createOperationAndExecuteAtOnce", "Shutdowning the server"),
						new Exception());
			}
		}
		AsyncOperation _operation = null;
		//local专门的operation
		if (operation instanceof LocalIoOperation || operation instanceof LocalBindUUIDIoOperation) {
			_operation = this.createLocalOperation(operation);
		} else if (operation instanceof BattleIIoOperation || operation instanceof BattleBindUUIDIoOperation) {
			// 战斗专用
			_operation = this.createBattleOperation(operation);
		}  else if (operation instanceof ChatIIoOperation) {
			//聊天
			_operation = this.createChatOperation(operation);
		} else {// 游戏内
			_operation = this.createOperation(operation);
		}
		_operation.execute();
		return _operation;
	}

	@Override
	public AsyncOperation createOperationAndExecuteAtOnce(IIoOperation operation, long uuid) {
		if (GameServerRuntime.isShutdowning()) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(CommonErrorLogInfo.INVALID_STATE,
						"#GS.AsyncManagerImpl.createOperationAndExecuteAtOnce",
						"Shutdowning the server"), new Exception());
			}
		}
		AsyncOperation _operation = null;
		//local专门的operation
		if (operation instanceof LocalIoOperation || operation instanceof LocalBindUUIDIoOperation) {
			_operation = this.createLocalOperation(operation, uuid);
		} else if (operation instanceof BattleIIoOperation || operation instanceof BattleBindUUIDIoOperation) {
			// 战斗专用
			_operation = this.createBattleOperation(operation, uuid);
		} else if (operation instanceof ChatIIoOperation) {
			//聊天
			_operation = this.createChatOperation(operation);
		} else {//非local
			_operation = this.createOperation(operation, uuid);
		}
		_operation.execute();
		return _operation;
	}

	private AsyncOperation createOperation(IIoOperation operation) {
		if (operation instanceof BindUUIDIoOperation) {
			long _charId = ((BindUUIDIoOperation) operation).getBindUUID();
			int _executorIndex = (int) (_charId % this.charBindExecutors.length);
			_executorIndex = _executorIndex < 0 ? 0 : _executorIndex;
			ExecutorService _asyncExecutor = this.charBindExecutors[_executorIndex];
			if (logger.isDebugEnabled()) {
				logger.debug("[#GS.AsyncManagerImpl.createOperation] [char:" + _charId + " bind to executor :"
						+ _executorIndex + "]");
			}
			return new AsyncOperation(operation, _asyncExecutor, messageProcessor);
		} else {
			return new AsyncOperation(operation, charUnBindExecutor, messageProcessor);
		}
	}
	
	private AsyncOperation createOperation(IIoOperation operation, long uuid) {
		if (operation instanceof BindUUIDIoOperation) {
			long _charId = ((BindUUIDIoOperation) operation).getBindUUID();
			int _executorIndex = (int) (_charId % this.charBindExecutors.length);
			_executorIndex = _executorIndex < 0 ? 0 : _executorIndex;
			ExecutorService _asyncExecutor = this.charBindExecutors[_executorIndex];
			if (logger.isDebugEnabled()) {
				logger.debug("[#GS.AsyncManagerImpl.createOperation] [char:" + _charId + " bind to executor :"
						+ _executorIndex + "]");
			}
			return new AsyncOperation(operation, _asyncExecutor, messageProcessor,uuid);
		} else {
			return new AsyncOperation(operation, charUnBindExecutor, messageProcessor,uuid);
		}
	}
	
	private AsyncOperation createBattleOperation(IIoOperation operation) {
		if (operation instanceof BattleBindUUIDIoOperation) {
			long _charId = ((BattleBindUUIDIoOperation) operation).getBindUUID();
			int _executorIndex = (int) (_charId % this.battleCharBindExecutors.length);
			_executorIndex = _executorIndex < 0 ? 0 : _executorIndex;
			ExecutorService _asyncExecutor = this.battleCharBindExecutors[_executorIndex];
			if (logger.isDebugEnabled()) {
				logger.debug("[#GS.AsyncManagerImpl.createBattleOperation] [char:" + _charId + " bind to executor :"
						+ _executorIndex + "]");
			}
			return new AsyncOperation(operation, _asyncExecutor, messageProcessor);
		} else {
			return new AsyncOperation(operation, battleCharUnBindExecutor, messageProcessor);
		}
	}
	
	private AsyncOperation createBattleOperation(IIoOperation operation, long uuid) {
		if (operation instanceof BattleBindUUIDIoOperation) {
			long _charId = ((BattleBindUUIDIoOperation) operation).getBindUUID();
			int _executorIndex = (int) (_charId % this.battleCharBindExecutors.length);
			_executorIndex = _executorIndex < 0 ? 0 : _executorIndex;
			ExecutorService _asyncExecutor = this.battleCharBindExecutors[_executorIndex];
			if (logger.isDebugEnabled()) {
				logger.debug("[#GS.AsyncManagerImpl.createBattleOperation] [char:" + _charId + " bind to executor :"
						+ _executorIndex + "]");
			}
			return new AsyncOperation(operation, _asyncExecutor, messageProcessor,uuid);
		} else {
			return new AsyncOperation(operation, battleCharUnBindExecutor, messageProcessor,uuid);
		}
	}
	
	private AsyncOperation createChatOperation(IIoOperation operation) {
		return new AsyncOperation(operation, chatExecutor, messageProcessor);
	}

	/**
	 * 创建local的异步operation
	 * @param operation
	 * @return
	 */
	private AsyncOperation createLocalOperation(IIoOperation operation) {
		if (operation instanceof LocalBindUUIDIoOperation) {
			long _charId = ((LocalBindUUIDIoOperation) operation).getBindUUID();
			int _executorIndex = (int) (_charId % this.localCharBindExecutors.length);
			_executorIndex = _executorIndex < 0 ? 0 : _executorIndex;
			ExecutorService _asyncExecutor = this.localCharBindExecutors[_executorIndex];
			if (logger.isDebugEnabled()) {
				logger.debug("[#GS.AsyncManagerImpl.createOperation] [char:" + _charId + " bind to executor :"
						+ _executorIndex + "]");
			}
			return new AsyncOperation(operation, _asyncExecutor, messageProcessor);
		} else {
			return new AsyncOperation(operation, localCharUnBindExecutor, messageProcessor);
		}
	}

	/**
	 * 创建local的异步operation
	 * @param operation
	 * @param uuid
	 * @return
	 */
	private AsyncOperation createLocalOperation(IIoOperation operation, long uuid) {
		if (operation instanceof LocalBindUUIDIoOperation) {
			long _charId = ((LocalBindUUIDIoOperation) operation).getBindUUID();
			int _executorIndex = (int) (_charId % this.localCharBindExecutors.length);
			_executorIndex = _executorIndex < 0 ? 0 : _executorIndex;
			ExecutorService _asyncExecutor = this.localCharBindExecutors[_executorIndex];
			if (logger.isDebugEnabled()) {
				logger.debug("[#GS.AsyncManagerImpl.createOperation] [char:" + _charId + " bind to executor :"
						+ _executorIndex + "]");
			}
			return new AsyncOperation(operation, _asyncExecutor, messageProcessor,uuid);
		} else {
			return new AsyncOperation(operation, localCharUnBindExecutor, messageProcessor,uuid);
		}
	}

}
