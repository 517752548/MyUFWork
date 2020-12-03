using System;
using UnityEngine;

namespace DCETRuntime
{
    public sealed class MonoBehaviourBridge : MonoBehaviour
    {
        public Action onAwake;
        public Action onFixedUpdate;
        public Action onLateUpdate;
        public Action<int> onAnimatorIK;
        public Action onAnimatorMove;
        public Action<bool> onApplicationFocus;
        public Action<bool> onApplicationPause;
        public Action onApplicationQuit;
        public Action<float[], int> onAudioFilterRead;
        public Action onBecameInvisible;
        public Action onBecameVisible;
        public Action<Collision> onCollisionEnter;
        public Action<Collision2D> onCollisionEnter2D;
        public Action<Collision> onCollisionExit;
        public Action<Collision2D> onCollisionExit2D;
        public Action<Collision> onCollisionStay;
        public Action<Collision2D> onCollisionStay2D;
        public Action onConnectedToServer;
        public Action<ControllerColliderHit> onControllerColliderHit;
        public Action onDestroy;
        public Action onDisable;
        public Action onDrawGizmos;
        public Action onDrawGizmosSelected;
        public Action onEnable;
        public Action<float> onJointBreak;
        public Action<Joint2D> onJointBreak2D;
        public Action onMouseDown;
        public Action onMouseDrag;
        public Action onMouseEnter;
        public Action onMouseExit;
        public Action onMouseOver;
        public Action onMouseUp;
        public Action onMouseUpAsButton;
        public Action<GameObject> onParticleCollision;
        public Action onParticleTrigger;
        public Action onPostRender;
        public Action onPreCull;
        public Action onPreRender;
        public Action onRenderObject;
        public Action onServerInitialized;
        public Action onTransformChildrenChanged;
        public Action onTransformParentChanged;
        public Action<Collider> onTriggerEnter;
        public Action<Collider2D> onTriggerEnter2D;
        public Action<Collider> onTriggerExit;
        public Action<Collider2D> onTriggerExit2D;
        public Action<Collider> onTriggerStay;
        public Action<Collider2D> onTriggerStay2D;
        public Action onValidate;
        public Action onWillRenderObject;
        public Action onReset;
        public Action onStart;
        public Action onUpdate;

        private void Awake()
        {
            onAwake?.Invoke();
        }

        private void FixedUpdate()
        {
            onFixedUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            onLateUpdate?.Invoke();
        }

        private void OnAnimatorIK(int layerIndex)
        {
            onAnimatorIK?.Invoke(layerIndex);
        }

        private void OnAnimatorMove()
        {
            onAnimatorMove?.Invoke();
        }

        private void OnApplicationFocus(bool focus)
        {
            onApplicationFocus?.Invoke(focus);
        }

        private void OnApplicationPause(bool pause)
        {
            onApplicationPause?.Invoke(pause);
        }

        private void OnApplicationQuit()
        {
            onApplicationQuit?.Invoke();
        }

        private void OnAudioFilterRead(float[] data, int channels)
        {
            onAudioFilterRead?.Invoke(data, channels);
        }

        private void OnBecameInvisible()
        {
            onBecameInvisible?.Invoke();
        }

        private void OnBecameVisible()
        {
            onBecameVisible?.Invoke();
        }

        private void OnCollisionEnter(Collision collision)
        {
            onCollisionEnter?.Invoke(collision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            onCollisionEnter2D?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            onCollisionExit?.Invoke(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            onCollisionExit2D?.Invoke(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            onCollisionStay?.Invoke(collision);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            onCollisionStay2D?.Invoke(collision);
        }

        private void OnConnectedToServer()
        {
            onConnectedToServer?.Invoke();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            onControllerColliderHit?.Invoke(hit);
        }

        private void OnDestroy()
        {
            onDestroy?.Invoke();
        }

        private void OnDisable()
        {
            onDisable?.Invoke();
        }

        private void OnDrawGizmosSelected()
        {
            onDrawGizmosSelected?.Invoke();
        }

        private void OnEnable()
        {
            onEnable?.Invoke();
        }

		private void OnJointBreak(float breakForce)
        {
            onJointBreak?.Invoke(breakForce);
        }

        private void OnJointBreak2D(Joint2D joint)
        {
            onJointBreak2D?.Invoke(joint);
        }

        private void OnMouseDown()
        {
            onMouseDown?.Invoke();
        }

        private void OnMouseDrag()
        {
            onMouseDrag?.Invoke();
        }

        private void OnMouseEnter()
        {
            onMouseEnter?.Invoke();
        }

        private void OnMouseExit()
        {
            onMouseExit?.Invoke();
        }

        private void OnMouseOver()
        {
            onMouseOver?.Invoke();
        }

        private void OnMouseUp()
        {
            onMouseUp?.Invoke();
        }

        private void OnMouseUpAsButton()
        {
            onMouseUpAsButton?.Invoke();
        }

        private void OnParticleCollision(GameObject other)
        {
            onParticleCollision?.Invoke(other);
        }

        private void OnParticleTrigger()
        {
            onParticleTrigger?.Invoke();
        }

        private void OnPostRender()
        {
            onPostRender?.Invoke();
        }

        private void OnPreCull()
        {
            onPreCull?.Invoke();
        }

        private void OnPreRender()
        {
            onPreRender?.Invoke();
        }

        private void OnRenderObject()
        {
            onRenderObject?.Invoke();
        }

        private void OnServerInitialized()
        {
            onServerInitialized?.Invoke();
        }

        private void OnTransformChildrenChanged()
        {
            onTransformChildrenChanged?.Invoke();
        }

        private void OnTransformParentChanged()
        {
            onTransformParentChanged?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter?.Invoke(other);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            onTriggerEnter2D?.Invoke(collision);
        }

        private void OnTriggerExit(Collider other)
        {
            onTriggerExit?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            onTriggerExit2D?.Invoke(collision);
        }

        private void OnTriggerStay(Collider other)
        {
            onTriggerStay?.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            onTriggerStay2D?.Invoke(collision);
        }

        private void OnValidate()
        {
            onValidate?.Invoke();
        }

        private void OnWillRenderObject()
        {
            onWillRenderObject?.Invoke();
        }

        private void Reset()
        {
            onReset?.Invoke();
        }

        private void Start()
        {
            onStart?.Invoke();
        }

        private void Update()
        {
            onUpdate?.Invoke();
        }
    }
}