using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActChangeScene : ActBase
{
    public override void Action(ActionParam param)
    {
		SceneManager.LoadScene (param.param);
    }
}
