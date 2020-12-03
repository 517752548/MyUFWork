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
    public class PathfindingSeekerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Seeker);
			Utils.BeginObjectRegister(type, L, translator, 0, 29, 9, 9);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCurrentPath", _m_GetCurrentPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CancelCurrentPathRequest", _m_CancelCurrentPathRequest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReleaseClaimedPath", _m_ReleaseClaimedPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RegisterModifier", _m_RegisterModifier);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeregisterModifier", _m_DeregisterModifier);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PostProcess", _m_PostProcess);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RunModifiers", _m_RunModifiers);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsDone", _m_IsDone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartPath", _m_StartPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmos", _m_OnDrawGizmos);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdrawGizmos", _g_get_drawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdetailedGizmos", _g_get_detailedGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstartEndModifier", _g_get_startEndModifier);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettraversableTags", _g_get_traversableTags);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettagPenalties", _g_get_tagPenalties);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphMask", _g_get_graphMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpathCallback", _g_get_pathCallback);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpreProcessPath", _g_get_preProcessPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpostProcessPath", _g_get_postProcessPath);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdrawGizmos", _s_set_drawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdetailedGizmos", _s_set_detailedGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstartEndModifier", _s_set_startEndModifier);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settraversableTags", _s_set_traversableTags);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settagPenalties", _s_set_tagPenalties);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraphMask", _s_set_graphMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpathCallback", _s_set_pathCallback);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpreProcessPath", _s_set_preProcessPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpostProcessPath", _s_set_postProcessPath);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "drawGizmos", _g_get_drawGizmos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "detailedGizmos", _g_get_detailedGizmos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startEndModifier", _g_get_startEndModifier);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "traversableTags", _g_get_traversableTags);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tagPenalties", _g_get_tagPenalties);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphMask", _g_get_graphMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathCallback", _g_get_pathCallback);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "preProcessPath", _g_get_preProcessPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "postProcessPath", _g_get_postProcessPath);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "drawGizmos", _s_set_drawGizmos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "detailedGizmos", _s_set_detailedGizmos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startEndModifier", _s_set_startEndModifier);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "traversableTags", _s_set_traversableTags);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tagPenalties", _s_set_tagPenalties);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "graphMask", _s_set_graphMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathCallback", _s_set_pathCallback);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "preProcessPath", _s_set_preProcessPath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "postProcessPath", _s_set_postProcessPath);
            
			
			
			
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
					
					Pathfinding.Seeker gen_ret = new Pathfinding.Seeker();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Seeker constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurrentPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.Path gen_ret = gen_to_be_invoked.GetCurrentPath(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CancelCurrentPathRequest(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _pool = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.CancelCurrentPathRequest( 
                        _pool );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.CancelCurrentPathRequest(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Seeker.CancelCurrentPathRequest!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReleaseClaimedPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ReleaseClaimedPath(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterModifier(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.IPathModifier _modifier = (Pathfinding.IPathModifier)translator.GetObject(L, 2, typeof(Pathfinding.IPathModifier));
                    
                    gen_to_be_invoked.RegisterModifier( 
                        _modifier );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeregisterModifier(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.IPathModifier _modifier = (Pathfinding.IPathModifier)translator.GetObject(L, 2, typeof(Pathfinding.IPathModifier));
                    
                    gen_to_be_invoked.DeregisterModifier( 
                        _modifier );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostProcess(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.PostProcess( 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunModifiers(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.Seeker.ModifierPass _pass;translator.Get(L, 2, out _pass);
                    PF.Path _path = (PF.Path)translator.GetObject(L, 3, typeof(PF.Path));
                    
                    gen_to_be_invoked.RunModifiers( 
                        _pass, 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDone(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.IsDone(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    
                        PF.Path gen_ret = gen_to_be_invoked.StartPath( 
                        _start, 
                        _end );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.Path>(L, 2)&& translator.Assignable<PF.OnPathDelegate>(L, 3)) 
                {
                    PF.Path _p = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 3);
                    
                        PF.Path gen_ret = gen_to_be_invoked.StartPath( 
                        _p, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.Path>(L, 2)) 
                {
                    PF.Path _p = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                        PF.Path gen_ret = gen_to_be_invoked.StartPath( 
                        _p );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<PF.Path>(L, 2)&& translator.Assignable<PF.OnPathDelegate>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    PF.Path _p = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 3);
                    int _graphMask = LuaAPI.xlua_tointeger(L, 4);
                    
                        PF.Path gen_ret = gen_to_be_invoked.StartPath( 
                        _p, 
                        _callback, 
                        _graphMask );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.OnPathDelegate>(L, 4)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 4);
                    
                        PF.Path gen_ret = gen_to_be_invoked.StartPath( 
                        _start, 
                        _end, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.OnPathDelegate>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 4);
                    int _graphMask = LuaAPI.xlua_tointeger(L, 5);
                    
                        PF.Path gen_ret = gen_to_be_invoked.StartPath( 
                        _start, 
                        _end, 
                        _callback, 
                        _graphMask );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Seeker.StartPath!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrawGizmos(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDrawGizmos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_drawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.drawGizmos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_detailedGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.detailedGizmos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startEndModifier(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.startEndModifier);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_traversableTags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.traversableTags);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tagPenalties(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tagPenalties);
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
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.graphMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathCallback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pathCallback);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preProcessPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.preProcessPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_postProcessPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.postProcessPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_drawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.drawGizmos = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_detailedGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.detailedGizmos = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startEndModifier(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startEndModifier = (Pathfinding.StartEndModifier)translator.GetObject(L, 2, typeof(Pathfinding.StartEndModifier));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_traversableTags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.traversableTags = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tagPenalties(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tagPenalties = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graphMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graphMask = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathCallback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pathCallback = translator.GetDelegate<PF.OnPathDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preProcessPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.preProcessPath = translator.GetDelegate<PF.OnPathDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_postProcessPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Seeker gen_to_be_invoked = (Pathfinding.Seeker)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.postProcessPath = translator.GetDelegate<PF.OnPathDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
