using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EventSystem : MonoBehaviour
{
    [SerializeReference] private SerializeField _optionsButton;
    [SerializeField] private GameObject panelMain, panelOptions;
    [SerializeField] private float waitTime = 1f;
    
    private Animator _animPanelMain, _animPanelOption;
    private Button _buttonOption, _buttonReturn;
    private static readonly int Unfold1 = Animator.StringToHash("unfold");
    private static readonly int Fold1 = Animator.StringToHash("fold");

    public void Start()
    {
        _animPanelMain = panelMain.GetComponent<Animator>();
        _animPanelOption = panelOptions.GetComponent<Animator>();
        _buttonOption = panelMain.transform.Find("ButtonOptions").GetComponent<Button>();
        _buttonReturn = panelOptions.transform.Find("ButtonReturn").GetComponent<Button>();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Fold()
    {
        StartCoroutine(FoldPanel());
    }

    public void Unfold()
    {
        StartCoroutine(UnfoldPanel());
    }
    private IEnumerator FoldPanel()
    {
        _buttonOption.interactable = false;
        _animPanelMain.SetTrigger(Unfold1);
        yield return new WaitForSeconds(waitTime);
        panelMain.SetActive(false);
        panelOptions.SetActive(true);
        _animPanelOption.SetTrigger(Fold1);
        yield return new WaitForSeconds(waitTime);
        _buttonReturn.interactable = true;
    }

    private IEnumerator UnfoldPanel()
    {
        _buttonReturn.interactable = false;
        _animPanelOption.SetTrigger(Unfold1);
        yield return new WaitForSeconds(waitTime);
        panelOptions.SetActive(false);
        panelMain.SetActive(true);
        _animPanelMain.SetTrigger(Fold1);
        yield return new WaitForSeconds(waitTime);
        _buttonOption.interactable = true;
    }
}