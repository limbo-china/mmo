using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SceneManager : MonoSingleton<SceneManager>
    {
        public void LoadScene(string name)
        {
            StartCoroutine(Load(name));
        }
        public void UnloadScene(string name)
        {
            StartCoroutine(Unload(name));
        }

        IEnumerator Load(string name)
        {
            Debug.LogFormat("LoadLevel: {0}", name);
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
            async.allowSceneActivation = true;
            async.completed += SceneLoadedCallback;
            while (!async.isDone)
            {
                //if (onProgress != null)
                //    onProgress(async.progress);
                yield return null;
            }
        }
        IEnumerator Unload(string name)
        {
            Debug.LogFormat("UnLoadLevel: {0}", name);
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(name);
            async.allowSceneActivation = true;
            async.completed += SceneUnloadedCallback;
            while (!async.isDone)
            {
                //if (onProgress != null)
                //    onProgress(async.progress);
                yield return null;
            }
        }

        void SceneLoadedCallback(AsyncOperation op)
        {
            Debug.Log("SceneLoadCompleted:" + op.progress);
        }

        void SceneUnloadedCallback(AsyncOperation op)
        {
            Debug.Log("SceneUnloadCompleted:" + op.progress);
        }
    }
}
