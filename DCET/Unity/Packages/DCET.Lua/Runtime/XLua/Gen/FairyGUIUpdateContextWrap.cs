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
    public class FairyGUIUpdateContextWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.UpdateContext);
			Utils.BeginObjectRegister(type, L, translator, 0, 20, 8, 8);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Begin", _m_Begin);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "End", _m_End);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EnterClipping", _m_EnterClipping);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LeaveClipping", _m_LeaveClipping);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getclipped", _g_get_clipped);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getclipInfo", _g_get_clipInfo);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrenderingOrder", _g_get_renderingOrder);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbatchingDepth", _g_get_batchingDepth);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrectMaskDepth", _g_get_rectMaskDepth);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstencilReferenceValue", _g_get_stencilReferenceValue);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getalpha", _g_get_alpha);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgrayed", _g_get_grayed);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setclipped", _s_set_clipped);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setclipInfo", _s_set_clipInfo);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrenderingOrder", _s_set_renderingOrder);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbatchingDepth", _s_set_batchingDepth);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrectMaskDepth", _s_set_rectMaskDepth);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstencilReferenceValue", _s_set_stencilReferenceValue);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setalpha", _s_set_alpha);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgrayed", _s_set_grayed);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "clipped", _g_get_clipped);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "clipInfo", _g_get_clipInfo);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "renderingOrder", _g_get_renderingOrder);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "batchingDepth", _g_get_batchingDepth);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rectMaskDepth", _g_get_rectMaskDepth);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "stencilReferenceValue", _g_get_stencilReferenceValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "alpha", _g_get_alpha);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "grayed", _g_get_grayed);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "clipped", _s_set_clipped);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "clipInfo", _s_set_clipInfo);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "renderingOrder", _s_set_renderingOrder);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "batchingDepth", _s_set_batchingDepth);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rectMaskDepth", _s_set_rectMaskDepth);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "stencilReferenceValue", _s_set_stencilReferenceValue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "alpha", _s_set_alpha);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "grayed", _s_set_grayed);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 21, 5, 5);
			
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getcurrent", _g_get_current);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getframeId", _g_get_frameId);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getworking", _g_get_working);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnBegin", _g_get_OnBegin);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnEnd", _g_get_OnEnd);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setcurrent", _s_set_current);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setframeId", _s_set_frameId);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setworking", _s_set_working);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnBegin", _s_set_OnBegin);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnEnd", _s_set_OnEnd);
            
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "current", _g_get_current);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "frameId", _g_get_frameId);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "working", _g_get_working);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnBegin", _g_get_OnBegin);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnEnd", _g_get_OnEnd);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "current", _s_set_current);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "frameId", _s_set_frameId);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "working", _s_set_working);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnBegin", _s_set_OnBegin);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnEnd", _s_set_OnEnd);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					FairyGUI.UpdateContext gen_ret = new FairyGUI.UpdateContext();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.UpdateContext constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Begin(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Begin(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_End(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.End(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterClipping(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    uint _clipId = LuaAPI.xlua_touint(L, 2);
                    System.Nullable<UnityEngine.Rect> _clipRect;translator.Get(L, 3, out _clipRect);
                    System.Nullable<UnityEngine.Vector4> _softness;translator.Get(L, 4, out _softness);
                    bool _reversedMask = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.EnterClipping( 
                        _clipId, 
                        _clipRect, 
                        _softness, 
                        _reversedMask );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LeaveClipping(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.LeaveClipping(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_clipped(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.clipped);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_clipInfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.clipInfo);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderingOrder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.renderingOrder);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_batchingDepth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.batchingDepth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rectMaskDepth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.rectMaskDepth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_stencilReferenceValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.stencilReferenceValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_alpha(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.alpha);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_grayed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.grayed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, FairyGUI.UpdateContext.current);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_frameId(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushuint(L, FairyGUI.UpdateContext.frameId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_working(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, FairyGUI.UpdateContext.working);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnBegin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, FairyGUI.UpdateContext.OnBegin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnEnd(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, FairyGUI.UpdateContext.OnEnd);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_clipped(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.clipped = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_clipInfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                FairyGUI.UpdateContext.ClipInfo gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.clipInfo = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_renderingOrder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.renderingOrder = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_batchingDepth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.batchingDepth = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rectMaskDepth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rectMaskDepth = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_stencilReferenceValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.stencilReferenceValue = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_alpha(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.alpha = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_grayed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext gen_to_be_invoked = (FairyGUI.UpdateContext)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.grayed = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    FairyGUI.UpdateContext.current = (FairyGUI.UpdateContext)translator.GetObject(L, 1, typeof(FairyGUI.UpdateContext));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_frameId(RealStatePtr L)
        {
		    try {
                
			    FairyGUI.UpdateContext.frameId = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_working(RealStatePtr L)
        {
		    try {
                
			    FairyGUI.UpdateContext.working = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnBegin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    FairyGUI.UpdateContext.OnBegin = translator.GetDelegate<FairyGUI.EventCallback0>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnEnd(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    FairyGUI.UpdateContext.OnEnd = translator.GetDelegate<FairyGUI.EventCallback0>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
