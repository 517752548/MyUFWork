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
    public class PathfindingGraphUpdateObjectWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.GraphUpdateObject);
			Utils.BeginObjectRegister(type, L, translator, 0, 31, 14, 14);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WillUpdateNode", _m_WillUpdateNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RevertFromBackup", _m_RevertFromBackup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbounds", _g_get_bounds);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrequiresFloodFill", _g_get_requiresFloodFill);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getupdatePhysics", _g_get_updatePhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getresetPenaltyOnPhysics", _g_get_resetPenaltyOnPhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getupdateErosion", _g_get_updateErosion);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnnConstraint", _g_get_nnConstraint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getaddPenalty", _g_get_addPenalty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmodifyWalkability", _g_get_modifyWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsetWalkability", _g_get_setWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmodifyTag", _g_get_modifyTag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsetTag", _g_get_setTag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettrackChangedNodes", _g_get_trackChangedNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getchangedNodes", _g_get_changedNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshape", _g_get_shape);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbounds", _s_set_bounds);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrequiresFloodFill", _s_set_requiresFloodFill);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setupdatePhysics", _s_set_updatePhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setresetPenaltyOnPhysics", _s_set_resetPenaltyOnPhysics);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setupdateErosion", _s_set_updateErosion);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnnConstraint", _s_set_nnConstraint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setaddPenalty", _s_set_addPenalty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmodifyWalkability", _s_set_modifyWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsetWalkability", _s_set_setWalkability);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmodifyTag", _s_set_modifyTag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsetTag", _s_set_setTag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settrackChangedNodes", _s_set_trackChangedNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setchangedNodes", _s_set_changedNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshape", _s_set_shape);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "bounds", _g_get_bounds);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "requiresFloodFill", _g_get_requiresFloodFill);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "updatePhysics", _g_get_updatePhysics);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "resetPenaltyOnPhysics", _g_get_resetPenaltyOnPhysics);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "updateErosion", _g_get_updateErosion);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nnConstraint", _g_get_nnConstraint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "addPenalty", _g_get_addPenalty);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "modifyWalkability", _g_get_modifyWalkability);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "setWalkability", _g_get_setWalkability);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "modifyTag", _g_get_modifyTag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "setTag", _g_get_setTag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "trackChangedNodes", _g_get_trackChangedNodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "changedNodes", _g_get_changedNodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shape", _g_get_shape);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "bounds", _s_set_bounds);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "requiresFloodFill", _s_set_requiresFloodFill);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "updatePhysics", _s_set_updatePhysics);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "resetPenaltyOnPhysics", _s_set_resetPenaltyOnPhysics);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "updateErosion", _s_set_updateErosion);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "nnConstraint", _s_set_nnConstraint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "addPenalty", _s_set_addPenalty);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "modifyWalkability", _s_set_modifyWalkability);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "setWalkability", _s_set_setWalkability);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "modifyTag", _s_set_modifyTag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "setTag", _s_set_setTag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "trackChangedNodes", _s_set_trackChangedNodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "changedNodes", _s_set_changedNodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shape", _s_set_shape);
            
			
			
			
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
					
					Pathfinding.GraphUpdateObject gen_ret = new Pathfinding.GraphUpdateObject();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.Bounds>(L, 2))
				{
					UnityEngine.Bounds _b;translator.Get(L, 2, out _b);
					
					Pathfinding.GraphUpdateObject gen_ret = new Pathfinding.GraphUpdateObject(_b);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.GraphUpdateObject constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WillUpdateNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.WillUpdateNode( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RevertFromBackup(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RevertFromBackup(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.Apply( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineBounds(L, gen_to_be_invoked.bounds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_requiresFloodFill(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.requiresFloodFill);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_updatePhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.updatePhysics);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resetPenaltyOnPhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.resetPenaltyOnPhysics);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_updateErosion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.updateErosion);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nnConstraint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nnConstraint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_addPenalty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.addPenalty);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_modifyWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.modifyWalkability);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_setWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.setWalkability);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_modifyTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.modifyTag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_setTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.setTag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_trackChangedNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.trackChangedNodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_changedNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.changedNodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shape(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shape);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                UnityEngine.Bounds gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.bounds = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_requiresFloodFill(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.requiresFloodFill = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_updatePhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.updatePhysics = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resetPenaltyOnPhysics(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.resetPenaltyOnPhysics = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_updateErosion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.updateErosion = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nnConstraint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nnConstraint = (PF.NNConstraint)translator.GetObject(L, 2, typeof(PF.NNConstraint));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_addPenalty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.addPenalty = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_modifyWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.modifyWalkability = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_setWalkability(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.setWalkability = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_modifyTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.modifyTag = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_setTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.setTag = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_trackChangedNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.trackChangedNodes = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_changedNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.changedNodes = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<PF.GraphNode>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shape(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.GraphUpdateObject gen_to_be_invoked = (Pathfinding.GraphUpdateObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shape = (Pathfinding.GraphUpdateShape)translator.GetObject(L, 2, typeof(Pathfinding.GraphUpdateShape));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
