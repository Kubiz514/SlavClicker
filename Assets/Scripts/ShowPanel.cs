using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanel : MonoBehaviour
{
    public GameObject UpgradesPanel;
    public GameObject UpgPerSecondPanel;
    public GameObject UpgPerClickPanel;
    public Animator UpgPanelAnimator;
    public ScrollRect Scroll;
    public Text UpgradesPanelTitle;
    public AnimationClip HideAnimation;

    public void ShowUpgPerClick()
    {
        UpgradesPanel.SetActive(true);
        Scroll.content = UpgPerClickPanel.GetComponent<RectTransform>();
        UpgPanelAnimator.Play("ShowUpgPanelAnim");
        UpgPerSecondPanel.SetActive(false);
        UpgPerClickPanel.SetActive(true);
        UpgradesPanelTitle.text = "Semechki per\nclick upgrades";
    }

    public void ShowUpgPerSecond()
    {
        UpgradesPanel.SetActive(true);
        Scroll.content = UpgPerSecondPanel.GetComponent<RectTransform>();
        UpgPanelAnimator.Play("ShowUpgPanelAnim");
        UpgPerClickPanel.SetActive(false);
        UpgPerSecondPanel.SetActive(true);
        UpgradesPanelTitle.text = "Semechki per\nsecond upgrades";
    }

    public void HideUpgradesPanel()
    {
        StartCoroutine(PlayUpgradesPanelHideAnimation());

    }

    IEnumerator PlayUpgradesPanelHideAnimation()
    {
        UpgPanelAnimator.Play("HideUpgPanelAnim");
        yield return new WaitForSeconds(HideAnimation.length);
        UpgradesPanel.SetActive(false);
        StopCoroutine("PlayUpgradesPanelHideAnimation");
    }

}
