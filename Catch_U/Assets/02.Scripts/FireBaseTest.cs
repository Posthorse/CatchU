using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FireBaseTest : MonoBehaviour
{
    FirebaseAuth _fbauth;

    // Start is called before the first frame update
    void Start()
    {
        _fbauth = FirebaseAuth.DefaultInstance;
        StartCoroutine(Login("jh1211srp@naver.com", "12345678"));
    }

    IEnumerator Login(string email, string password)
    {
        Task<FirebaseUser> task = _fbauth.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => task.IsCompleted);

        if(task.Exception == null)
        {
            print("Login Success");
        }
        else
        {
            print("Login Failed :: " + task.Exception);
            StartCoroutine(Register(email, password));
        }
    }

    IEnumerator Register(string email, string password)
    {
        Task<FirebaseUser> task = _fbauth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => task.IsCompleted);

        if(task.Exception == null)
        {
            print("Register Success");
        }
        else
        {
            print("Register Failed");
        }
    }
}
