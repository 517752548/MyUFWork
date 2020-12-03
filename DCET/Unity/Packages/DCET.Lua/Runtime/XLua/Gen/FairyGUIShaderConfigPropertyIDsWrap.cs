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
    public class FairyGUIShaderConfigPropertyIDsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.ShaderConfig.PropertyIDs);
			Utils.BeginObjectRegister(type, L, translator, 0, 26, 13, 13);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_ClipBox", _g_get__ClipBox);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_ClipSoftness", _g_get__ClipSoftness);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_AlphaTex", _g_get__AlphaTex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_StencilComp", _g_get__StencilComp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_Stencil", _g_get__Stencil);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_StencilOp", _g_get__StencilOp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_StencilReadMask", _g_get__StencilReadMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_ColorMask", _g_get__ColorMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_ColorMatrix", _g_get__ColorMatrix);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_ColorOffset", _g_get__ColorOffset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_BlendSrcFactor", _g_get__BlendSrcFactor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_BlendDstFactor", _g_get__BlendDstFactor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_ColorOption", _g_get__ColorOption);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_ClipBox", _s_set__ClipBox);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_ClipSoftness", _s_set__ClipSoftness);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_AlphaTex", _s_set__AlphaTex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_StencilComp", _s_set__StencilComp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_Stencil", _s_set__Stencil);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_StencilOp", _s_set__StencilOp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_StencilReadMask", _s_set__StencilReadMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_ColorMask", _s_set__ColorMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_ColorMatrix", _s_set__ColorMatrix);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_ColorOffset", _s_set__ColorOffset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_BlendSrcFactor", _s_set__BlendSrcFactor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_BlendDstFactor", _s_set__BlendDstFactor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_ColorOption", _s_set__ColorOption);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "_ClipBox", _g_get__ClipBox);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_ClipSoftness", _g_get__ClipSoftness);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_AlphaTex", _g_get__AlphaTex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_StencilComp", _g_get__StencilComp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_Stencil", _g_get__Stencil);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_StencilOp", _g_get__StencilOp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_StencilReadMask", _g_get__StencilReadMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_ColorMask", _g_get__ColorMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_ColorMatrix", _g_get__ColorMatrix);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_ColorOffset", _g_get__ColorOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_BlendSrcFactor", _g_get__BlendSrcFactor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_BlendDstFactor", _g_get__BlendDstFactor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_ColorOption", _g_get__ColorOption);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "_ClipBox", _s_set__ClipBox);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_ClipSoftness", _s_set__ClipSoftness);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_AlphaTex", _s_set__AlphaTex);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_StencilComp", _s_set__StencilComp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_Stencil", _s_set__Stencil);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_StencilOp", _s_set__StencilOp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_StencilReadMask", _s_set__StencilReadMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_ColorMask", _s_set__ColorMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_ColorMatrix", _s_set__ColorMatrix);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_ColorOffset", _s_set__ColorOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_BlendSrcFactor", _s_set__BlendSrcFactor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_BlendDstFactor", _s_set__BlendDstFactor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_ColorOption", _s_set__ColorOption);
            
			
			
			
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
					
					FairyGUI.ShaderConfig.PropertyIDs gen_ret = new FairyGUI.ShaderConfig.PropertyIDs();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.ShaderConfig.PropertyIDs constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__ClipBox(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._ClipBox);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__ClipSoftness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._ClipSoftness);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__AlphaTex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._AlphaTex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__StencilComp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._StencilComp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__Stencil(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._Stencil);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__StencilOp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._StencilOp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__StencilReadMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._StencilReadMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__ColorMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._ColorMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__ColorMatrix(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._ColorMatrix);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__ColorOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._ColorOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__BlendSrcFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._BlendSrcFactor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__BlendDstFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._BlendDstFactor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__ColorOption(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked._ColorOption);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__ClipBox(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._ClipBox = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__ClipSoftness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._ClipSoftness = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__AlphaTex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._AlphaTex = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__StencilComp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._StencilComp = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__Stencil(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._Stencil = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__StencilOp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._StencilOp = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__StencilReadMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._StencilReadMask = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__ColorMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._ColorMask = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__ColorMatrix(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._ColorMatrix = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__ColorOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._ColorOffset = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__BlendSrcFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._BlendSrcFactor = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__BlendDstFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._BlendDstFactor = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__ColorOption(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.ShaderConfig.PropertyIDs gen_to_be_invoked = (FairyGUI.ShaderConfig.PropertyIDs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._ColorOption = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
