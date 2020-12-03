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
    public class PFEndingConditionProximityWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.EndingConditionProximity);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 1, 1);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TargetFound", _m_TargetFound);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxDistance", _g_get_maxDistance);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxDistance", _s_set_maxDistance);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxDistance", _g_get_maxDistance);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxDistance", _s_set_maxDistance);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<PF.ABPath>(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					PF.ABPath _p = (PF.ABPath)translator.GetObject(L, 2, typeof(PF.ABPath));
					float _maxDistance = (float)LuaAPI.lua_tonumber(L, 3);
					
					PF.EndingConditionProximity gen_ret = new PF.EndingConditionProximity(_p, _maxDistance);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.EndingConditionProximity constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TargetFound(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.EndingConditionProximity gen_to_be_invoked = (PF.EndingConditionProximity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.PathNode _node = (PF.PathNode)translator.GetObject(L, 2, typeof(PF.PathNode));
                    
                        bool gen_ret = gen_to_be_invoked.TargetFound( 
                        _node );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EndingConditionProximity gen_to_be_invoked = (PF.EndingConditionProximity)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EndingConditionProximity gen_to_be_invoked = (PF.EndingConditionProximity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
