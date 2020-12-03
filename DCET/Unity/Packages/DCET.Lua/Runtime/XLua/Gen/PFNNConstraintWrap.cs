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
    public class PFNNConstraintWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.NNConstraint);
			Utils.BeginObjectRegister(type, L, translator, 0, 20, 9, 9);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SuitableGraph", _m_SuitableGraph);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Suitable", _m_Suitable);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphMask", _g_get_graphMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconstrainArea", _g_get_constrainArea);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getarea", _g_get_area);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconstrainWalkability", _g_get_constrainWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwalkable", _g_get_walkable);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdistanceXZ", _g_get_distanceXZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconstrainTags", _g_get_constrainTags);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettags", _g_get_tags);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconstrainDistance", _g_get_constrainDistance);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraphMask", _s_set_graphMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconstrainArea", _s_set_constrainArea);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setarea", _s_set_area);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconstrainWalkability", _s_set_constrainWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setwalkable", _s_set_walkable);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdistanceXZ", _s_set_distanceXZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconstrainTags", _s_set_constrainTags);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settags", _s_set_tags);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconstrainDistance", _s_set_constrainDistance);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphMask", _g_get_graphMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "constrainArea", _g_get_constrainArea);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "area", _g_get_area);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "constrainWalkability", _g_get_constrainWalkability);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "walkable", _g_get_walkable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "distanceXZ", _g_get_distanceXZ);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "constrainTags", _g_get_constrainTags);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tags", _g_get_tags);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "constrainDistance", _g_get_constrainDistance);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "graphMask", _s_set_graphMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "constrainArea", _s_set_constrainArea);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "area", _s_set_area);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "constrainWalkability", _s_set_constrainWalkability);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "walkable", _s_set_walkable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "distanceXZ", _s_set_distanceXZ);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "constrainTags", _s_set_constrainTags);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tags", _s_set_tags);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "constrainDistance", _s_set_constrainDistance);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 2, 0);
			
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getDefault", _g_get_Default);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getNone", _g_get_None);
            
			
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Default", _g_get_Default);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "None", _g_get_None);
            
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.NNConstraint gen_ret = new PF.NNConstraint();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NNConstraint constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SuitableGraph(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _graphIndex = LuaAPI.xlua_tointeger(L, 2);
                    PF.NavGraph _graph = (PF.NavGraph)translator.GetObject(L, 3, typeof(PF.NavGraph));
                    
                        bool gen_ret = gen_to_be_invoked.SuitableGraph( 
                        _graphIndex, 
                        _graph );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Suitable(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        bool gen_ret = gen_to_be_invoked.Suitable( 
                        _node );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Default(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.NNConstraint.Default);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_None(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.NNConstraint.None);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.graphMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constrainArea(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.constrainArea);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_area(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.area);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constrainWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.constrainWalkability);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_walkable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.walkable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_distanceXZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.distanceXZ);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constrainTags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.constrainTags);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.tags);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constrainDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.constrainDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graphMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graphMask = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constrainArea(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.constrainArea = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_area(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.area = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constrainWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.constrainWalkability = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_walkable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.walkable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_distanceXZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.distanceXZ = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constrainTags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.constrainTags = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tags = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constrainDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNConstraint gen_to_be_invoked = (PF.NNConstraint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.constrainDistance = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
