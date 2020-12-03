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
    public class DCETRuntimeMonoBehaviourBridgeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.MonoBehaviourBridge);
			Utils.BeginObjectRegister(type, L, translator, 0, 106, 53, 53);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonAwake", _g_get_onAwake);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonFixedUpdate", _g_get_onFixedUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonLateUpdate", _g_get_onLateUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonAnimatorIK", _g_get_onAnimatorIK);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonAnimatorMove", _g_get_onAnimatorMove);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonApplicationFocus", _g_get_onApplicationFocus);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonApplicationPause", _g_get_onApplicationPause);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonApplicationQuit", _g_get_onApplicationQuit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonAudioFilterRead", _g_get_onAudioFilterRead);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonBecameInvisible", _g_get_onBecameInvisible);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonBecameVisible", _g_get_onBecameVisible);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonCollisionEnter", _g_get_onCollisionEnter);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonCollisionEnter2D", _g_get_onCollisionEnter2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonCollisionExit", _g_get_onCollisionExit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonCollisionExit2D", _g_get_onCollisionExit2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonCollisionStay", _g_get_onCollisionStay);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonCollisionStay2D", _g_get_onCollisionStay2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonConnectedToServer", _g_get_onConnectedToServer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonControllerColliderHit", _g_get_onControllerColliderHit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonDestroy", _g_get_onDestroy);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonDisable", _g_get_onDisable);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonDrawGizmos", _g_get_onDrawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonDrawGizmosSelected", _g_get_onDrawGizmosSelected);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonEnable", _g_get_onEnable);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonJointBreak", _g_get_onJointBreak);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonJointBreak2D", _g_get_onJointBreak2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonMouseDown", _g_get_onMouseDown);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonMouseDrag", _g_get_onMouseDrag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonMouseEnter", _g_get_onMouseEnter);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonMouseExit", _g_get_onMouseExit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonMouseOver", _g_get_onMouseOver);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonMouseUp", _g_get_onMouseUp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonMouseUpAsButton", _g_get_onMouseUpAsButton);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonParticleCollision", _g_get_onParticleCollision);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonParticleTrigger", _g_get_onParticleTrigger);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonPostRender", _g_get_onPostRender);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonPreCull", _g_get_onPreCull);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonPreRender", _g_get_onPreRender);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonRenderObject", _g_get_onRenderObject);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonServerInitialized", _g_get_onServerInitialized);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTransformChildrenChanged", _g_get_onTransformChildrenChanged);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTransformParentChanged", _g_get_onTransformParentChanged);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTriggerEnter", _g_get_onTriggerEnter);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTriggerEnter2D", _g_get_onTriggerEnter2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTriggerExit", _g_get_onTriggerExit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTriggerExit2D", _g_get_onTriggerExit2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTriggerStay", _g_get_onTriggerStay);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonTriggerStay2D", _g_get_onTriggerStay2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonValidate", _g_get_onValidate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonWillRenderObject", _g_get_onWillRenderObject);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonReset", _g_get_onReset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonStart", _g_get_onStart);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonUpdate", _g_get_onUpdate);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonAwake", _s_set_onAwake);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonFixedUpdate", _s_set_onFixedUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonLateUpdate", _s_set_onLateUpdate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonAnimatorIK", _s_set_onAnimatorIK);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonAnimatorMove", _s_set_onAnimatorMove);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonApplicationFocus", _s_set_onApplicationFocus);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonApplicationPause", _s_set_onApplicationPause);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonApplicationQuit", _s_set_onApplicationQuit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonAudioFilterRead", _s_set_onAudioFilterRead);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonBecameInvisible", _s_set_onBecameInvisible);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonBecameVisible", _s_set_onBecameVisible);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonCollisionEnter", _s_set_onCollisionEnter);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonCollisionEnter2D", _s_set_onCollisionEnter2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonCollisionExit", _s_set_onCollisionExit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonCollisionExit2D", _s_set_onCollisionExit2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonCollisionStay", _s_set_onCollisionStay);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonCollisionStay2D", _s_set_onCollisionStay2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonConnectedToServer", _s_set_onConnectedToServer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonControllerColliderHit", _s_set_onControllerColliderHit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonDestroy", _s_set_onDestroy);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonDisable", _s_set_onDisable);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonDrawGizmos", _s_set_onDrawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonDrawGizmosSelected", _s_set_onDrawGizmosSelected);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonEnable", _s_set_onEnable);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonJointBreak", _s_set_onJointBreak);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonJointBreak2D", _s_set_onJointBreak2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonMouseDown", _s_set_onMouseDown);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonMouseDrag", _s_set_onMouseDrag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonMouseEnter", _s_set_onMouseEnter);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonMouseExit", _s_set_onMouseExit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonMouseOver", _s_set_onMouseOver);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonMouseUp", _s_set_onMouseUp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonMouseUpAsButton", _s_set_onMouseUpAsButton);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonParticleCollision", _s_set_onParticleCollision);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonParticleTrigger", _s_set_onParticleTrigger);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonPostRender", _s_set_onPostRender);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonPreCull", _s_set_onPreCull);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonPreRender", _s_set_onPreRender);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonRenderObject", _s_set_onRenderObject);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonServerInitialized", _s_set_onServerInitialized);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTransformChildrenChanged", _s_set_onTransformChildrenChanged);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTransformParentChanged", _s_set_onTransformParentChanged);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTriggerEnter", _s_set_onTriggerEnter);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTriggerEnter2D", _s_set_onTriggerEnter2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTriggerExit", _s_set_onTriggerExit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTriggerExit2D", _s_set_onTriggerExit2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTriggerStay", _s_set_onTriggerStay);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonTriggerStay2D", _s_set_onTriggerStay2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonValidate", _s_set_onValidate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonWillRenderObject", _s_set_onWillRenderObject);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonReset", _s_set_onReset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonStart", _s_set_onStart);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonUpdate", _s_set_onUpdate);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "onAwake", _g_get_onAwake);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onFixedUpdate", _g_get_onFixedUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onLateUpdate", _g_get_onLateUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onAnimatorIK", _g_get_onAnimatorIK);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onAnimatorMove", _g_get_onAnimatorMove);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onApplicationFocus", _g_get_onApplicationFocus);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onApplicationPause", _g_get_onApplicationPause);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onApplicationQuit", _g_get_onApplicationQuit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onAudioFilterRead", _g_get_onAudioFilterRead);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onBecameInvisible", _g_get_onBecameInvisible);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onBecameVisible", _g_get_onBecameVisible);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionEnter", _g_get_onCollisionEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionEnter2D", _g_get_onCollisionEnter2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionExit", _g_get_onCollisionExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionExit2D", _g_get_onCollisionExit2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionStay", _g_get_onCollisionStay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCollisionStay2D", _g_get_onCollisionStay2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onConnectedToServer", _g_get_onConnectedToServer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onControllerColliderHit", _g_get_onControllerColliderHit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDestroy", _g_get_onDestroy);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDisable", _g_get_onDisable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDrawGizmos", _g_get_onDrawGizmos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDrawGizmosSelected", _g_get_onDrawGizmosSelected);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onEnable", _g_get_onEnable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onJointBreak", _g_get_onJointBreak);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onJointBreak2D", _g_get_onJointBreak2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseDown", _g_get_onMouseDown);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseDrag", _g_get_onMouseDrag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseEnter", _g_get_onMouseEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseExit", _g_get_onMouseExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseOver", _g_get_onMouseOver);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseUp", _g_get_onMouseUp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMouseUpAsButton", _g_get_onMouseUpAsButton);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onParticleCollision", _g_get_onParticleCollision);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onParticleTrigger", _g_get_onParticleTrigger);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPostRender", _g_get_onPostRender);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPreCull", _g_get_onPreCull);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onPreRender", _g_get_onPreRender);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onRenderObject", _g_get_onRenderObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onServerInitialized", _g_get_onServerInitialized);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTransformChildrenChanged", _g_get_onTransformChildrenChanged);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTransformParentChanged", _g_get_onTransformParentChanged);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerEnter", _g_get_onTriggerEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerEnter2D", _g_get_onTriggerEnter2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerExit", _g_get_onTriggerExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerExit2D", _g_get_onTriggerExit2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerStay", _g_get_onTriggerStay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTriggerStay2D", _g_get_onTriggerStay2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onValidate", _g_get_onValidate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onWillRenderObject", _g_get_onWillRenderObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onReset", _g_get_onReset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStart", _g_get_onStart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onUpdate", _g_get_onUpdate);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "onAwake", _s_set_onAwake);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onFixedUpdate", _s_set_onFixedUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onLateUpdate", _s_set_onLateUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onAnimatorIK", _s_set_onAnimatorIK);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onAnimatorMove", _s_set_onAnimatorMove);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onApplicationFocus", _s_set_onApplicationFocus);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onApplicationPause", _s_set_onApplicationPause);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onApplicationQuit", _s_set_onApplicationQuit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onAudioFilterRead", _s_set_onAudioFilterRead);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onBecameInvisible", _s_set_onBecameInvisible);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onBecameVisible", _s_set_onBecameVisible);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionEnter", _s_set_onCollisionEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionEnter2D", _s_set_onCollisionEnter2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionExit", _s_set_onCollisionExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionExit2D", _s_set_onCollisionExit2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionStay", _s_set_onCollisionStay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCollisionStay2D", _s_set_onCollisionStay2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onConnectedToServer", _s_set_onConnectedToServer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onControllerColliderHit", _s_set_onControllerColliderHit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDestroy", _s_set_onDestroy);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDisable", _s_set_onDisable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDrawGizmos", _s_set_onDrawGizmos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDrawGizmosSelected", _s_set_onDrawGizmosSelected);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onEnable", _s_set_onEnable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onJointBreak", _s_set_onJointBreak);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onJointBreak2D", _s_set_onJointBreak2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseDown", _s_set_onMouseDown);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseDrag", _s_set_onMouseDrag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseEnter", _s_set_onMouseEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseExit", _s_set_onMouseExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseOver", _s_set_onMouseOver);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseUp", _s_set_onMouseUp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMouseUpAsButton", _s_set_onMouseUpAsButton);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onParticleCollision", _s_set_onParticleCollision);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onParticleTrigger", _s_set_onParticleTrigger);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPostRender", _s_set_onPostRender);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPreCull", _s_set_onPreCull);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onPreRender", _s_set_onPreRender);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onRenderObject", _s_set_onRenderObject);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onServerInitialized", _s_set_onServerInitialized);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTransformChildrenChanged", _s_set_onTransformChildrenChanged);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTransformParentChanged", _s_set_onTransformParentChanged);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerEnter", _s_set_onTriggerEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerEnter2D", _s_set_onTriggerEnter2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerExit", _s_set_onTriggerExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerExit2D", _s_set_onTriggerExit2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerStay", _s_set_onTriggerStay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTriggerStay2D", _s_set_onTriggerStay2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onValidate", _s_set_onValidate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onWillRenderObject", _s_set_onWillRenderObject);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onReset", _s_set_onReset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStart", _s_set_onStart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onUpdate", _s_set_onUpdate);
            
			
			
			
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
					
					DCETRuntime.MonoBehaviourBridge gen_ret = new DCETRuntime.MonoBehaviourBridge();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.MonoBehaviourBridge constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onAwake(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onAwake);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onFixedUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onFixedUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onLateUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onLateUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onAnimatorIK(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onAnimatorIK);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onAnimatorMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onAnimatorMove);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onApplicationFocus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onApplicationFocus);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onApplicationPause(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onApplicationPause);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onApplicationQuit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onApplicationQuit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onAudioFilterRead(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onAudioFilterRead);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onBecameInvisible(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onBecameInvisible);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onBecameVisible(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onBecameVisible);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionEnter2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionEnter2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionExit2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionExit2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionStay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCollisionStay2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCollisionStay2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onConnectedToServer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onConnectedToServer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onControllerColliderHit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onControllerColliderHit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDestroy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDestroy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDisable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDisable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDrawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDrawGizmos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDrawGizmosSelected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDrawGizmosSelected);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onEnable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onEnable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onJointBreak(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onJointBreak);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onJointBreak2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onJointBreak2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseDown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseDown);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseDrag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseDrag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseOver(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseOver);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseUp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMouseUpAsButton(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMouseUpAsButton);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onParticleCollision(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onParticleCollision);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onParticleTrigger(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onParticleTrigger);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPostRender(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPostRender);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPreCull(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPreCull);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onPreRender(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onPreRender);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onRenderObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onRenderObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onServerInitialized(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onServerInitialized);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTransformChildrenChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTransformChildrenChanged);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTransformParentChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTransformParentChanged);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerEnter2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerEnter2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerExit2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerExit2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerStay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTriggerStay2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTriggerStay2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onValidate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onValidate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onWillRenderObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onWillRenderObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onReset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onReset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onAwake(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onAwake = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onFixedUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onFixedUpdate = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onLateUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onLateUpdate = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onAnimatorIK(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onAnimatorIK = translator.GetDelegate<System.Action<int>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onAnimatorMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onAnimatorMove = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onApplicationFocus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onApplicationFocus = translator.GetDelegate<System.Action<bool>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onApplicationPause(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onApplicationPause = translator.GetDelegate<System.Action<bool>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onApplicationQuit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onApplicationQuit = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onAudioFilterRead(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onAudioFilterRead = translator.GetDelegate<System.Action<float[], int>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onBecameInvisible(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onBecameInvisible = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onBecameVisible(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onBecameVisible = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionEnter = translator.GetDelegate<System.Action<UnityEngine.Collision>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionEnter2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionEnter2D = translator.GetDelegate<System.Action<UnityEngine.Collision2D>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionExit = translator.GetDelegate<System.Action<UnityEngine.Collision>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionExit2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionExit2D = translator.GetDelegate<System.Action<UnityEngine.Collision2D>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionStay = translator.GetDelegate<System.Action<UnityEngine.Collision>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCollisionStay2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCollisionStay2D = translator.GetDelegate<System.Action<UnityEngine.Collision2D>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onConnectedToServer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onConnectedToServer = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onControllerColliderHit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onControllerColliderHit = translator.GetDelegate<System.Action<UnityEngine.ControllerColliderHit>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDestroy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDestroy = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDisable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDisable = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDrawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDrawGizmos = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDrawGizmosSelected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDrawGizmosSelected = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onEnable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onEnable = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onJointBreak(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onJointBreak = translator.GetDelegate<System.Action<float>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onJointBreak2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onJointBreak2D = translator.GetDelegate<System.Action<UnityEngine.Joint2D>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseDown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseDown = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseDrag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseDrag = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseEnter = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseExit = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseOver(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseOver = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseUp = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMouseUpAsButton(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMouseUpAsButton = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onParticleCollision(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onParticleCollision = translator.GetDelegate<System.Action<UnityEngine.GameObject>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onParticleTrigger(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onParticleTrigger = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPostRender(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPostRender = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPreCull(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPreCull = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onPreRender(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onPreRender = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onRenderObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onRenderObject = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onServerInitialized(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onServerInitialized = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTransformChildrenChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTransformChildrenChanged = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTransformParentChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTransformParentChanged = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerEnter = translator.GetDelegate<System.Action<UnityEngine.Collider>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerEnter2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerEnter2D = translator.GetDelegate<System.Action<UnityEngine.Collider2D>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerExit = translator.GetDelegate<System.Action<UnityEngine.Collider>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerExit2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerExit2D = translator.GetDelegate<System.Action<UnityEngine.Collider2D>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerStay = translator.GetDelegate<System.Action<UnityEngine.Collider>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTriggerStay2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTriggerStay2D = translator.GetDelegate<System.Action<UnityEngine.Collider2D>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onValidate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onValidate = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onWillRenderObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onWillRenderObject = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onReset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onReset = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStart = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.MonoBehaviourBridge gen_to_be_invoked = (DCETRuntime.MonoBehaviourBridge)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onUpdate = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
