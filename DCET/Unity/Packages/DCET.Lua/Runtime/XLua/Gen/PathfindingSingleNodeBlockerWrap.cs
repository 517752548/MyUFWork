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
    public class PathfindingSingleNodeBlockerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.SingleNodeBlocker);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 2, 1);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BlockAtCurrentPosition", _m_BlockAtCurrentPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BlockAt", _m_BlockAt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Block", _m_Block);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Unblock", _m_Unblock);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlastBlocked", _g_get_lastBlocked);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmanager", _g_get_manager);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmanager", _s_set_manager);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "lastBlocked", _g_get_lastBlocked);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "manager", _g_get_manager);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "manager", _s_set_manager);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.SingleNodeBlocker gen_ret = new Pathfinding.SingleNodeBlocker();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.SingleNodeBlocker constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BlockAtCurrentPosition(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SingleNodeBlocker gen_to_be_invoked = (Pathfinding.SingleNodeBlocker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.BlockAtCurrentPosition(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BlockAt(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SingleNodeBlocker gen_to_be_invoked = (Pathfinding.SingleNodeBlocker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    
                    gen_to_be_invoked.BlockAt( 
                        _position );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Block(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SingleNodeBlocker gen_to_be_invoked = (Pathfinding.SingleNodeBlocker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.Block( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unblock(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SingleNodeBlocker gen_to_be_invoked = (Pathfinding.SingleNodeBlocker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Unblock(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lastBlocked(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SingleNodeBlocker gen_to_be_invoked = (Pathfinding.SingleNodeBlocker)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.lastBlocked);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_manager(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SingleNodeBlocker gen_to_be_invoked = (Pathfinding.SingleNodeBlocker)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.manager);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_manager(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SingleNodeBlocker gen_to_be_invoked = (Pathfinding.SingleNodeBlocker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.manager = (Pathfinding.BlockManager)translator.GetObject(L, 2, typeof(Pathfinding.BlockManager));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
