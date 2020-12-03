#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PathfindingUtilMovementUtilitiesWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Util.MovementUtilities);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ClampVelocity", _m_ClampVelocity_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CalculateAccelerationToReachPoint", _m_CalculateAccelerationToReachPoint_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.Util.MovementUtilities does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClampVelocity_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 _velocity;translator.Get(L, 1, out _velocity);
                    float _maxSpeed = (float)LuaAPI.lua_tonumber(L, 2);
                    float _slowdownFactor = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _slowWhenNotFacingTarget = LuaAPI.lua_toboolean(L, 4);
                    UnityEngine.Vector2 _forward;translator.Get(L, 5, out _forward);
                    
                        UnityEngine.Vector2 gen_ret = Pathfinding.Util.MovementUtilities.ClampVelocity( 
                        _velocity, 
                        _maxSpeed, 
                        _slowdownFactor, 
                        _slowWhenNotFacingTarget, 
                        _forward );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateAccelerationToReachPoint_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 _deltaPosition;translator.Get(L, 1, out _deltaPosition);
                    UnityEngine.Vector2 _targetVelocity;translator.Get(L, 2, out _targetVelocity);
                    UnityEngine.Vector2 _currentVelocity;translator.Get(L, 3, out _currentVelocity);
                    float _forwardsAcceleration = (float)LuaAPI.lua_tonumber(L, 4);
                    float _rotationSpeed = (float)LuaAPI.lua_tonumber(L, 5);
                    float _maxSpeed = (float)LuaAPI.lua_tonumber(L, 6);
                    UnityEngine.Vector2 _forwardsVector;translator.Get(L, 7, out _forwardsVector);
                    
                        UnityEngine.Vector2 gen_ret = Pathfinding.Util.MovementUtilities.CalculateAccelerationToReachPoint( 
                        _deltaPosition, 
                        _targetVelocity, 
                        _currentVelocity, 
                        _forwardsAcceleration, 
                        _rotationSpeed, 
                        _maxSpeed, 
                        _forwardsVector );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
