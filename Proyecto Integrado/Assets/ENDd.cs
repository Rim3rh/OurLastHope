using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDd : MonoBehaviour
{
   

    public IEnumerator end()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0);
    }
}
