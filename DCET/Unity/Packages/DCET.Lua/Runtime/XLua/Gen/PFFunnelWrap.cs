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
    public class PFFunnelWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.Funnel);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 6, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SplitIntoParts", _m_SplitIntoParts_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ConstructFunnelPortals", _m_ConstructFunnelPortals_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ShrinkPortals", _m_ShrinkPortals_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Unwrap", _m_Unwrap_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Calculate", _m_Calculate_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.Funnel gen_ret = new PF.Funnel();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.Funnel constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SplitIntoParts_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 1, typeof(PF.Path));
                    
                        System.Collections.Generic.List<PF.Funnel.PathPart> gen_ret = PF.Funnel.SplitIntoParts( 
                        _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConstructFunnelPortals_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<PF.GraphNode> _nodes = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<PF.GraphNode>));
                    PF.Funnel.PathPart _part;translator.Get(L, 2, out _part);
                    
                        PF.Funnel.FunnelPortals gen_ret = PF.Funnel.ConstructFunnelPortals( 
                        _nodes, 
                        _part );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShrinkPortals_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Funnel.FunnelPortals _portals;translator.Get(L, 1, out _portals);
                    float _shrink = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    PF.Funnel.ShrinkPortals( 
                        _portals, 
                        _shrink );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unwrap_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Funnel.FunnelPortals _funnel;translator.Get(L, 1, out _funnel);
                    UnityEngine.Vector2[] _left = (UnityEngine.Vector2[])translator.GetObject(L, 2, typeof(UnityEngine.Vector2[]));
                    UnityEngine.Vector2[] _right = (UnityEngine.Vector2[])translator.GetObject(L, 3, typeof(UnityEngine.Vector2[]));
                    
                    PF.Funnel.Unwrap( 
                        _funnel, 
                        _left, 
                        _right );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Calculate_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Funnel.FunnelPortals _funnel;translator.Get(L, 1, out _funnel);
                    bool _unwrap = LuaAPI.lua_toboolean(L, 2);
                    bool _splitAtEveryPortal = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> gen_ret = PF.Funnel.Calculate( 
                        _funnel, 
                        _unwrap, 
                        _splitAtEveryPortal );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
