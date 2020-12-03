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
    public class PathfindingExamplesTurnBasedAIWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Examples.TurnBasedAI);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 5, 5);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmovementPoints", _g_get_movementPoints);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getblockManager", _g_get_blockManager);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getblocker", _g_get_blocker);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettargetNode", _g_get_targetNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettraversalProvider", _g_get_traversalProvider);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmovementPoints", _s_set_movementPoints);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setblockManager", _s_set_blockManager);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setblocker", _s_set_blocker);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settargetNode", _s_set_targetNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settraversalProvider", _s_set_traversalProvider);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "movementPoints", _g_get_movementPoints);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "blockManager", _g_get_blockManager);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "blocker", _g_get_blocker);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "targetNode", _g_get_targetNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "traversalProvider", _g_get_traversalProvider);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "movementPoints", _s_set_movementPoints);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "blockManager", _s_set_blockManager);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "blocker", _s_set_blocker);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "targetNode", _s_set_targetNode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "traversalProvider", _s_set_traversalProvider);
            
			
			
			
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
					
					Pathfinding.Examples.TurnBasedAI gen_ret = new Pathfinding.Examples.TurnBasedAI();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Examples.TurnBasedAI constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_movementPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.movementPoints);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blockManager(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.blockManager);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blocker(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.blocker);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_targetNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.targetNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_traversalProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.traversalProvider);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_movementPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.movementPoints = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_blockManager(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.blockManager = (Pathfinding.BlockManager)translator.GetObject(L, 2, typeof(Pathfinding.BlockManager));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_blocker(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.blocker = (Pathfinding.SingleNodeBlocker)translator.GetObject(L, 2, typeof(Pathfinding.SingleNodeBlocker));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_targetNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.targetNode = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_traversalProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.TurnBasedAI gen_to_be_invoked = (Pathfinding.Examples.TurnBasedAI)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.traversalProvider = (Pathfinding.BlockManager.TraversalProvider)translator.GetObject(L, 2, typeof(Pathfinding.BlockManager.TraversalProvider));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
