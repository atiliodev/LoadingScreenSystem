using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{

    [Header("UI References")]
    public Slider progressBar;
    public TextMeshProUGUI percentageText;
    public GameObject LoadingPainel;

    private float loadingStartTime;
    private float targetProgress = 0;

    private void Start()
    {
        LoadingPainel.SetActive(false);
    }

    public void LoadScene(string sceneToLoad) { StartCoroutine(LoadSceneAsync(sceneToLoad)); }

    IEnumerator LoadSceneAsync(string sceneToLoad)
    {
        LoadingPainel.SetActive(true);

        loadingStartTime = Time.time;

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        loadOperation.allowSceneActivation = false;
        

        while (!loadOperation.isDone)
        {
            targetProgress = Mathf.MoveTowards(progressBar.value, 1, 0.0000001f);


            UpdateUI(targetProgress);
            
            if(loadOperation.progress >= 0.9f)
            {

                while(progressBar.value < 1)
                {
                    targetProgress = Mathf.MoveTowards(progressBar.value, 1, Time.deltaTime);
                    UpdateUI(targetProgress);
                    yield return null;
                }

                yield return new WaitForSeconds(0.00001f);
                loadOperation.allowSceneActivation = true;
                
            }

            yield return null;
        }

        
    }

    void UpdateUI(float progress)
    {
        if (progress != null) { progressBar.value = progress; }

        if (percentageText != null) { percentageText.text = $"{(progress * 100):F0}%" + " Loading..."; }
    }

}
