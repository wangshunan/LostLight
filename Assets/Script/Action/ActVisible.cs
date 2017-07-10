using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ActVisible : ActBase
{
    public override void Action(ActionParam param)
    {
		if (param.param == "true")
		{
			param.target.SetActive(true);
		}
		else if (param.param == "inverse")
		{
			param.target.SetActive(!param.target.activeSelf);
		}
		else
		{
			param.target.SetActive(false);
		}
    }
}
